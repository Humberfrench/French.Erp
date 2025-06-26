using Dietcode.Core.DomainValidator;
using Dietcode.Core.Lib;
using French.Erp.Application.DataObject;
using French.Erp.Application.Interfaces.Repository;
using French.Erp.Application.Interfaces.Services;
using French.Erp.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;

namespace French.Erp.Services
{
    public class TarefaService : ITarefaService
    {
        private readonly IFeriadoRepository repositoryFeriado;
        private readonly IClienteRepository repositoryCliente;
        private readonly ITarefaRepository repositoryTarefa;
        private readonly ITarefaItemRepository repositoryTarefaItem;
        private readonly INotaFiscalRepository notaFiscalRepository;
        private readonly ValidationResult validationResult;

        public TarefaService(INotaFiscalRepository notaFiscalRepository,
                             ITarefaItemRepository repositoryTarefaItem,
                             ITarefaRepository repositoryTarefa,
                             IFeriadoRepository repositoryFeriado,
                             IClienteRepository repositoryCliente)
        {
            this.repositoryTarefa = repositoryTarefa;
            this.repositoryTarefaItem = repositoryTarefaItem;
            this.notaFiscalRepository = notaFiscalRepository;
            this.repositoryFeriado = repositoryFeriado;
            validationResult = new ValidationResult();
            this.repositoryCliente = repositoryCliente;
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
            //Ajustes Tarefas.
            //validate
            Tarefa tarefa;
            var items = new List<TarefaItem>();

            //add or update
            if (tarefaDados.TarefaId == 0)
            {
                if(tarefaDados.GerarItems)
                {
                    items = await ObterTarefasItens(tarefaDados);
                }
                tarefa = tarefaDados.ConvertObjects<Tarefa>();
                if (!tarefa.IsValid())
                {
                    return tarefa.ValidationResult;
                }

                //add itens
                tarefa.TarefaItems = items;
                await repositoryTarefa.Adicionar(tarefa);
            }
            else
            {
                tarefa = await repositoryTarefa.ObterPorId(tarefaDados.TarefaId);
                if (tarefa == null)
                {
                    validationResult.Add("Tarefa inexistente");
                    return validationResult;
                }
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

        async Task<List<TarefaItem>> ObterTarefasItens(TarefaDto tarefaDados)
        {
            var items = new List<TarefaItem>();
            var cliente = await repositoryCliente.ObterPorId(tarefaDados.ClienteId);
            var cidade = cliente.CidadeId;
            var estado = cliente.EstadoId;
            byte ordem = 0;
            var datas = await ObterDatasUteis(tarefaDados.DataInicio.Year, tarefaDados.DataInicio.Month, cidade,estado);

            foreach (var data in datas)
            {
                ordem ++;
                var item = new TarefaItem
                {
                    TarefaId = tarefaDados.TarefaId,
                    Ordem = ordem,
                    Data = data,
                    Descricao = tarefaDados.Nome,
                    HorasOrcadas = 8, // Padrão == 8
                    HorasGastas = 8, // Padrão == 8
                    ValorHora = tarefaDados.ValorHora,
                    ValorItem = tarefaDados.ValorHora * 8,
                };
                items.Add(item);
            }
            return items;
        }

        public async Task<List<DateTime>> ObterDatasUteis(int ano, int mes, int? cidade, int? estado)
        {
            var datas = new List<DateTime>();
            var feriados = await repositoryFeriado.ObterFeriadosMes(mes);
            var dias = Dias(mes, ano);

            for (var i = 1; i <= dias; i++)
            {
                var dataAtual = new DateTime(ano, mes, i);

                if (DiaUtil(dataAtual))
                {
                    continue;
                }
                // Verifica se é feriado
                if (EhFeriado(dataAtual, feriados, cidade, estado))
                {
                    continue;
                }
                datas.Add(dataAtual);
            }
            return datas;
        }

        //TODO: Considerar Cidade e Estado
        bool EhFeriado(DateTime data, List<Feriado> feriados, int? cidade, int? estado)
        {
            bool feriado = false;

            //feriado moveis como carnaval, pascoa, corpus christi, etc.
            var feriadoModel = feriados.FirstOrDefault(f => f.Dia == data.Day && f.Ano == data.Year);
            if(feriadoModel != null)
            {
                feriado = true;
            }

            //feriado fixos como dia do trabalho, independencia do brasil, etc.
            var feriadoFixo = feriados.FirstOrDefault(f => f.Dia == data.Day);
            if(feriadoFixo != null)
            {
                feriado = true;
            }

            //verifica se é feriado da cidade
            if (cidade.HasValue)
            {
                var feriadoLocal = feriados.FirstOrDefault(f => f.Dia == data.Day && f.CidadeId == cidade.Value);
                if (feriadoLocal != null)
                {
                    feriado = true;
                }

            }

            //verifica se é feriado do estado
            if (estado.HasValue)
            {
                var feriadoLocal = feriados.FirstOrDefault(f => f.Dia == data.Day && f.EstadoId == estado.Value);
                if (feriadoLocal != null)
                {
                    feriado = true;
                }

            }

            return feriado;
            
        }

        bool DiaUtil(DateTime data)
        {
            if ((data.DayOfWeek == DayOfWeek.Sunday) && (data.DayOfWeek == DayOfWeek.Saturday))
            {
                return false;
            }
            return true;
        }

        int Dias(int mes, int ano)
        {
            switch (mes)
            {
                case 1: // Janeiro
                case 3: // Março
                case 5: // Maio
                case 7: // Julho
                case 8: // Agosto
                case 10: // Outubro
                case 12: // Dezembro
                    return 31;
                case 4: // Abril
                case 6: // Junho
                case 9: // Setembro
                case 11: // Novembro
                    return 30;
                case 2: // Fevereiro
                default:
                    if ((ano % 4 == 0 && ano % 100 != 0) || (ano % 400 == 0))
                    {
                        return 29; // ano bissexto
                    }
                    return 28; // ano não bissexto
            }
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
