using French.Erp.Application.ViewModel;
using French.Erp.Web.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using System.Linq;
using System.Threading.Tasks;


namespace French.Erp.Web.Controllers
{
    [Route("Cliente")]
    public class ClienteController : BaseController
    {
        private readonly IGenericsAppService genericAppService;
        private readonly IClienteAppService clienteAppService;
        private readonly ITipoDePessoaAppService tipoDePessoaAppService;
        private readonly ITipoDeClienteAppService tipoDeClienteAppService;

        public ClienteController(IClienteAppService clienteAppService,
                                 IGenericsAppService genericAppService,
                                 ITipoDePessoaAppService tipoDePessoaAppService,
                                 ITipoDeClienteAppService tipoDeClienteAppService,
                                 IHttpContextAccessor context) : base(context)
        {
            this.genericAppService = genericAppService;
            this.clienteAppService = clienteAppService;
            this.tipoDePessoaAppService = tipoDePessoaAppService;
            this.tipoDeClienteAppService = tipoDeClienteAppService;
        }
        [Route("")]
        public async Task<IActionResult> Index()
        {
            var model = new ModelBasic<ClienteDto>
            {
                Lista = (await clienteAppService.ObterTodos()).ToList(),
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

        [HttpPost, Route("Gravar")]

        public async Task<IActionResult> Gravar(ClienteDto servico)
        {
            var result = await clienteAppService.Gravar(servico);

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

        [HttpPost, Route("Excluir/{id}")]
        public async Task<IActionResult> Excluir(int id)
        {
            var result = await clienteAppService.Excluir(id);

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

        [Route("ObterCidades/{id}")]
        public async Task<IActionResult> ObterCidades(int id)
        {
            var dados = await genericAppService.ObterCidades(id);
            return Json(dados);

        }

        private async Task<SelectList> ObterTipoDeClienteParaCombo()
        {
            var dados = await tipoDeClienteAppService.ObterTodos();
            var dadosSelect = new SelectList(dados, "TipoDeClienteId", "Descricao");

            return dadosSelect;
        }
        private async Task<SelectList> ObterTipoDePessoaParaCombo()
        {
            var dados = await tipoDePessoaAppService.ObterTodos();
            var dadosSelect = new SelectList(dados, "TipoDePessoaId", "Descricao");

            return dadosSelect;
        }
        private async Task<SelectList> ObterEstadosParaCombo()
        {
            var dados = await genericAppService.ObterEstados();
            var dadosSelect = new SelectList(dados, "EstadoId", "NomeUf");

            return dadosSelect;
        }
    }
}
