using Dietcode.Core.DomainValidator;
using French.Erp.Domain.Specifications.TipoDePessoas;

namespace French.Erp.Domain.Validations.TipoDePessoas
{
    public class TipoDePessoaEstaConsistente : Validator<Entities.TipoDePessoa>
    {
        public TipoDePessoaEstaConsistente()
        {
            var descricaoPreenchida = new DescricaoPreenchida();

            //implementa��o regras
            base.AdicionarRegra(nameof(descricaoPreenchida), new Rule<Entities.TipoDePessoa>(descricaoPreenchida, "Preencher a Descri��o."));
        }

    }
}
