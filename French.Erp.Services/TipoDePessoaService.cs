using Dietcode.Core.DomainValidator;
using French.Erp.Domain.Entities;
using French.Erp.Domain.Interfaces.Repository;
using French.Erp.Domain.Interfaces.Services;
using System.Threading.Tasks;

namespace French.Erp.Services
{
    public class TipoDePessoaService : BaseService<TipoDePessoa>, ITipoDePessoaService
    {
        private readonly ITipoDePessoaRepository repository;
        private readonly ValidationResult validationResult;

        public TipoDePessoaService(IBaseRepository<TipoDePessoa> baseRepository,
                                    ITipoDePessoaRepository repository) : base(baseRepository)
        {
            this.repository = repository;
            validationResult = new ValidationResult();
        }

        public async Task<ValidationResult> Excluir(int id)
        {
            var tipoDePessoa = await ObterPorId(id);
            if (tipoDePessoa == null)
            {
                validationResult.Add("Tipo de Pessoa inexistente");
                return validationResult;
            }

            await base.Remover(tipoDePessoa);

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
                await base.Adicionar(tipoDePessoa);
            }
            else
            {
                await base.Atualizar(tipoDePessoa);
            }

            return validationResult;
        }
    }
}
