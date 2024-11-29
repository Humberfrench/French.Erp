using Dietcode.Core.DomainValidator;
using Dietcode.Core.Lib;
using French.Erp.Application.DataObject;
using French.Erp.Application.Interfaces.Repository;
using French.Erp.Application.Interfaces.Services;
using French.Erp.Domain.Entities;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace French.Erp.Services
{
    public class ServicoService :  IServicoService
    {
        private readonly IServicoRepository servicoRepository;
        private readonly ValidationResult validationResult;

        public ServicoService(IServicoRepository servicoRepository) 
        {
            this.servicoRepository = servicoRepository;
            validationResult = new ValidationResult();
        }

        public async Task<ValidationResult> Excluir(int id)
        {
            var servico = await servicoRepository.ObterPorId(id);

            if (servico == null)
            {
                validationResult.Add("Serviço inexistente");
                return validationResult;
            }

            await servicoRepository.Remover(servico);

            return validationResult;
        }

        public async Task<ValidationResult> Gravar(ServicoDto servicoDados)
        {
            //add or update
            if (servicoDados.ServicoId == 0)
            {
                var servico = new Servico()
                {
                    Descricao = servicoDados.Descricao,
                    Nome = servicoDados.Nome
                };

                //validate
                if (!servico.IsValid())
                {
                    return servico.ValidationResult;
                }

                await servicoRepository.Adicionar(servico);
            }
            else
            {
                var servico = await servicoRepository.ObterPorId(servicoDados.ServicoId);
                servico.Descricao = servicoDados.Descricao;
                servico.Nome = servicoDados.Nome;

                //validate
                if (!servico.IsValid())
                {
                    return servico.ValidationResult;
                }

                await servicoRepository.Atualizar(servico);
            }

            return validationResult;
        }

        public async Task<ServicoDto> ObterPorId(int id)
        {
            var clientes = await servicoRepository.ObterPorId(id);

            return clientes.ConvertObjects<ServicoDto>();
        }

        public async Task<List<ServicoDto>> ObterTodos()
        {
            var clientes = await servicoRepository.ObterTodos();

            return clientes.ConvertObjects<List<ServicoDto>>();
        }
    }
}
