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
    public class TipoDePessoaService : ITipoDePessoaService
    {
        private readonly ITipoDePessoaRepository tipoDePessoaRepository;

        public TipoDePessoaService(ITipoDePessoaRepository tipoDePessoaRepository)
        {
            this.tipoDePessoaRepository = tipoDePessoaRepository;
        }

        public async Task<ValidationResult> Excluir(byte id)
        {
            var validationResult = new ValidationResult();
            var tipoDePessoa = await tipoDePessoaRepository.ObterPorId(id);
            if (tipoDePessoa == null)
            {
                validationResult.Add("Tipo de Pessoa inexistente");
                return validationResult;
            }

            await tipoDePessoaRepository.Remover(tipoDePessoa);

            return validationResult;
        }

        public async Task<ValidationResult> Gravar(TipoDePessoaDto tipoDePessoaDados)
        {
            var validationResult = new ValidationResult();
            //add or update
            if (tipoDePessoaDados.TipoDePessoaId == 0)
            {
                var tipoDePessoa = new TipoDePessoa()
                {
                    Descricao = tipoDePessoaDados.Descricao
                };

                //validate
                if (!tipoDePessoa.IsValid())
                {
                    return tipoDePessoa.ValidationResult;
                }

                await tipoDePessoaRepository.Adicionar(tipoDePessoa);
            }
            else
            {
                var tipoDePessoa = await tipoDePessoaRepository.ObterPorId(tipoDePessoaDados.TipoDePessoaId);
                tipoDePessoa.Descricao = tipoDePessoaDados.Descricao;

                //validate
                if (!tipoDePessoa.IsValid())
                {
                    return tipoDePessoa.ValidationResult;
                }

                await tipoDePessoaRepository.Atualizar(tipoDePessoa);
            }

            return validationResult;
        }

        public async Task<IEnumerable<TipoDePessoaDto>> ObterTodos()
        {
            var tipoDeClientes = await tipoDePessoaRepository.ObterTodos();

            return tipoDeClientes.ConvertObjects<List<TipoDePessoaDto>>();
        }
        public async Task<TipoDePessoaDto> ObterPorId(byte id)
        {
            var tipoDeClientes = await tipoDePessoaRepository.ObterPorId(id);

            return tipoDeClientes.ConvertObjects<TipoDePessoaDto>();
        }

    }
}
