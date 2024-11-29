using Dietcode.Core.DomainValidator;
using French.Erp.Application.Interfaces.Repository;
using French.Erp.Application.Interfaces.Services;
using French.Erp.Domain.Entities;
using System.Threading.Tasks;

namespace French.Erp.Services
{
    public class TipoDePessoaService : ITipoDePessoaService
    {
        private readonly ITipoDePessoaRepository tipoDePessoaRepository;
        private readonly ValidationResult validationResult;

        public TipoDePessoaService(ITipoDePessoaRepository tipoDePessoaRepository) 
        {
            this.tipoDePessoaRepository = tipoDePessoaRepository;
            validationResult = new ValidationResult();
        }

        public async Task<ValidationResult> Excluir(int id)
        {
            var tipoDePessoa = await tipoDePessoaRepository.ObterPorId(id);
            if (tipoDePessoa == null)
            {
                validationResult.Add("Tipo de Pessoa inexistente");
                return validationResult;
            }

            await tipoDePessoaRepository.Remover(tipoDePessoa);

            return validationResult;
        }

        public async Task<ValidationResult> Gravar(TipoDePessoa tipoDePessoa)
        {
            //validate
            if (!tipoDePessoa.IsValid())
            {
                return tipoDePessoa.ValidationResult;
            }

            //add or update
            if (tipoDePessoa.TipoDePessoaId == 0)
            {
                await tipoDePessoaRepository.Adicionar(tipoDePessoa);
            }
            else
            {
                await tipoDePessoaRepository.Atualizar(tipoDePessoa);
            }

            return validationResult;
        }
    }
}
