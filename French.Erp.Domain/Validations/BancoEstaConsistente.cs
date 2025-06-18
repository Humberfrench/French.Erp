using Dietcode.Core.DomainValidator;
using French.Erp.Domain.Specifications;

namespace French.Erp.Domain.Validations
{
    public class BancoEstaConsistente : Validator<Entities.Banco>
    {
        public BancoEstaConsistente()
        {

            var codigoPreenchido = new PropriedadeStringPreenchida<Entities.Banco>(f => f.Codigo);
            var nomePreenchido = new PropriedadeStringPreenchida<Entities.Banco>(f => f.Nome);
            var apelidoPreenchido = new PropriedadeStringPreenchida<Entities.Banco>(f => f.Apelido);
            var codigoZeroPreenchido = new PropriedadeNumeroStringValido<Entities.Banco>(f => f.Codigo);

            //implementa��o regras
            base.AdicionarRegra(nameof(codigoPreenchido), new Rule<Entities.Banco>(codigoPreenchido, "Preencher o C�digo."));
            base.AdicionarRegra(nameof(codigoZeroPreenchido), new Rule<Entities.Banco>(codigoZeroPreenchido, "Preencher o C�digo com um numero v�lido."));
            base.AdicionarRegra(nameof(apelidoPreenchido), new Rule<Entities.Banco>(apelidoPreenchido, "Preencher o Apelido."));
            base.AdicionarRegra(nameof(nomePreenchido), new Rule<Entities.Banco>(nomePreenchido, "Preencher o Nome."));
        }

    }
}
