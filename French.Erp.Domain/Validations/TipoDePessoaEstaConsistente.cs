using Dietcode.Core.DomainValidator;
using French.Erp.Domain.Entities;
using French.Erp.Domain.Specifications;

namespace French.Erp.Domain.Validations
{
    public class TipoDePessoaEstaConsistente : Validator<TipoDePessoa>
    {
        public TipoDePessoaEstaConsistente()
        {
            var descricaoPreenchida = new PropriedadeStringPreenchida<TipoDePessoa>(f => f.Descricao);

            //implementação regras
            base.AdicionarRegra(nameof(descricaoPreenchida), new Rule<TipoDePessoa>(descricaoPreenchida, "Preencher a Descrição."));
        }

    }
}
