using Dietcode.Core.DomainValidator;
using French.Erp.Domain.Entities;
using French.Erp.Domain.Interfaces.Repository;
using French.Erp.Domain.Interfaces.Services;
using System.Threading.Tasks;

namespace French.Erp.Services
{
    public class ServicoService : BaseService<Servico>, IServicoService
    {
        private readonly IServicoRepository repository;
        private readonly ValidationResult validationResult;

        public ServicoService(IBaseRepository<Servico> baseRepository,
                                    IServicoRepository repository) : base(baseRepository)
        {
            this.repository = repository;
            validationResult = new ValidationResult();
        }

        public async Task<ValidationResult> Excluir(int id)
        {
            var servico = await ObterPorId(id);

            if (servico == null)
            {
                validationResult.Add("Serviço inexistente");
                return validationResult;
            }

            await base.Remover(servico);

            return validationResult;
        }

        public async Task<ValidationResult> Gravar(Servico servico)
        {
            //validate
            if (!servico.IsValid())
            {
                return servico.ValidationResult;
            }

            //add or update
            if (servico.ServicoId == 0)
            {
                await base.Adicionar(servico);
            }
            else
            {
                await base.Atualizar(servico);
            }

            return validationResult;
        }
    }
}
