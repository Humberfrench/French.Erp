using Dietcode.Core.DomainValidator;
using French.Erp.Domain.Entities;
using French.Erp.Domain.Interfaces.Repository;
using French.Erp.Domain.Interfaces.Services;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace French.Erp.Services
{
    public class TarefaItemService : BaseService<TarefaItem>, ITarefaItemService
    {
        private readonly ITarefaItemRepository repository;
        private readonly ValidationResult validationResult;

        public TarefaItemService(IBaseRepository<TarefaItem> baseRepository,
                                 ITarefaItemRepository repository) : base(baseRepository)
        {
            this.repository = repository;
            validationResult = new ValidationResult();
        }

        public async Task<ValidationResult> Excluir(int id)
        {
            var tarefa = await ObterPorId(id);
            if (tarefa == null)
            {
                validationResult.Add("Item da Tarefa inexistente");
                return validationResult;
            }

            await base.Remover(tarefa);

            return validationResult;
        }

        public async Task<ValidationResult> Gravar(TarefaItem tarefa)
        {
            ////validate
            //if (!tarefa.IsValid())
            //{
            //    return tarefa.ValidationResult;
            //}

            //add or update
            if (tarefa.TarefaId == 0)
            {
                await base.Adicionar(tarefa);
            }
            else
            {
                await base.Atualizar(tarefa);
            }

            return validationResult;
        }
        public async new Task<IEnumerable<TarefaItem>> ObterTodos()
        {
            return await repository.ObterTodos();
        }
        public async Task<IEnumerable<TarefaItem>> ObterTodosItensDaTarefa(int tarefaId)
        {
            return await repository.ObterTodosItensDaTarefa(tarefaId);
        }

        public async new Task<TarefaItem> ObterPorId(int id)
        {
            return await repository.ObterPorId(id);
        }



    }
}
