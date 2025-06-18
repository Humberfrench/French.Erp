using Dietcode.Core.DomainValidator;
using French.Erp.Domain.Entities;
using French.Erp.Domain.Specifications;

namespace French.Erp.Domain.Validations
{
    public class StatusNotaFiscalEstaConsistente : Validator<StatusNotaFiscal>
    {
        public StatusNotaFiscalEstaConsistente()
        {
            var descricaoPreenchida = new PropriedadeStringPreenchida<StatusNotaFiscal>(f => f.Descricao);

            //implementação regras
            base.AdicionarRegra(nameof(descricaoPreenchida), new Rule<StatusNotaFiscal>(descricaoPreenchida, "Preencher a Descrição."));
        }

    }
}
