using Dietcode.Core.DomainValidator;
using French.Erp.Application.DataObject;
using French.Erp.Application.Interfaces.Repository;
using French.Erp.Application.Interfaces.Services;
using French.Erp.Domain.Entities;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace French.Erp.Services
{
    public class ClienteService : IClienteService
    {

        private readonly IClienteRepository clienteRepository;
        private readonly ValidationResult validationResult;

        public ClienteService(IClienteRepository clienteRepository)
        {
            this.clienteRepository = clienteRepository;
            validationResult = new ValidationResult();
        }

        public async Task<ValidationResult> Excluir(int id)
        {
            var cliente = await clienteRepository.ObterPorId(id);
            if (cliente == null)
            {
                validationResult.Add("Cliente inexistente");
                return validationResult;
            }

            await clienteRepository.Remover(cliente);

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
                await clienteRepository.Adicionar(cliente);
            }
            else
            {
                await clienteRepository.Atualizar(cliente);
            }

            return validationResult;
        }

        public async Task<IEnumerable<Cliente>> ObterTodos()
        {
            return await clienteRepository.ObterTodos();
        }
        public async Task<IEnumerable<ClienteDadosDto>> ObterTodosParaCombo()
        {
            var clientes = (await clienteRepository.ObterTodos()).ToList();

            var retorno = clientes.Select(c => new ClienteDadosDto()
            {
                ClienteId = c.ClienteId,
                Nome = c.Nome,
                RazaoSocial = c.RazaoSocial
            });

            return retorno;
        }
    }
}
