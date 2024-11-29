using Dietcode.Core.DomainValidator;
using French.Erp.Application.Interfaces.Repository;
using French.Erp.Application.Interfaces.Services;
using French.Erp.Domain.Entities;
using System.Threading.Tasks;

namespace French.Erp.Services
{
    public class TipoDeClienteService :  ITipoDeClienteService
    {
        private readonly ValidationResult validationResult;
        private readonly ITipoDeClienteRepository repositoryTipoDeCliente;

        public TipoDeClienteService(ITipoDeClienteRepository repositoryTipoDeCliente) 
        {
            this.repositoryTipoDeCliente = repositoryTipoDeCliente;
            validationResult = new ValidationResult();
        }

        public async Task<ValidationResult> Excluir(int id)
        {
            var tipoDeCliente = await repositoryTipoDeCliente.ObterPorId(id);
            if (tipoDeCliente == null)
            {
                validationResult.Add("Tipo de Cliente inexistente");
                return validationResult;
            }

            await repositoryTipoDeCliente.Remover(tipoDeCliente);

            return validationResult;
        }

        public async Task<ValidationResult> Gravar(TipoDeCliente tipoDeCliente)
        {
            //validate
            if (!tipoDeCliente.IsValid())
            {
                return tipoDeCliente.ValidationResult;
            }

            //add or update
            if (tipoDeCliente.TipoDeClienteId == 0)
            {
                await repositoryTipoDeCliente.Adicionar(tipoDeCliente);
            }
            else
            {
                await repositoryTipoDeCliente.Atualizar(tipoDeCliente);
            }

            return validationResult;
        }
    }
}
