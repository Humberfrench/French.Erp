using Dietcode.Core.DomainValidator;
using French.Erp.Domain.Entities;
using French.Erp.Domain.Interfaces.Repository;
using French.Erp.Domain.Interfaces.Services;
using System.Threading.Tasks;

namespace French.Erp.Services
{
    public class TributoService : BaseService<Tributo>, ITributoService
    {
        private readonly ITributoRepository repository;
        private readonly ValidationResult validationResult;

        public TributoService(IBaseRepository<Tributo> baseRepository,
                                    ITributoRepository repository) : base(baseRepository)
        {
            this.repository = repository;
            validationResult = new ValidationResult();
        }

        public async Task<ValidationResult> Excluir(int id)
        {
            var tributo = await ObterPorId(id);
            if (tributo == null)
            {
                validationResult.Add("Tributo inexistente");
                return validationResult;
            }

            await base.Remover(tributo);

            return validationResult;
        }

        public async Task<ValidationResult> Gravar(Tributo tributo)
        {
            //validate
            if (!tributo.IsValid())
            {
                return tributo.ValidationResult;
            }

            //add or update
            if (tributo.TributoId == 0)
            {
                await base.Adicionar(tributo);
            }
            else
            {
                await base.Atualizar(tributo);
            }

            return validationResult;
        }
    }
}
