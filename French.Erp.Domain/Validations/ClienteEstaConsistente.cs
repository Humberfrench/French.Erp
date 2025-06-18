using Dietcode.Core.DomainValidator;
using French.Erp.Domain.Specifications;

namespace French.Erp.Domain.Validations
{
    public class ClienteEstaConsistente : Validator<Entities.Cliente>
    {
        public ClienteEstaConsistente()
        {
            var nomePreenchida = new PropriedadeStringPreenchida<Entities.Cliente>(f => f.Nome);
            var razaoSocialPreenchido = new PropriedadeStringPreenchida<Entities.Cliente>(f => f.RazaoSocial);
            var documentoPreenchido = new PropriedadeStringPreenchida<Entities.Cliente>(f => f.Documento);
            var telefonePreenchida = new PropriedadeStringPreenchida<Entities.Cliente>(f => f.Telefone);
            var emailPreenchido = new PropriedadeStringPreenchida<Entities.Cliente>(f => f.Email);
            var tipoDeClientePreenchido = new PropriedadeIntMaiorQueZero<Entities.Cliente>(c => c.TipoDeClienteId);
            var tipoDePessoaPreenchido = new PropriedadeIntMaiorQueZero<Entities.Cliente>(c => c.TipoDePessoaId);

            //implementação regras
            base.AdicionarRegra(nameof(nomePreenchida), new Rule<Entities.Cliente>(nomePreenchida, "Preencher o Nome do Cliente."));
            base.AdicionarRegra(nameof(razaoSocialPreenchido), new Rule<Entities.Cliente>(razaoSocialPreenchido, "Preencher a Razão Social do Cliente."));
            base.AdicionarRegra(nameof(documentoPreenchido), new Rule<Entities.Cliente>(documentoPreenchido, "Preencher o Documento do Cliente."));
            base.AdicionarRegra(nameof(telefonePreenchida), new Rule<Entities.Cliente>(telefonePreenchida, "Preencher o Nome do Cliente."));
            base.AdicionarRegra(nameof(emailPreenchido), new Rule<Entities.Cliente>(emailPreenchido, "Preencher a Razão Social do Cliente."));
            base.AdicionarRegra(nameof(tipoDeClientePreenchido), new Rule<Entities.Cliente>(tipoDeClientePreenchido, "Preencher o Tipo de Cliente."));
            base.AdicionarRegra(nameof(tipoDePessoaPreenchido), new Rule<Entities.Cliente>(tipoDePessoaPreenchido, "Preencher o Tipo de Pessoa do Cliente."));
        }

    }
}
