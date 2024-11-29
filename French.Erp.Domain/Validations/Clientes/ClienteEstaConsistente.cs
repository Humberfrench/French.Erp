using Dietcode.Core.DomainValidator;
using French.Erp.Domain.Specifications.Clientes;

namespace French.Erp.Domain.Validations.Clientes
{
    public class ClienteEstaConsistente : Validator<Entities.Cliente>
    {
        public ClienteEstaConsistente()
        {

            var nomePreenchida = new NomePreenchido();
            var razaoSocialPreenchido = new RazaoSocialPreenchido();
            var documentoPreenchido = new DocumentoPreenchido();
            var tipoDeClientePreenchido = new TipoDeClientePreenchido();
            var tipoDePessoaPreenchido = new TipoDePessoaPreenchido();

            //implementação regras
            base.AdicionarRegra(nameof(nomePreenchida), new Rule<Entities.Cliente>(nomePreenchida, "Preencher o Nome do Cliente."));
            base.AdicionarRegra(nameof(razaoSocialPreenchido), new Rule<Entities.Cliente>(razaoSocialPreenchido, "Preencher a Razão Social do Cliente."));
            base.AdicionarRegra(nameof(documentoPreenchido), new Rule<Entities.Cliente>(documentoPreenchido, "Preencher o Documento do Cliente."));
            base.AdicionarRegra(nameof(tipoDeClientePreenchido), new Rule<Entities.Cliente>(tipoDeClientePreenchido, "Preencher o Tipo de Cliente."));
            base.AdicionarRegra(nameof(tipoDePessoaPreenchido), new Rule<Entities.Cliente>(tipoDePessoaPreenchido, "Preencher o Tipo de Pessoa do Cliente."));
        }

    }
}
