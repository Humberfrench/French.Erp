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
            var apelidoPreenchido = new ApelidoPreenchida();

            //implementação regras
            base.AdicionarRegra(nameof(codigoPreenchido), new Rule<Entities.Banco>(codigoPreenchido, "Preencher o Código."));
            base.AdicionarRegra(nameof(codigoZeroPreenchido), new Rule<Entities.Banco>(codigoZeroPreenchido, "Preencher o Código com um numero válido."));
            base.AdicionarRegra(nameof(apelidoPreenchido), new Rule<Entities.Banco>(apelidoPreenchido, "Preencher o Apelido."));
            base.AdicionarRegra(nameof(nomePreenchido), new Rule<Entities.Banco>(nomePreenchido, "Preencher o Nome."));
        }

    }
}
