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

            //implementação regras
            base.AdicionarRegra(nameof(descricaoPreenchida), new Rule<Entities.Tributo>(descricaoPreenchida, "Preencher a Descrição."));
            base.AdicionarRegra(nameof(faixaInicialPreenchido), new Rule<Entities.Tributo>(faixaInicialPreenchido, "Faixa Inicial deve ser um número positivo ou zero."));
            base.AdicionarRegra(nameof(faixaFinalPreenchido), new Rule<Entities.Tributo>(faixaFinalPreenchido, "Faixa Final deve ser um número positivo ou zero."));
            base.AdicionarRegra(nameof(percentualPreenchido), new Rule<Entities.Tributo>(percentualPreenchido, "Percentual deve ser um número válido e positivo."));
            base.AdicionarRegra(nameof(valorPreenchido), new Rule<Entities.Tributo>(valorPreenchido, "Faixa Inicial deve ser um úmero positivo ou zero."));
        }

    }
}
