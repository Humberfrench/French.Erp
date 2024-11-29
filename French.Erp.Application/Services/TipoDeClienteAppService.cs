using Dietcode.Core.DomainValidator;
using French.Erp.Domain.Entities;
using French.Erp.Domain.Interfaces.Repository;
using French.Erp.Domain.Interfaces.Services;
using French.Erp.ViewModel.Interface;
using French.Erp.ViewModel.ViewModel;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace French.Erp.Application.Services
{
    public class TipoDeClienteAppService : BaseServiceApp<TipoDeClienteViewModel>, ITipoDeClienteAppService
    {
        private readonly ITipoDeClienteService service;
        private ValidationResult<TipoDeClienteViewModel> validationResult;

        public TipoDeClienteAppService(ITipoDeClienteService service, IUnitOfWork uow) : base(uow)
        {
            this.service = service;
            validationResult = new ValidationResult<TipoDeClienteViewModel>();
        }

        public async Task<ValidationResult<TipoDeClienteViewModel>> Gravar(TipoDeClienteViewModel tipoDeCliente)
        {
            BeginTransaction();
            var dadoIncluir = Mapper.Map<TipoDeCliente>(tipoDeCliente);
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
            validationResult.Retorno = Mapper.Map<TipoDeClienteViewModel>(retorno.Retorno);

            retorno.Erros.ToList().ForEach(e => validationResult.Add(e));
            return validationResult;


        }

        public async Task<ValidationResult<TipoDeClienteViewModel>> Excluir(int id)
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
            validationResult.Retorno = Mapper.Map<TipoDeClienteViewModel>(retorno.Retorno);

            retorno.Erros.ToList().ForEach(e => validationResult.Add(e));
            return validationResult;


        }

        public async Task<TipoDeClienteViewModel> ObterPorId(int id)
        {
            var tipoDeCliente = await service.ObterPorId(id);
            var retorno = Mapper.Map<TipoDeClienteViewModel>(tipoDeCliente);
            return retorno;
        }

        public async Task<IEnumerable<TipoDeClienteViewModel>> ObterTodos()
        {
            var tipoDeCliente = await service.ObterTodos();
            var retorno = Mapper.Map<IEnumerable<TipoDeClienteViewModel>>(tipoDeCliente);
            return retorno;

        }

    }
}
