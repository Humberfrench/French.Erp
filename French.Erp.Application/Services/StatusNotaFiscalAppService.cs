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
    public class StatusNotaFiscalAppService : BaseServiceApp<StatusNotaFiscalViewModel>, IStatusNotaFiscalAppService
    {
        private readonly IStatusNotaFiscalService service;
        private ValidationResult<StatusNotaFiscalViewModel> validationResult;

        public StatusNotaFiscalAppService(IStatusNotaFiscalService service, IUnitOfWork uow) : base(uow)
        {
            this.service = service;
            validationResult = new ValidationResult<StatusNotaFiscalViewModel>();
        }

        public async Task<ValidationResult<StatusNotaFiscalViewModel>> Gravar(StatusNotaFiscalViewModel statusNotaFiscal)
        {
            BeginTransaction();
            var dadoIncluir = Mapper.Map<StatusNotaFiscal>(statusNotaFiscal);
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
            validationResult.Retorno = Mapper.Map<StatusNotaFiscalViewModel>(retorno.Retorno);

            retorno.Erros.ToList().ForEach(e => validationResult.Add(e));
            return validationResult;


        }

        public async Task<ValidationResult<StatusNotaFiscalViewModel>> Excluir(int id)
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
            validationResult.Retorno = Mapper.Map<StatusNotaFiscalViewModel>(retorno.Retorno);

            retorno.Erros.ToList().ForEach(e => validationResult.Add(e));
            return validationResult;


        }

        public async Task<StatusNotaFiscalViewModel> ObterPorId(int id)
        {
            var statusNotaFiscal = await service.ObterPorId(id);
            var retorno = Mapper.Map<StatusNotaFiscalViewModel>(statusNotaFiscal);
            return retorno;
        }

        public async Task<IEnumerable<StatusNotaFiscalViewModel>> ObterTodos()
        {
            var statusNotaFiscal = await service.ObterTodos();
            var retorno = Mapper.Map<IEnumerable<StatusNotaFiscalViewModel>>(statusNotaFiscal);
            return retorno;

        }

    }
}
