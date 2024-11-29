using Dietcode.Core.DomainValidator;
using French.Erp.Application.Interfaces.Repository;
using French.Erp.Application.Interfaces.Services;
using French.Erp.Domain.Entities;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace French.Erp.Services
{
    public class TarefaService : ITarefaService
    {
        private readonly ITarefaRepository repositoryTarefa;
        private readonly ITarefaItemRepository repositoryTarefaItem;
        private readonly INotaFiscalRepository notaFiscalRepository;
        private readonly ValidationResult validationResult;

        public TarefaService(INotaFiscalRepository notaFiscalRepository, 
                             ITarefaItemRepository repositoryTarefaItem,
                             ITarefaRepository repositoryTarefa)
        {
            this.repositoryTarefa = repositoryTarefa;
            this.repositoryTarefaItem = repositoryTarefaItem;
            this.notaFiscalRepository = notaFiscalRepository;
            validationResult = new ValidationResult();
        }

        public async Task<ValidationResult> Excluir(int id)
        {
            var tarefa = await repositoryTarefa.ObterPorId(id);
            if (tarefa == null)
            {
                validationResult.Add("Tarefa inexistente");
                return validationResult;
            }

            await repositoryTarefa.Remover(tarefa);

            return validationResult;
        }

        public async Task<ValidationResult> Gravar(Tarefa tarefa)
        {
            //validate
            if (!tarefa.IsValid())
            {
                return tarefa.ValidationResult;
            }

            //add or update
            if (tarefa.TarefaId == 0)
            {
                await repositoryTarefa.Adicionar(tarefa);
            }
            else
            {
                await repositoryTarefa.Atualizar(tarefa);
            }

            return validationResult;
        }
        public async Task<IEnumerable<Tarefa>> ObterTodos()
        {
            return await repositoryTarefa.ObterTodos();
        }
        public async Task<IEnumerable<Tarefa>> ObterTodosDoCliente(int clienteId)
        {
            return await repositoryTarefa.ObterTodosDoCliente(clienteId);
        }

        public async Task<Tarefa> ObterPorId(int id)
        {
            return await repositoryTarefa.ObterPorId(id);
        }

        public async Task<string> ObterNumeroDaNota(int tarefaId)
        {
            return await notaFiscalRepository.ObterNumeroDaNota(tarefaId);
        }


    }
}
