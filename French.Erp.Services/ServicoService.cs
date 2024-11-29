using Dietcode.Core.DomainValidator;
using French.Erp.Application.Interfaces.Repository;
using French.Erp.Application.Interfaces.Services;
using French.Erp.Domain.Entities;
using System.Threading.Tasks;

namespace French.Erp.Services
{
    public class ServicoService :  IServicoService
    {
        private readonly IServicoRepository repositoryServico;
        private readonly ValidationResult validationResult;

        public ServicoService(IServicoRepository repositoryServico) 
        {
            this.repositoryServico = repositoryServico;
            validationResult = new ValidationResult();
        }

        public async Task<ValidationResult> Excluir(int id)
        {
            var servico = await repositoryServico.ObterPorId(id);

            if (servico == null)
            {
                validationResult.Add("Serviço inexistente");
                return validationResult;
            }

            await repositoryServico.Remover(servico);

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
                await repositoryServico.Adicionar(servico);
            }
            else
            {
                await repositoryServico.Atualizar(servico);
            }

            return validationResult;
        }
    }
}
