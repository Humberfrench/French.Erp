namespace French.Erp.Application.AutoMapper
{
    using Application.ViewModel;
    using Domain.Entities;
    using French.Erp.Domain.ObjectValue;
    using French.Erp.ViewModel.ViewModel;
    using global::AutoMapper;

    //using Domain.ObjectValue;

    public static class AutoMapperConfig
    {
        public static MapperConfiguration Config;

        public static void RegisterMappings()
        {
            Config = new MapperConfiguration(cfg =>
            {
                cfg.CreateMap<ArquivoNotaFiscal, ArquivoNotaFiscalViewModel>().ReverseMap();
                cfg.CreateMap<Cliente, ClienteViewModel>().ReverseMap().PreserveReferences();
                cfg.CreateMap<ClienteDados, ClienteDadosViewModel>().ReverseMap();
                cfg.CreateMap<ComposicaoNotaFiscal, ComposicaoNotaFiscalViewModel>().ReverseMap();
                cfg.CreateMap<Estado, EstadoViewModel>().ReverseMap();
                cfg.CreateMap<Faturamento, FaturamentoViewModel>().ReverseMap();
                cfg.CreateMap<Cidade, CidadeViewModel>().ReverseMap();
                cfg.CreateMap<NotaFiscal, NotaFiscalViewModel>().ReverseMap();
                cfg.CreateMap<Servico, ServicoViewModel>().ReverseMap();
                cfg.CreateMap<StatusNotaFiscal, StatusNotaFiscalViewModel>().ReverseMap();
                cfg.CreateMap<TributoNotaFiscal, TributoNotaFiscalViewModel>().ReverseMap();
                cfg.CreateMap<Tributo, TributoViewModel>().ReverseMap();
                cfg.CreateMap<Tarefa, TarefaViewModel>().ReverseMap();
                cfg.CreateMap<TarefaItem, TarefaItemViewModel>().ReverseMap();
                cfg.CreateMap<TipoDeCliente, TipoDeClienteViewModel>().ReverseMap();
                cfg.CreateMap<TipoDePessoa, TipoDePessoaViewModel>().ReverseMap();
                cfg.CreateMap<Usuario, UsuarioViewModel>().ReverseMap();
            }
            );
        }
    }
}
