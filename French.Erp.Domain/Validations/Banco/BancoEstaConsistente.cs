using Dietcode.Core.DomainValidator;
using French.Erp.Domain.Specifications.Banco;

namespace French.Erp.Domain.Validations.Banco
{
    public class BancoEstaConsistente : Validator<Entities.Banco>
    {
        public BancoEstaConsistente()
        {
            var codigoPreenchido = new CodigoPreenchida();
            var codigoZeroPreenchido = new CodigoZeroPreenchida();
            var nomePreenchido = new NomePreenchido();

            //implementação regras
            base.AdicionarRegra(nameof(codigoPreenchido), new Rule<Entities.Banco>(codigoPreenchido, "Preencher o Código."));
            base.AdicionarRegra(nameof(codigoZeroPreenchido), new Rule<Entities.Banco>(codigoZeroPreenchido, "Preencher o Código com um numero válido."));
            base.AdicionarRegra(nameof(nomePreenchido), new Rule<Entities.Banco>(nomePreenchido, "Preencher o Nome."));
        }

    }
}
