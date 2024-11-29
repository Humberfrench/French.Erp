using Dietcode.Core.DomainValidator;
using French.Erp.Domain.Entities;
using French.Erp.Domain.Specifications.StatusNotaFiscals;

namespace French.Erp.Domain.Validations.StatusNotaFiscals
{
    public class StatusNotaFiscalEstaConsistente : Validator<StatusNotaFiscal>
    {
        public StatusNotaFiscalEstaConsistente()
        {
            var descricaoPreenchida = new DescricaoPreenchida();

            //implementação regras
            base.AdicionarRegra(nameof(descricaoPreenchida), new Rule<Entities.StatusNotaFiscal>(descricaoPreenchida, "Preencher a Descrição."));
        }

    }
}
