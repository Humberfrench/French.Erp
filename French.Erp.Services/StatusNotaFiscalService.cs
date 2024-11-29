using Dietcode.Core.DomainValidator;
using French.Erp.Application.Interfaces.Repository;
using French.Erp.Application.Interfaces.Services;
using French.Erp.Domain.Entities;
using System.Threading.Tasks;

namespace French.Erp.Services
{
    public class StatusNotaFiscalService :  IStatusNotaFiscalService
    {
        private readonly IStatusNotaFiscalRepository repositoryStatusNotaFiscal;
        private readonly ValidationResult validationResult;

        public StatusNotaFiscalService(IStatusNotaFiscalRepository repositoryStatusNotaFiscal) 
        {
            this.repositoryStatusNotaFiscal = repositoryStatusNotaFiscal;
            validationResult = new ValidationResult();
        }

        public async Task<ValidationResult> Excluir(int id)
        {
            var tipoDePessoa = await repositoryStatusNotaFiscal.ObterPorId(id);
            if (tipoDePessoa == null)
            {
                validationResult.Add("Status da Nota Fiscal inexistente");
                return validationResult;
            }

            await repositoryStatusNotaFiscal.Remover(tipoDePessoa);

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
                await repositoryStatusNotaFiscal.Adicionar(statusNotaFiscal);
            }
            else
            {
                await repositoryStatusNotaFiscal.Atualizar(statusNotaFiscal);
            }

            return validationResult;
        }
    }
}
