using Dietcode.Core.DomainValidator;
using French.Erp.Domain.Specifications.Servicos;

namespace French.Erp.Domain.Validations.Servicos
{
    public class ServicoEstaConsistente : Validator<Entities.Servico>
    {
        public ServicoEstaConsistente()
        {
            var descricaoPreenchida = new DescricaoPreenchida();
            var nomePreenchido = new NomePreenchido();

            //implementa��o regras
            base.AdicionarRegra(nameof(descricaoPreenchida), new Rule<Entities.Servico>(descricaoPreenchida, "Preencher a Descri��o."));
            base.AdicionarRegra(nameof(nomePreenchido), new Rule<Entities.Servico>(nomePreenchido, "Preencher o Nome."));
        }

    }
}
