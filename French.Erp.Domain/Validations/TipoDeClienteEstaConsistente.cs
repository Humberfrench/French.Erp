using Dietcode.Core.DomainValidator;
using French.Erp.Domain.Entities;
using French.Erp.Domain.Specifications;

namespace French.Erp.Domain.Validations
{
    public class TipoDeClienteEstaConsistente : Validator<TipoDeCliente>
    {
        public TipoDeClienteEstaConsistente()
        {
            var descricaoPreenchida = new PropriedadeStringPreenchida<TipoDeCliente>(f => f.Descricao);

            //implementa��o regras
            base.AdicionarRegra(nameof(descricaoPreenchida), new Rule<TipoDeCliente>(descricaoPreenchida, "Preencher a Descri��o."));
        }

    }
}
