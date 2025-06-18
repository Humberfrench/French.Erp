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

            //implementação regras
            base.AdicionarRegra(nameof(codigoPreenchido), new Rule<Entities.Banco>(codigoPreenchido, "Preencher o Código."));
            base.AdicionarRegra(nameof(codigoZeroPreenchido), new Rule<Entities.Banco>(codigoZeroPreenchido, "Preencher o Código com um numero válido."));
            base.AdicionarRegra(nameof(apelidoPreenchido), new Rule<Entities.Banco>(apelidoPreenchido, "Preencher o Apelido."));
            base.AdicionarRegra(nameof(nomePreenchido), new Rule<Entities.Banco>(nomePreenchido, "Preencher o Nome."));
        }

    }
}
