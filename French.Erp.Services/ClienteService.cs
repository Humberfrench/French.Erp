using Dietcode.Core.DomainValidator;
using French.Erp.Domain.Entities;
using French.Erp.Domain.Interfaces.Repository;
using French.Erp.Domain.Interfaces.Services;
using French.Erp.Domain.ObjectValue;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace French.Erp.Services
{
    public class ClienteService : BaseService<Cliente>, IClienteService
    {
        private readonly IClienteRepository repository;
        private readonly ValidationResult validationResult;

        public ClienteService(IBaseRepository<Cliente> baseRepository,
                              IClienteRepository repository) : base(baseRepository)
        {
            this.repository = repository;
            validationResult = new ValidationResult();
        }

        public async Task<ValidationResult> Excluir(int id)
        {
            var cliente = await ObterPorId(id);
            if (cliente == null)
            {
                validationResult.Add("Cliente inexistente");
                return validationResult;
            }

            await base.Remover(cliente);

            return validationResult;
        }

        public async Task<ValidationResult> Gravar(Cliente cliente)
        {
            //validate
            if (!cliente.IsValid())
            {
                return cliente.ValidationResult;
            }

            //add or update
            if (cliente.ClienteId == 0)
            {
                await base.Adicionar(cliente);
            }
            else
            {
                await base.Atualizar(cliente);
            }

            return validationResult;
        }

        public async new Task<IEnumerable<Cliente>> ObterTodos()
        {
            return await repository.ObterTodos();
        }
        public async Task<IEnumerable<ClienteDados>> ObterTodosParaCombo()
        {
            var clientes = (await base.ObterTodos()).ToList();

            var retorno = clientes.Select(c => new ClienteDados()
            {
                ClienteId = c.ClienteId,
                Nome = c.Nome,
                RazaoSocial = c.RazaoSocial
            });

            return retorno;
        }
    }
}
