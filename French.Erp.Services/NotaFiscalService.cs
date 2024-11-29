using Dietcode.Core.DomainValidator;
using French.Erp.Domain.Entities;
using French.Erp.Domain.Interfaces.Repository;
using French.Erp.Domain.Interfaces.Services;
using System.Threading.Tasks;

namespace French.Erp.Services
{
    public class NotaFiscalService : BaseService<NotaFiscal>, INotaFiscalService
    {
        private readonly INotaFiscalRepository repository;
        private readonly ValidationResult validationResult;

        public NotaFiscalService(IBaseRepository<NotaFiscal> baseRepository,
                                 INotaFiscalRepository repository) : base(baseRepository)
        {
            this.repository = repository;
            validationResult = new ValidationResult();
        }

        public async Task<ValidationResult> Excluir(int id)
        {
            var tipoDePessoa = await ObterPorId(id);
            if (tipoDePessoa == null)
            {
                validationResult.Add(" da Nota Fiscal inexistente");
                return validationResult;
            }

            await base.Remover(tipoDePessoa);

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
                await base.Adicionar(notaFiscal);
            }
            else
            {
                await base.Atualizar(notaFiscal);
            }

            return validationResult;
        }
    }
}
