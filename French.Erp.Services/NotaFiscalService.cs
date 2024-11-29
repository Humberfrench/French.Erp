using Dietcode.Core.DomainValidator;
using French.Erp.Application.Interfaces.Repository;
using French.Erp.Application.Interfaces.Services;
using French.Erp.Domain.Entities;
using System.Threading.Tasks;

namespace French.Erp.Services
{
    public class NotaFiscalService :  INotaFiscalService
    {
        private readonly INotaFiscalRepository repositoryNotaFiscal;
        private readonly ValidationResult validationResult;

        public NotaFiscalService(INotaFiscalRepository repositoryNotaFiscal) 
        {
            this.repositoryNotaFiscal = repositoryNotaFiscal;
            validationResult = new ValidationResult();
        }

        public async Task<ValidationResult> Excluir(int id)
        {
            var tipoDePessoa = await repositoryNotaFiscal.ObterPorId(id);
            if (tipoDePessoa == null)
            {
                validationResult.Add(" da Nota Fiscal inexistente");
                return validationResult;
            }

            await repositoryNotaFiscal.Remover(tipoDePessoa);

            return validationResult;
        }

        public async Task<ValidationResult> Gravar(NotaFiscal notaFiscal)
        {
            ////validate
            //if (!notaFiscal.IsValid())
            //{
            //    return notaFiscal.ValidationResult;
            //}

            //add or update
            if (notaFiscal.NotaFiscalId == 0)
            {
                await repositoryNotaFiscal.Adicionar(notaFiscal);
            }
            else
            {
                await repositoryNotaFiscal.Atualizar(notaFiscal);
            }

            return validationResult;
        }
    }
}
