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
    public class TributoAppService : BaseServiceApp<TributoViewModel>, ITributoAppService
    {
        private readonly ITributoService service;
        private ValidationResult<TributoViewModel> validationResult;

        public TributoAppService(ITributoService service, IUnitOfWork uow) : base(uow)
        {
            this.service = service;
            validationResult = new ValidationResult<TributoViewModel>();
        }

        public async Task<ValidationResult<TributoViewModel>> Gravar(TributoViewModel tributo)
        {
            BeginTransaction();
            var dadoIncluir = Mapper.Map<Tributo>(tributo);
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
            validationResult.Retorno = Mapper.Map<TributoViewModel>(retorno.Retorno);

            retorno.Erros.ToList().ForEach(e => validationResult.Add(e));
            return validationResult;

        }

        public async Task<ValidationResult<TributoViewModel>> Excluir(int id)
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
            validationResult.Retorno = Mapper.Map<TributoViewModel>(retorno.Retorno);

            retorno.Erros.ToList().ForEach(e => validationResult.Add(e));
            return validationResult;

        }

        public async Task<TributoViewModel> ObterPorId(int id)
        {
            var tributo = await service.ObterPorId(id);
            var retorno = Mapper.Map<TributoViewModel>(tributo);
            return retorno;
        }

        public async Task<IEnumerable<TributoViewModel>> ObterTodos()
        {
            var tributo = await service.ObterTodos();
            var retorno = Mapper.Map<IEnumerable<TributoViewModel>>(tributo);
            return retorno;

        }

    }
}
