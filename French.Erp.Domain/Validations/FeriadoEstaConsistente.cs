using Dietcode.Core.DomainValidator;
using French.Erp.Domain.Specifications;

namespace French.Erp.Domain.Validations
{
    public class FeriadoEstaConsistente : Validator<Entities.Feriado>
    {
        public FeriadoEstaConsistente()
        {
            var nomePreenchido = new PropriedadeStringPreenchida<Entities.Feriado>(f => f.Nome);
            var diaPreenchido = new PropriedadeIntMaiorQueZero<Entities.Feriado>(c => c.Dia);
            var mesPreenchido = new PropriedadeIntMaiorQueZero<Entities.Feriado>(c => c.Mes);
            var diaValido = new PropriedadeDiaValido<Entities.Feriado>(f => f.Dia, f => f.Mes);
            var mesValido = new PropriedadeMesValido<Entities.Feriado>(f => f.Mes);

            //implementação regras
            base.AdicionarRegra(nameof(diaPreenchido), new Rule<Entities.Feriado>(diaPreenchido, "Preencher ao menos um nome de contato, email ou telefone."));
            base.AdicionarRegra(nameof(mesPreenchido), new Rule<Entities.Feriado>(mesPreenchido, "Preencher o Tipo de Cliente."));
            base.AdicionarRegra(nameof(nomePreenchido), new Rule<Entities.Feriado>(nomePreenchido, "Preencher o Tipo de Pessoa do Cliente."));
            base.AdicionarRegra(nameof(diaValido), new Rule<Entities.Feriado>(diaValido, "Preencher o Tipo de Cliente."));
            base.AdicionarRegra(nameof(mesValido), new Rule<Entities.Feriado>(mesValido, "Preencher o Tipo de Pessoa do Cliente."));
        }
    }
}
