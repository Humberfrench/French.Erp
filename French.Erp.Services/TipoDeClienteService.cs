using Dietcode.Core.DomainValidator;
using French.Erp.Domain.Entities;
using French.Erp.Domain.Interfaces.Repository;
using French.Erp.Domain.Interfaces.Services;
using System.Threading.Tasks;

namespace French.Erp.Services
{
    public class TipoDeClienteService : BaseService<TipoDeCliente>, ITipoDeClienteService
    {
        private readonly ITipoDeClienteRepository repository;
        private readonly ValidationResult validationResult;

        public TipoDeClienteService(IBaseRepository<TipoDeCliente> baseRepository,
                                    ITipoDeClienteRepository repository) : base(baseRepository)
        {
            this.repository = repository;
            validationResult = new ValidationResult();
        }

        public async Task<ValidationResult> Excluir(int id)
        {
            var tipoDeCliente = await ObterPorId(id);
            if (tipoDeCliente == null)
            {
                validationResult.Add("Tipo de Cliente inexistente");
                return validationResult;
            }

            await base.Remover(tipoDeCliente);

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
                await base.Adicionar(tipoDeCliente);
            }
            else
            {
                await base.Atualizar(tipoDeCliente);
            }

            return validationResult;
        }
    }
}
