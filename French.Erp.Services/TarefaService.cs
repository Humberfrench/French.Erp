using Dietcode.Core.DomainValidator;
using French.Erp.Domain.Entities;
using French.Erp.Domain.Interfaces.Repository;
using French.Erp.Domain.Interfaces.Services;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace French.Erp.Services
{
    public class TarefaService : BaseService<Tarefa>, ITarefaService
    {
        private readonly ITarefaRepository repository;
        private readonly INotaFiscalRepository notaFiscalRepository;
        private readonly ValidationResult validationResult;

        public TarefaService(IBaseRepository<Tarefa> baseRepository,
                             INotaFiscalRepository notaFiscalRepository,
                             ITarefaRepository repository) : base(baseRepository)
        {
            this.repository = repository;
            this.notaFiscalRepository = notaFiscalRepository;
            validationResult = new ValidationResult();
        }

        public async Task<ValidationResult> Excluir(int id)
        {
            var tarefa = await ObterPorId(id);
            if (tarefa == null)
            {
                validationResult.Add("Tarefa inexistente");
                return validationResult;
            }

            await base.Remover(tarefa);

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
                await base.Adicionar(tarefa);
            }
            else
            {
                await base.Atualizar(tarefa);
            }

            return validationResult;
        }
        public async new Task<IEnumerable<Tarefa>> ObterTodos()
        {
            return await repository.ObterTodos();
        }
        public async Task<IEnumerable<Tarefa>> ObterTodosDoCliente(int clienteId)
        {
            return await repository.ObterTodosDoCliente(clienteId);
        }

        public async new Task<Tarefa> ObterPorId(int id)
        {
            return await repository.ObterPorId(id);
        }

        public async Task<string> ObterNumeroDaNota(int tarefaId)
        {
            return await notaFiscalRepository.ObterNumeroDaNota(tarefaId);
        }


    }
}
