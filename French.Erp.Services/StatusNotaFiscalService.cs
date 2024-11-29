using Dietcode.Core.DomainValidator;
using French.Erp.Domain.Entities;
using French.Erp.Domain.Interfaces.Repository;
using French.Erp.Domain.Interfaces.Services;
using System.Threading.Tasks;

namespace French.Erp.Services
{
    public class StatusNotaFiscalService : BaseService<StatusNotaFiscal>, IStatusNotaFiscalService
    {
        private readonly IStatusNotaFiscalRepository repository;
        private readonly ValidationResult validationResult;

        public StatusNotaFiscalService(IBaseRepository<StatusNotaFiscal> baseRepository,
                                       IStatusNotaFiscalRepository repository) : base(baseRepository)
        {
            this.repository = repository;
            validationResult = new ValidationResult();
        }

        public async Task<ValidationResult> Excluir(int id)
        {
            var tipoDePessoa = await ObterPorId(id);
            if (tipoDePessoa == null)
            {
                validationResult.Add("Status da Nota Fiscal inexistente");
                return validationResult;
            }

            await base.Remover(tipoDePessoa);

            return validationResult;
        }

        public async Task<ValidationResult> Gravar(StatusNotaFiscal statusNotaFiscal)
        {
            //validate
            if (!statusNotaFiscal.IsValid())
            {
                return statusNotaFiscal.ValidationResult;
            }

            //add or update
            if (statusNotaFiscal.StatusNotaFiscalId == 0)
            {
                await base.Adicionar(statusNotaFiscal);
            }
            else
            {
                await base.Atualizar(statusNotaFiscal);
            }

            return validationResult;
        }
    }
}
