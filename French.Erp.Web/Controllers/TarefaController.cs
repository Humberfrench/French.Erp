using French.Erp.Application.DataObject;
using French.Erp.Application.Interfaces.Services;
using French.Erp.Web.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace French.Erp.Web.Controllers
{
    [Route("Tarefa")]
    public class TarefaController : BaseController
    {

        private readonly IClienteService clienteAppService;
        private readonly ITarefaService tarefaAppService;

        public TarefaController(IClienteService clienteAppService,
                                ITarefaService tarefaAppService,
                                IHttpContextAccessor context) : base(context)
        {
            this.tarefaAppService = tarefaAppService;
            this.clienteAppService = clienteAppService;

        }

        [Route("")]
        public async Task<IActionResult> Index()
        {
            var model = new ModelBasic<TarefaDto>
            {
                Lista = (await tarefaAppService.ObterTodos()).ToList(),
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

        [Route("{id}")]
        public async Task<IActionResult> Index(int id)
        {
            var model = new ModelBasic<TarefaDto>
            {
                Lista = (await tarefaAppService.ObterTodosDoCliente(id)).ToList(),
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

        [Route("New/{clienteId}")]
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

        [Route("Edit/{id}")]
        public async Task<IActionResult> Edit(int id)
        {
            var dadosModel = await tarefaAppService.ObterPorId(id);
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
                Valor1 = await tarefaAppService.ObterNumeroDaNota(dadosModel.TarefaId),
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

        [HttpPost, Route("Edit")]
        public async Task<IActionResult> Edit(TarefaDto tarefa)
        {

            var model = new ModelBasic<TarefaDto, TarefaItemDto>
            {
                Erro = "",
                ViewModel = tarefa,
                Valor1 = await tarefaAppService.ObterNumeroDaNota(tarefa.TarefaId),
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


        private async Task<SelectList> ObterClienteParaCombo()
        {
            var dados = await clienteAppService.ObterTodosParaCombo();
            var dadosSelect = new SelectList(dados, "ClienteId", "NomeCompleto");

            return dadosSelect;
        }


    }
}
