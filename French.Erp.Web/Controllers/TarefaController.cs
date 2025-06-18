using French.Erp.Application.DataObject;
using French.Erp.Application.Interfaces.Services;
using French.Erp.Web.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace French.Erp.Web.Controllers
{
    [Route("[controller]")]
    public class TarefaController : CommonController
    {

        private readonly ITarefaService tarefaService;

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
        }

        [HttpGet("")]
        public async Task<IActionResult> Index()
        {
            var model = new ModelBasic<TarefaDto>
            {
                Lista = (await tarefaService.ObterTodos()).ToList(),
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

        [HttpGet("{id}")]
        public async Task<IActionResult> Index(int id)
        {
            var model = new ModelBasic<TarefaDto>
            {
                Lista = (await tarefaService.ObterTodosDoCliente(id)).ToList(),
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

        [HttpGet("New/{clienteId}")]
        public async Task<IActionResult> New(int clienteId)
        {

            var model = new ModelBasic<TarefaDto, TarefaItemDto>
            {
                Erro = "",
                ViewModel = new TarefaDto()
                {
                    ClienteId = clienteId
                },
                Lista = new List<TarefaItemDto>(),
                Valor1 = "0",
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
                    Seletor1 = await ObterClienteParaCombo(),
                },
                Nome = Nome,
                Role = Admin ? "Administrador" : "Usuário",
                Admin = Admin,
            };

            return View(model);
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
                    Seletor1 = await ObterClienteParaCombo(),
                },
                Nome = Nome,
                Role = Admin ? "Administrador" : "Usuário",
                Admin = Admin,
            };

            return View(model);
        }

    }
}
