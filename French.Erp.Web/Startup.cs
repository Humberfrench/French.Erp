using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc.Authorization;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using System;
using System.Text.Json.Serialization;

namespace French.Erp.Web
{
    using static Ioc.Bootstraper;
    public class Startup
    {
        public IWebHostEnvironment Env { get; set; }
        public IConfiguration Configuration { get; }

        public Startup(IConfiguration configuration, IWebHostEnvironment env)
        {
            Configuration = configuration;
            Env = env;
        }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddDistributedMemoryCache();
            services.AddControllersWithViews();

            //IConfigurationRoot configuration = new ConfigurationBuilder().SetBasePath(Directory.GetCurrentDirectory())
            //                                                             .AddJsonFile("appsettings.json").Build();

            var sessionTimeInSeconds = Convert.ToInt32(Configuration.GetSection("SessionTimeInMinutes").Value) * 60;

            services.AddSession(options =>
            {
                options.IdleTimeout = TimeSpan.FromSeconds(sessionTimeInSeconds);
                options.Cookie.HttpOnly = true;
                options.Cookie.IsEssential = true;
            });

            services.Configure<CookiePolicyOptions>(options =>
            {
                // This lambda determines whether user consent for non-essential cookies is needed for a given request.
                options.CheckConsentNeeded = context => false;
                options.MinimumSameSitePolicy = SameSiteMode.None;
            });

            services.AddControllersWithViews().AddJsonOptions(options =>
            {
                options.JsonSerializerOptions.WriteIndented = true;
                options.JsonSerializerOptions.DefaultIgnoreCondition = JsonIgnoreCondition.WhenWritingDefault;
            });

            services.AddMvc().AddRazorPagesOptions(options => options.Conventions.AddAreaPageRoute("Home", "/Index", ""));

            services.AddMvc(config =>
            {

                var policy = new AuthorizationPolicyBuilder()
                .RequireAuthenticatedUser()
                .Build();

                config.Filters.Add(new AuthorizeFilter(policy));
            });

            services.AddAuthentication(optionsAuth =>
            {

                optionsAuth.DefaultAuthenticateScheme = CookieAuthenticationDefaults.AuthenticationScheme;
                optionsAuth.DefaultSignInScheme = CookieAuthenticationDefaults.AuthenticationScheme;
                optionsAuth.DefaultChallengeScheme = CookieAuthenticationDefaults.AuthenticationScheme;

            }).AddCookie(CookieAuthenticationDefaults.AuthenticationScheme,
            options =>
            {
                options.Cookie.HttpOnly = true; // Um sinalizador que diz que o cookie está disponível apenas para servidores. O navegador envia apenas o cookie, mas não pode acessá-lo através do JavaScript
                options.LoginPath = "/Account";
                options.AccessDeniedPath = "/Account";
            });

            //container IOC and Contexts
            Initializer(services, Configuration);
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }
            else
            {
                app.UseExceptionHandler("/Home/Error");
                app.UseHsts();
            }

            app.Use(async (ctx, next) =>
            {
                await next();

                if (ctx.Response.StatusCode == 404 && !ctx.Response.HasStarted)
                {
                    //Re-execute the request so the user gets the error page
                    string originalPath = ctx.Request.Path.Value;
                    ctx.Items["originalPath"] = originalPath;
                    ctx.Request.Path = "/Home/404";
                    await next();
                }
            });
            app.UseHttpsRedirection();

            app.UseStaticFiles();

            app.UseRouting();

            app.UseSession();

            app.UseAuthentication();

            app.UseCookiePolicy();

            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllerRoute(
                    name: "default",
                    pattern: "{controller=Home}/{action=Index}/{id?}");
            });
        }
    }
}
