using French.Erp.Application.DataObject;
using French.Erp.Application.Interfaces.Services;
using French.Erp.Web.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using System.Linq;
using System.Threading.Tasks;


namespace French.Erp.Web.Controllers
{
    [Route("[controller]")]
    public class ClienteController : CommonController
    {
        private readonly IClienteService clienteService;

        public ClienteController(IClienteService clienteService,
                                 IGenericsService genericService,
                                 ITipoDePessoaService tipoDePessoaService,
                                 ITipoDeClienteService tipoDeClienteService,
                                 IHttpContextAccessor context) : base(genericService,
                                                                      tipoDePessoaService,
                                                                      tipoDeClienteService,
                                                                      clienteService,
                                                                      context)
        {
            this.clienteService = clienteService;
        }

        [HttpGet("")]
        public async Task<IActionResult> Index()
        {
            var model = new ModelBasic<ClienteDto>
            {
                Lista = (await clienteService.ObterTodos()).ToList(),
                Seletores = new SeletoresBasic
                {
                    Seletor1 = await ObterTipoDeClienteParaCombo(),
                    Seletor2 = await ObterTipoDePessoaParaCombo(),
                    Seletor3 = await ObterEstadosParaCombo(),
                },
                Nome = Nome,
                Role = Admin ? "Administrador" : "Usuário",
                Admin = Admin,
            };
            return View(model);
        }

        [HttpPost("Gravar")]

        public async Task<IActionResult> Gravar(ClienteDto servico)
        {
            var result = await clienteService.Gravar(servico);

            var returnData = new
            {
                Erro = false,
                Mensagem = "Cliente cadastrado com sucesso.",
            };
            if (!result.Valid)
            {
                returnData = new
                {
                    Erro = true,
                    Mensagem = RenderizeErros(result)
                };
            }

            return Json(returnData);

        }

        [HttpPost("Excluir/{id}")]
        public async Task<IActionResult> Excluir(int id)
        {
            var result = await clienteService.Excluir(id);

            var returnData = new
            {
                Erro = false,
                Mensagem = "Cliente excluído com sucesso.",
            };
            if (!result.Valid)
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
