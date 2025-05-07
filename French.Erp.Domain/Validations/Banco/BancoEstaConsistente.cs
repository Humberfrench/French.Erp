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

            //implementa��o regras
            base.AdicionarRegra(nameof(codigoPreenchido), new Rule<Entities.Banco>(codigoPreenchido, "Preencher o C�digo."));
            base.AdicionarRegra(nameof(codigoZeroPreenchido), new Rule<Entities.Banco>(codigoZeroPreenchido, "Preencher o C�digo com um numero v�lido."));
            base.AdicionarRegra(nameof(nomePreenchido), new Rule<Entities.Banco>(nomePreenchido, "Preencher o Nome."));
        }

    }
}
