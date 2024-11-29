using Dietcode.Core.DomainValidator;
using French.Erp.Domain.Specifications.Tributos;

namespace French.Erp.Domain.Validations.Tributos
{
    public class TributoEstaConsistente : Validator<Entities.Tributo>
    {
        public TributoEstaConsistente()
        {
            var descricaoPreenchida = new DescricaoPreenchida();
            var faixaInicialPreenchido = new FaixaInicialPreenchido();
            var faixaFinalPreenchido = new FaixaFinalPreenchido();
            var percentualPreenchido = new PercentualPreenchido();
            var valorPreenchido = new ValorPreenchido();

            //implementa��o regras
            base.AdicionarRegra(nameof(descricaoPreenchida), new Rule<Entities.Tributo>(descricaoPreenchida, "Preencher a Descri��o."));
            base.AdicionarRegra(nameof(faixaInicialPreenchido), new Rule<Entities.Tributo>(faixaInicialPreenchido, "Faixa Inicial deve ser um n�mero positivo ou zero."));
            base.AdicionarRegra(nameof(faixaFinalPreenchido), new Rule<Entities.Tributo>(faixaFinalPreenchido, "Faixa Final deve ser um n�mero positivo ou zero."));
            base.AdicionarRegra(nameof(percentualPreenchido), new Rule<Entities.Tributo>(percentualPreenchido, "Percentual deve ser um n�mero v�lido e positivo."));
            base.AdicionarRegra(nameof(valorPreenchido), new Rule<Entities.Tributo>(valorPreenchido, "Faixa Inicial deve ser um �mero positivo ou zero."));
        }

    }
}
