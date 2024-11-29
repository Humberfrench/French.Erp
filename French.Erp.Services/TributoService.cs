using Dietcode.Core.DomainValidator;
using French.Erp.Application.Interfaces.Repository;
using French.Erp.Application.Interfaces.Services;
using French.Erp.Domain.Entities;
using System.Threading.Tasks;

namespace French.Erp.Services
{
    public class TributoService : ITributoService
    {
        private readonly ITributoRepository repositoryTributo;
        private readonly ValidationResult validationResult;

        public TributoService( ITributoRepository repositoryTributo) 
        {
            this.repositoryTributo = repositoryTributo;
            validationResult = new ValidationResult();
        }

        public async Task<ValidationResult> Excluir(int id)
        {
            var tributo = await repositoryTributo.ObterPorId(id);
            if (tributo == null)
            {
                validationResult.Add("Tributo inexistente");
                return validationResult;
            }

            await repositoryTributo.Remover(tributo);

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
                await repositoryTributo.Adicionar(tributo);
            }
            else
            {
                await repositoryTributo.Atualizar(tributo);
            }

            return validationResult;
        }
    }
}
