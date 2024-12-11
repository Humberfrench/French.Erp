using Dietcode.Core.DomainValidator;
using French.Erp.Domain.Specifications.Lead;

namespace French.Erp.Domain.Validations.Lead
{
    public class LeadEstaConsistente : Validator<Entities.Lead>
    {
        public LeadEstaConsistente()
        {

            var requisitoMinimoPreenchido = new RequisitoMinimoPreenchido();
            var tipoDeClientePreenchido = new TipoDeClientePreenchido();
            var tipoDePessoaPreenchido = new TipoDePessoaPreenchido();

            //implementação regras
            base.AdicionarRegra(nameof(requisitoMinimoPreenchido), new Rule<Entities.Lead>(requisitoMinimoPreenchido, "Preencher ao menos um nome de contato, email ou telefone."));
            base.AdicionarRegra(nameof(tipoDeClientePreenchido), new Rule<Entities.Lead>(tipoDeClientePreenchido, "Preencher o Tipo de Cliente."));
            base.AdicionarRegra(nameof(tipoDePessoaPreenchido), new Rule<Entities.Lead>(tipoDePessoaPreenchido, "Preencher o Tipo de Pessoa do Cliente."));
        }

    }
}
