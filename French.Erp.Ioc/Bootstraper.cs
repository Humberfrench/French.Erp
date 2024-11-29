using Microsoft.Extensions.DependencyInjection;

namespace French.Erp.Ioc
{
    using Application.Services;
    using Domain.Interfaces.Repository;
    using Domain.Interfaces.Services;
    using French.Erp.Repository.Support;
    using French.Erp.ViewModel.Interface;
    using Microsoft.AspNetCore.Http;
    using Microsoft.AspNetCore.Mvc.Infrastructure;
    using Microsoft.EntityFrameworkCore;
    using Microsoft.Extensions.Configuration;
    using Repository;
    using Repository.Context;
    using Repository.Interfaces;
    using Repository.UnitOfWork;
    using Services;

    public static class Bootstraper
    {
        public static void Initializer(IServiceCollection services, IConfiguration configuration)
        {

            //Services
            services.AddSingleton<IHttpContextAccessor, HttpContextAccessor>();
            services.AddSingleton<IActionContextAccessor, ActionContextAccessor>();
            services.AddScoped<IContextManager, ContextManager>();
            services.AddScoped<IUnitOfWork, UnitOfWork>();
            //services.AddScoped<IConfiguration, ConfigurationSection>();
            //services.AddScoped<IConfiguration, ConfigurationRoot>();
            //services.AddScoped<IConfigurationProvider, ConfigurationProvider>();

            services.AddDbContext<FrenchContext>(options => options.UseSqlServer(configuration.GetConnectionString("FrenchContext")));

            //Services
            services.AddScoped(typeof(IBaseRepository<>), typeof(BaseRepository<>));

            services.AddScoped<IConvertKey, ConvertKey>();

            services.AddScoped<ITarefaAppService, TarefaAppService>();
            services.AddScoped<ITarefaService, TarefaService>();
            services.AddScoped<ITarefaRepository, TarefaRepository>();

            services.AddScoped<ITipoDePessoaRepository, TipoDePessoaRepository>();
            services.AddScoped<ITipoDePessoaService, TipoDePessoaService>();
            services.AddScoped<ITipoDePessoaAppService, TipoDePessoaAppService>();

            services.AddScoped<ITipoDeClienteRepository, TipoDeClienteRepository>();
            services.AddScoped<ITipoDeClienteService, TipoDeClienteService>();
            services.AddScoped<ITipoDeClienteAppService, TipoDeClienteAppService>();

            services.AddScoped<IStatusNotaFiscalAppService, StatusNotaFiscalAppService>();
            services.AddScoped<IStatusNotaFiscalService, StatusNotaFiscalService>();
            services.AddScoped<IStatusNotaFiscalRepository, StatusNotaFiscalRepository>();

            services.AddScoped<IServicoAppService, ServicoAppService>();
            services.AddScoped<IServicoService, ServicoService>();
            services.AddScoped<IServicoRepository, ServicoRepository>();

            services.AddScoped<ITarefaAppService, TarefaAppService>();
            services.AddScoped<ITarefaService, TarefaService>();
            services.AddScoped<ITarefaRepository, TarefaRepository>();

            services.AddScoped<ITarefaItemAppService, TarefaItemAppService>();
            services.AddScoped<ITarefaItemService, TarefaItemService>();
            services.AddScoped<ITarefaItemRepository, TarefaItemRepository>();

            services.AddScoped<IClienteAppService, ClienteAppService>();
            services.AddScoped<IClienteService, ClienteService>();
            services.AddScoped<IClienteRepository, ClienteRepository>();

            //services.AddScoped<IClienteAppService, ClienteAppService>();
            services.AddScoped<INotaFiscalService, NotaFiscalService>();
            services.AddScoped<INotaFiscalRepository, NotaFiscalRepository>();

            services.AddScoped<IUsuarioAppService, UsuarioAppService>();
            services.AddScoped<IUsuarioService, UsuarioService>();
            services.AddScoped<IUsuarioRepository, UsuarioRepository>();

            services.AddScoped<ICidadeRepository, CidadeRepository>();
            services.AddScoped<IEstadoRepository, EstadoRepository>();
            services.AddScoped<IGenericsService, GenericsService>();
            services.AddScoped<IGenericsAppService, GenericsAppService>();

        }
    }
}
