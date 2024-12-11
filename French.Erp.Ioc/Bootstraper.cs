﻿using Microsoft.Extensions.DependencyInjection;

namespace French.Erp.Ioc
{
    using French.Erp.Application.Interfaces.Repository;
    using French.Erp.Application.Interfaces.Services;
    using French.Erp.Repository.Support;
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

            services.AddScoped<ITarefaService, TarefaService>();
            services.AddScoped<ITarefaRepository, TarefaRepository>();

            services.AddScoped<ITipoDePessoaRepository, TipoDePessoaRepository>();
            services.AddScoped<ITipoDePessoaService, TipoDePessoaService>();

            services.AddScoped<ITipoDeClienteRepository, TipoDeClienteRepository>();
            services.AddScoped<ITipoDeClienteService, TipoDeClienteService>();

            services.AddScoped<IStatusNotaFiscalService, StatusNotaFiscalService>();
            services.AddScoped<IStatusNotaFiscalRepository, StatusNotaFiscalRepository>();

            services.AddScoped<IServicoService, ServicoService>();
            services.AddScoped<IServicoRepository, ServicoRepository>();

            services.AddScoped<ITarefaService, TarefaService>();
            services.AddScoped<ITarefaRepository, TarefaRepository>();
            services.AddScoped<ITarefaItemRepository, TarefaItemRepository>();

            services.AddScoped<IClienteService, ClienteService>();
            services.AddScoped<IClienteRepository, ClienteRepository>();

            //services.AddScoped<IClienteAppService, ClienteAppService>();
            services.AddScoped<INotaFiscalService, NotaFiscalService>();
            services.AddScoped<INotaFiscalRepository, NotaFiscalRepository>();

            services.AddScoped<IUsuarioService, UsuarioService>();
            services.AddScoped<IUsuarioRepository, UsuarioRepository>();

            services.AddScoped<ILeadService, LeadService>();
            services.AddScoped<ILeadRepository, LeadRepository>();

            services.AddScoped<ICidadeRepository, CidadeRepository>();
            services.AddScoped<IEstadoRepository, EstadoRepository>();
            services.AddScoped<IGenericsService, GenericsService>();

        }
    }
}
