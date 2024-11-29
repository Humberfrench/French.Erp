using Dietcode.Core.DomainValidator;
using French.Erp.Application.ViewModel;
using French.Erp.Domain.Entities;
using French.Erp.Domain.Interfaces.Repository;
using French.Erp.Domain.Interfaces.Services;
using French.Erp.ViewModel.Interface;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace French.Erp.Application.Services
{
    public class ServicoAppService : BaseServiceApp<ServicoViewModel>, IServicoAppService
    {
        private readonly IServicoService service;
        private ValidationResult<ServicoViewModel> validationResult;

        public ServicoAppService(IServicoService service, IUnitOfWork uow) : base(uow)
        {
            this.service = service;
            validationResult = new ValidationResult<ServicoViewModel>();
        }

        public async Task<ValidationResult<ServicoViewModel>> Gravar(ServicoViewModel servico)
        {
            BeginTransaction();
            var dadoIncluir = Mapper.Map<Servico>(servico);
            var retorno = await service.Gravar(dadoIncluir);
            if (retorno.Valid)
            {
                //commit transaction
                await Commit();
                //commit error
                if (!baseValidationResult.Valid)
                {
                    return baseValidationResult;
                }
            }
            validationResult.Retorno = Mapper.Map<ServicoViewModel>(retorno.Retorno);

            retorno.Erros.ToList().ForEach(e => validationResult.Add(e));
            return validationResult;


        }

        public async Task<ValidationResult<ServicoViewModel>> Excluir(int id)
        {
            BeginTransaction();
            var retorno = await service.Excluir(id);
            if (retorno.Valid)
            {
                //commit transaction
                await Commit();
                //commit error
                if (!baseValidationResult.Valid)
                {
                    return baseValidationResult;
                }
            }
            validationResult.Retorno = Mapper.Map<ServicoViewModel>(retorno.Retorno);

            retorno.Erros.ToList().ForEach(e => validationResult.Add(e));
            return validationResult;


        }

        public async Task<ServicoViewModel> ObterPorId(int id)
        {
            var servico = await service.ObterPorId(id);
            var retorno = Mapper.Map<ServicoViewModel>(servico);
            return retorno;
        }

        public async Task<IEnumerable<ServicoViewModel>> ObterTodos()
        {
            var servico = await service.ObterTodos();
            var retorno = Mapper.Map<IEnumerable<ServicoViewModel>>(servico);
            return retorno;

        }

    }
}
