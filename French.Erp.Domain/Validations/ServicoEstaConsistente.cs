using Dietcode.Core.DomainValidator;
using French.Erp.Domain.Specifications;

namespace French.Erp.Domain.Validations
{
    public class ServicoEstaConsistente : Validator<Entities.Servico>
    {
        public ServicoEstaConsistente()
        {
            var descricaoPreenchida = new PropriedadeStringPreenchida<Entities.Servico>(f => f.Descricao);
            var nomePreenchido = new PropriedadeStringPreenchida<Entities.Servico>(f => f.Nome);

            //implementação regras
            base.AdicionarRegra(nameof(descricaoPreenchida), new Rule<Entities.Servico>(descricaoPreenchida, "Preencher a Descrição."));
            base.AdicionarRegra(nameof(nomePreenchido), new Rule<Entities.Servico>(nomePreenchido, "Preencher o Nome."));
        }

    }
}
