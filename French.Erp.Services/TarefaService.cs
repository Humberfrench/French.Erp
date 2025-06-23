using Dietcode.Core.DomainValidator;
using Dietcode.Core.Lib;
using French.Erp.Application.DataObject;
using French.Erp.Application.Interfaces.Repository;
using French.Erp.Application.Interfaces.Services;
using French.Erp.Domain.Entities;
using System.Collections.Generic;
using System.Linq;
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

        public async Task<ValidationResult> Gravar(TarefaDto tarefaDados)
        {
            //validate

            //add or update
            if (tarefaDados.TarefaId == 0)
            {
                var tarefa = new Tarefa();

                //TODO: Atualizar as tarefas
                AtualizarTarefa(tarefaDados, ref tarefa);

                if (!tarefa.IsValid())
                {
                    return tarefa.ValidationResult;
                }
                await repositoryTarefa.Adicionar(tarefa);
            }
            else
            {
                var tarefa = await repositoryTarefa.ObterPorId(tarefaDados.TarefaId);

                //TODO: Atualizar as tarefas
                AtualizarTarefa(tarefaDados, ref tarefa);

                if (!tarefa.IsValid())
                {
                    return tarefa.ValidationResult;
                }
                await repositoryTarefa.Atualizar(tarefa);
            }

            return validationResult;
        }

        void AtualizarTarefa(TarefaDto tarefaDados, ref Tarefa tarefa)
        {
            tarefa.TarefaId = tarefaDados.TarefaId;
            tarefa.ClienteId = tarefaDados.ClienteId;
            tarefa.NotaFiscalId = tarefaDados.NotaFiscalId;
            tarefa.Nome = tarefaDados.Nome;
            tarefa.Observacao = tarefaDados.Observacao;
            tarefa.ValorOrcado = tarefaDados.ValorOrcado;
            tarefa.TotalHoras = tarefaDados.TotalHoras;
            tarefa.ValorDesconto = tarefaDados.ValorDesconto;
            tarefa.ValorBruto = tarefaDados.ValorBruto;
            tarefa.ValorHora = tarefaDados.ValorHora;
            tarefa.ValorCobrado = tarefaDados.ValorCobrado;
            tarefa.Comissao = tarefaDados.Comissao;
            tarefa.DataInicio = tarefaDados.DataInicio;
            tarefa.DataFim = tarefaDados.DataFim;


        }
        void AtualizarTarefa(List<TarefaItemDto> tarefaDados, ref List<Tarefa> tarefa)
        {
            // ver que tarefa tem igual e atualizar
            // ver que tarefa nao tem e inserir
            // ver tarefa nao tem e deletar
        }

        public async Task<IEnumerable<TarefaDto>> ObterTodos()
        {
            var tarefas = await repositoryTarefa.ObterTodos();
            return tarefas.ConvertObjects<List<TarefaDto>>();
        }
        public async Task<IEnumerable<TarefaDto>> ObterTodosDoCliente(int clienteId)
        {
            var tarefas = await repositoryTarefa.ObterTodosDoCliente(clienteId);
            return tarefas.ConvertObjects<List<TarefaDto>>();
        }
        public async Task<IEnumerable<TarefaDto>> ObterTodosDoCliente(int id, int ano, int mes = 0)
        {
            var tarefas = new List<Tarefa>();
            if (mes == 0)
            {
                tarefas = (await repositoryTarefa.ObterTodosDoCliente(id, ano)).ToList();
            }
            else
            {
                tarefas = (await repositoryTarefa.ObterTodosDoCliente(id, ano, mes)).ToList();
            }
            return tarefas.ConvertObjects<List<TarefaDto>>();
        }
        public async Task<TarefaDto> ObterPorId(int id)
        {
            var tarefa = await repositoryTarefa.ObterPorId(id);
            return tarefa.ConvertObjects<TarefaDto>();
        }

        public async Task<string> ObterNumeroDaNota(int tarefaId)
        {
            return await notaFiscalRepository.ObterNumeroDaNota(tarefaId);
        }

        public async Task<IEnumerable<ClienteDadosDto>> ObterTodosClientes()
        {
            return await repositoryTarefa.ObterTodosClientes();
        }


    }
}
