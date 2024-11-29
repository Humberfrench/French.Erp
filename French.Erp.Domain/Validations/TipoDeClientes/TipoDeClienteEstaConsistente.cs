using Dietcode.Core.DomainValidator;
using French.Erp.Domain.Specifications.TipoDeClientes;

namespace French.Erp.Domain.Validations.TipoDeClientes
{
    public class TipoDeClienteEstaConsistente : Validator<Entities.TipoDeCliente>
    {
        public TipoDeClienteEstaConsistente()
        {
            var descricaoPreenchida = new DescricaoPreenchida();

            //implementação regras
            base.AdicionarRegra(nameof(descricaoPreenchida), new Rule<Entities.TipoDeCliente>(descricaoPreenchida, "Preencher a Descrição."));
        }

    }
}
