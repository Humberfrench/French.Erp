using Dietcode.Core.DomainValidator;
using French.Erp.Domain.Specifications;

namespace French.Erp.Domain.Validations
{
    public class LeadEstaConsistente : Validator<Entities.Lead>
    {
        public LeadEstaConsistente()
        {

            var requisitoMinimoPreenchido = new RequisitoMinimoPreenchido<Entities.Lead>(
                lead => lead.Contato,
                lead => lead.Telefone,
                lead => lead.Email
            );
            var tipoDeClientePreenchido = new PropriedadeIntMaiorQueZero<Entities.Lead>(c => c.TipoDeClienteId);
            var tipoDePessoaPreenchido = new PropriedadeIntMaiorQueZero<Entities.Lead>(c => c.TipoDePessoaId);

            //implementação regras
            base.AdicionarRegra(nameof(requisitoMinimoPreenchido), new Rule<Entities.Lead>(requisitoMinimoPreenchido, "Preencher ao menos um nome de contato, email ou telefone."));
            base.AdicionarRegra(nameof(tipoDeClientePreenchido), new Rule<Entities.Lead>(tipoDeClientePreenchido, "Preencher o Tipo de Cliente."));
            base.AdicionarRegra(nameof(tipoDePessoaPreenchido), new Rule<Entities.Lead>(tipoDePessoaPreenchido, "Preencher o Tipo de Pessoa do Cliente."));
        }

    }
}
