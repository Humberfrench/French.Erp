using Dietcode.Core.DomainValidator;
using French.Erp.Domain.Entities;
using French.Erp.Domain.Specifications.Tarefas;

namespace French.Erp.Domain.Validations.Tarefas
{
    public class TarefaEstaConsistente : Validator<Tarefa>
    {
        public TarefaEstaConsistente()
        {
            var descricaoPreenchida = new NomePreenchido();
            var clientePreenchido = new ClientePreenchido();

            //implementação regras
            base.AdicionarRegra(nameof(descricaoPreenchida), new Rule<Tarefa>(descricaoPreenchida, "Preencher o Nome."));
            base.AdicionarRegra(nameof(clientePreenchido), new Rule<Tarefa>(clientePreenchido, "Cliente não selecionado/escolhido."));
        }
    }
}
