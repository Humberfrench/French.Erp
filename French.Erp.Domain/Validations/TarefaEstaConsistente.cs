using Dietcode.Core.DomainValidator;
using French.Erp.Domain.Entities;
using French.Erp.Domain.Specifications;

namespace French.Erp.Domain.Validations
{
    public class TarefaEstaConsistente : Validator<Tarefa>
    {
        public TarefaEstaConsistente()
        {
            var nomePreenchida = new PropriedadeStringPreenchida<Tarefa>(f => f.Nome);
            var clientePreenchido = new PropriedadeIntMaiorQueZero<Tarefa>(f => f.ClienteId);

            //implementa��o regras
            base.AdicionarRegra(nameof(nomePreenchida), new Rule<Tarefa>(nomePreenchida, "Preencher o Nome."));
            base.AdicionarRegra(nameof(clientePreenchido), new Rule<Tarefa>(clientePreenchido, "Cliente n�o selecionado/escolhido."));
        }
    }
}
