using Dietcode.Core.DomainValidator;
using Dietcode.Core.Lib;
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

        public async Task<ValidationResult<bool>> Excluir(int id)
        {
            var validationResult = new ValidationResult<bool>();
            var cliente = await clienteRepository.ObterPorId(id);
            if (cliente == null)
            {
                validationResult.Add("Cliente inexistente");
                return validationResult;
            }

            await clienteRepository.Remover(cliente);

            return validationResult;
        }

        public async Task<ValidationResult> Gravar(ClienteDto clienteDados)
        {

            //add or update
            if (clienteDados.ClienteId == 0)
            {
                var cliente = new Cliente();

                AtualizaCliente(clienteDados, ref cliente);

                //validate
                if (!cliente.IsValid())
                {
                    return cliente.ValidationResult;
                }

                await clienteRepository.Adicionar(cliente);
            }
            else
            {
                var cliente = await clienteRepository.ObterPorId(clienteDados.ClienteId);

                AtualizaCliente(clienteDados, ref cliente);

                //validate
                if (!cliente.IsValid())
                {
                    return cliente.ValidationResult;
                }
                
                await clienteRepository.Atualizar(cliente);
            }

            return validationResult;
        }

        void AtualizaCliente(ClienteDto clienteDados, ref Cliente cliente)
        {
            cliente.Nome = clienteDados.Nome;
            cliente.RazaoSocial = clienteDados.RazaoSocial;
            cliente.Documento = clienteDados.Documento;
            cliente.TipoDeClienteId = clienteDados.TipoDeClienteId;
            cliente.TipoDePessoaId = clienteDados.TipoDePessoaId;
            cliente.Telefone = clienteDados.Telefone;
            cliente.Contato = clienteDados.Contato;
            cliente.Email = clienteDados.Email;
            cliente.InscricaoEstadual = clienteDados.InscricaoEstadual;
            cliente.CadastroMunicipal = clienteDados.CadastroMunicipal;
            cliente.Endereco = clienteDados.Endereco;
            cliente.Numero = clienteDados.Numero;
            cliente.Complemento = clienteDados.Complemento;
            cliente.Bairro = clienteDados.Bairro;
            cliente.Cep = clienteDados.Cep;
            cliente.UsuarioId = clienteDados.UsuarioId;
            cliente.EstadoId = clienteDados.EstadoId;
            cliente.CidadeId = clienteDados.CidadeId;
        }

        public async Task<IEnumerable<ClienteDto>> ObterTodos()
        {
            var clientes = await clienteRepository.ObterTodos();

            return clientes.ConvertObjects<List<ClienteDto>>();
        }

        public async Task<ClienteDto> ObterPorId(int id)
        {
            var tipoDeClientes = await clienteRepository.ObterPorId(id);

            return tipoDeClientes.ConvertObjects<ClienteDto>();
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
