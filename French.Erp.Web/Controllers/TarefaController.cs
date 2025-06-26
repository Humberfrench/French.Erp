using French.Erp.Application.DataObject;
using French.Erp.Application.Interfaces.Services;
using French.Erp.Web.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace French.Erp.Web.Controllers
{
    [Route("[controller]")]
    public class TarefaController : CommonController
    {

        private readonly ITarefaService tarefaService;
        private DateTime dataInicio;
        private DateTime dataFinal;

        public TarefaController(ITarefaService tarefaService,
                                IGenericsService genericService,
                                ITipoDePessoaService tipoDePessoaService,
                                ITipoDeClienteService tipoDeClienteService,
                                IClienteService clienteService,
                                IHttpContextAccessor context) : base(genericService,
                                                                   tipoDePessoaService,
                                                                   tipoDeClienteService,
                                                                   clienteService,
                                                                   context)
        {
            this.tarefaService = tarefaService;
            dataInicio = new DateTime(DateTime.Now.Year, DateTime.Now.Month, 1);
            dataFinal = dataInicio.AddMonths(1).AddDays(-1);
        }

        [HttpGet("")]
        public async Task<IActionResult> Index()
        {
            var model = new ModelBasic<TarefaDto>
            {
                Lista = new List<TarefaDto>(),
                Valor1 = 0,
                Valor2 = 0,
                Valor3 = 0,
                Seletores = new SeletoresBasic
                {
                    Seletor1 = await ObterClienteTarefasParaCombo(),
                },
                Nome = Nome,
                Role = Admin ? "Administrador" : "Usuário",
                Admin = Admin,
            };

            ViewBag.Cliente = 0;
            ViewBag.Mes = 0;
            ViewBag.Ano = 0;
            return View(model);
        }

        [HttpGet("Cliente/{id}/Ano/{ano}/Mes/{mes}")]
        public async Task<IActionResult> Index(int id, int ano, int mes = 0)
        {
            var model = new ModelBasic<TarefaDto>
            {
                Lista = (await tarefaService.ObterTodosDoCliente(id, ano, mes)).ToList(),
                Valor1 = id,
                Valor2 = ano,
                Valor3 = mes,
                Seletores = new SeletoresBasic
                {
                    Seletor1 = await ObterClienteTarefasParaCombo(),
                },
                Nome = Nome,
                Role = Admin ? "Administrador" : "Usuário",
                Admin = Admin,
            };

            return View(model);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> Index(int id)
        {
            var model = new ModelBasic<TarefaDto>
            {
                Lista = (await tarefaService.ObterTodosDoCliente(id)).ToList(),
                Valor1 = id,
                Valor2 = 0,
                Valor3 = 0,
                Seletores = new SeletoresBasic
                {
                    Seletor1 = await ObterClienteTarefasParaCombo(),
                },
                Nome = Nome,
                Role = Admin ? "Administrador" : "Usuário",
                Admin = Admin,
            };

            return View(model);
        }

        [HttpGet("New")]
        public async Task<IActionResult> New()
        {
            var model = new ModelBasic<TarefaDto, TarefaItemDto>
            {
                Erro = "",
                ViewModel = new TarefaDto
                {
                    ClienteId = 0,
                    DataInicio = dataInicio,
                    DataFim = dataFinal,
                },
                Lista = new List<TarefaItemDto>(),
                Valor1 = 0,
                Seletores = new SeletoresBasic
                {
                    Seletor1 = await ObterClienteParaCombo(),
                },
                Nome = Nome,
                Role = Admin ? "Administrador" : "Usuário",
                Admin = Admin,
            };

            return View(model);
        }

        [HttpGet("New/{id}")]
        public async Task<IActionResult> New(int id)
        {

            var model = new ModelBasic<TarefaDto, TarefaItemDto>
            {
                Erro = "",
                ViewModel = new TarefaDto{
                    ClienteId = id,
                    DataInicio = dataInicio,
                    DataFim = dataFinal,
                },
                Lista = new List<TarefaItemDto>(),
                Valor1 = id,
                Seletores = new SeletoresBasic
                {
                    Seletor1 = await ObterClienteParaCombo(),
                },
                Nome = Nome,
                Role = Admin ? "Administrador" : "Usuário",
                Admin = Admin,
            };

            return View(model);
        }

        [HttpGet("Edit/{id}")]
        public async Task<IActionResult> Edit(int id)
        {
            var dadosModel = await tarefaService.ObterPorId(id);
            if (dadosModel == null) // erro
            {
                // tratar
                var modelErro = new ModelBasic<TarefaDto, TarefaItemDto>
                {
                    Erro = "Não encontrado a tarefa. Por  favor verifique as informações.",
                    ViewModel = new TarefaDto(),
                    Lista = new List<TarefaItemDto>(), //futuramente itens de tarefa
                    Valor1 = "0",
                    Seletores = new SeletoresBasic
                    {
                        Seletor1 = await ObterClienteParaCombo(),
                    },
                    Nome = Nome,
                    Role = Admin ? "Administrador" : "Usuário",
                    Admin = Admin,
                };
                return View(modelErro);

            }

            var model = new ModelBasic<TarefaDto, TarefaItemDto>
            {
                Erro = "",
                ViewModel = dadosModel,
                Lista = new List<TarefaItemDto>(), //futuramente itens de tarefa,
                Valor1 = await tarefaService.ObterNumeroDaNota(dadosModel.TarefaId),
                Seletores = new SeletoresBasic
                {
                    Seletor1 = await ObterClienteTarefasParaCombo(),
                },
                Nome = Nome,
                Role = Admin ? "Administrador" : "Usuário",
                Admin = Admin,
            };

            return View(model);
        }

        [HttpPost("Gravar")]
        public async Task<IActionResult> Gravar(TarefaDto tarefa)
        {
            var okGravado = await tarefaService.Gravar(tarefa);

            if (okGravado.Invalid)
            {
                var model = new ModelBasic<TarefaDto, TarefaItemDto>
                {
                    Erro = okGravado.Erros[0].Message,
                    ViewModel = tarefa,
                    Valor1 = await tarefaService.ObterNumeroDaNota(tarefa.TarefaId),
                    Lista = new List<TarefaItemDto>(), //futuramente itens de tarefa,
                    Seletores = new SeletoresBasic
                    {
                        Seletor1 = await ObterClienteTarefasParaCombo(),
                    },
                    Nome = Nome,
                    Role = Admin ? "Administrador" : "Usuário",
                    Admin = Admin,
                };

                return View("New", model);
            }

            return await Index();
        }

        [HttpPost("Edit")]
        public async Task<IActionResult> Edit(TarefaDto tarefa)
        {

            var model = new ModelBasic<TarefaDto, TarefaItemDto>
            {
                Erro = "",
                ViewModel = tarefa,
                Valor1 = await tarefaService.ObterNumeroDaNota(tarefa.TarefaId),
                Lista = new List<TarefaItemDto>(), //futuramente itens de tarefa,
                Seletores = new SeletoresBasic
                {
                    Seletor1 = await ObterClienteTarefasParaCombo(),
                },
                Nome = Nome,
                Role = Admin ? "Administrador" : "Usuário",
                Admin = Admin,
            };

            return View(model);
        }

        public async Task<SelectList> ObterClienteTarefasParaCombo()
        {
            var dados = await tarefaService.ObterTodosClientes();
            var dadosSelect = new SelectList(dados, "ClienteId", "NomeCompleto");

            return dadosSelect;
        }

    }
}
