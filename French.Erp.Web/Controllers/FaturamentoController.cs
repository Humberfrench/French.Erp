using French.Erp.Application.DataObject;
using French.Erp.Application.Interfaces.Services;
using French.Erp.Web.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Linq;
using System.Threading.Tasks;


namespace French.Erp.Web.Controllers
{
    [Route("[controller]")]
    public class FaturamentoController : CommonController
    {
        private readonly IFaturamentoService faturamentoService;
        private readonly IClienteService clienteService;

        public FaturamentoController(IFaturamentoService faturamentoService,
                                     IClienteService clienteService,
                                     IHttpContextAccessor context) : base(null, null, null,
                                                                          clienteService,
                                                                          context)
        {
            this.faturamentoService = faturamentoService;
            this.clienteService = clienteService;
        }

        [HttpGet("")]
        public async Task<IActionResult> Index()
        {
            var model = new ModelBasic<FaturamentoDadosDto>
            {
                Lista = (await faturamentoService.Obter(UsuarioId)).ToList(),
                Nome = Nome,
                Role = Admin ? "Administrador" : "Usuário",
                Admin = Admin,
                Seletores = new SeletoresBasic
                {
                    Seletor1 = await ObterClienteParaCombo(),
                },
            };
            return View(model);
        }

        [HttpPost("")]
        public async Task<IActionResult> Index(FaturamentoPesquisaPost faturamentoPesquisaPost)
        {
            var model = new ModelBasic<FaturamentoDadosDto>
            {
                Lista = (await faturamentoService.Obter(UsuarioId,
                                                        faturamentoPesquisaPost.ClienteId,
                                                        faturamentoPesquisaPost.Mes,
                                                        faturamentoPesquisaPost.Ano,
                                                        faturamentoPesquisaPost.Faturado)).ToList(),
                Nome = Nome,
                Role = Admin ? "Administrador" : "Usuário",
                Admin = Admin,
                Seletores = new SeletoresBasic
                {
                    Seletor1 = await ObterClienteParaCombo(),
                },
            };
            return View(model);
        }

        [HttpPost("Excluir/{id}")]
        public async Task<IActionResult> Gravar(FaturamentoDto tributo)
        {
            var result = await faturamentoService.Gravar(tributo);

            var returnData = new
            {
                Erro = false,
                Mensagem = "Faturamento cadastrado com sucesso.",
            };
            if (result.Invalid)
            {
                returnData = new
                {
                    Erro = true,
                    Mensagem = RenderizeErros(result)
                };
            }

            return Json(returnData);

        }

        [HttpPost("{id}")]
        public async Task<IActionResult> Excluir(int id)
        {
            var result = await faturamentoService.Excluir(id);

            var returnData = new
            {
                Erro = false,
                Mensagem = "Faturamento excluído com sucesso.",
            };
            if (result.Invalid)
            {
                returnData = new
                {
                    Erro = true,
                    Mensagem = RenderizeErros(result)
                };
            }

            return Json(returnData);

        }
    }
}
