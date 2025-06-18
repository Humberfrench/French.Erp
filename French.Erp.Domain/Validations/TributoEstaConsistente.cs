using Dietcode.Core.DomainValidator;
using French.Erp.Domain.Entities;
using French.Erp.Domain.Specifications;

namespace French.Erp.Domain.Validations
{
    public class TributoEstaConsistente : Validator<Entities.Tributo>
    {
        public TributoEstaConsistente()
        {
            var descricaoPreenchida = new PropriedadeStringPreenchida<Tributo>(f => f.Descricao);
            var faixaInicialPreenchido = new PropriedadeDecimalMaiorIgualZero<Tributo>(f => f.FaixaInicial);
            var faixaFinalPreenchido = new PropriedadeDecimalMaiorIgualZero<Tributo>(f => f.FaixaFinal);
            var percentualPreenchido = new PropriedadeDecimalMaiorQueZero<Tributo>(f => f.Percentual);
            var valorPreenchido = new PropriedadeDecimalMaiorIgualZero<Tributo>(f => f.ValorDeducao);

            //implementa��o regras
            base.AdicionarRegra(nameof(descricaoPreenchida), new Rule<Entities.Tributo>(descricaoPreenchida, "Preencher a Descri��o."));
            base.AdicionarRegra(nameof(faixaInicialPreenchido), new Rule<Entities.Tributo>(faixaInicialPreenchido, "Faixa Inicial deve ser um n�mero positivo ou zero."));
            base.AdicionarRegra(nameof(faixaFinalPreenchido), new Rule<Entities.Tributo>(faixaFinalPreenchido, "Faixa Final deve ser um n�mero positivo ou zero."));
            base.AdicionarRegra(nameof(percentualPreenchido), new Rule<Entities.Tributo>(percentualPreenchido, "Percentual deve ser um n�mero v�lido e positivo."));
            base.AdicionarRegra(nameof(valorPreenchido), new Rule<Entities.Tributo>(valorPreenchido, "Faixa Inicial deve ser um �mero positivo ou zero."));
        }

    }
}
