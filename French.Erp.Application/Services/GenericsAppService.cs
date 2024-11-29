using French.Erp.Application.ViewModel;
using French.Erp.Domain.Interfaces.Repository;
using French.Erp.Domain.Interfaces.Services;
using French.Erp.ViewModel.Interface;
using French.Erp.ViewModel.ViewModel;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace French.Erp.Application.Services
{
    //TODO: Segregar aqui
    public class GenericsAppService : BaseServiceApp<EmptyClass>, IGenericsAppService
    {
        private readonly IGenericsService service;

        public GenericsAppService(IGenericsService service, IUnitOfWork uow) : base(uow)
        {
            this.service = service;

        }
        public async Task<IEnumerable<EstadoViewModel>> ObterEstados()
        {
            var dados = await service.ObterEstados();
            var retorno = Mapper.Map<IEnumerable<EstadoViewModel>>(dados);
            return retorno;
        }
        public async Task<IEnumerable<CidadeViewModel>> ObterCidades(int uf)
        {
            var dados = await service.ObterCidades(uf);
            var retorno = Mapper.Map<IEnumerable<CidadeViewModel>>(dados);
            return retorno;
        }

    }
}
