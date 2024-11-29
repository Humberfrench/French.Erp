using French.Erp.Application.ViewModel;
using French.Erp.Web.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Linq;
using System.Threading.Tasks;

namespace French.Erp.Web.Controllers
{
    public class TipoDePessoaController : BaseController
    {
        private readonly ITipoDePessoaAppService tipoPessoaAppService;

        public TipoDePessoaController(ITipoDePessoaAppService tipoPessoaAppService,
                                      IHttpContextAccessor context) : base(context)
        {
            this.tipoPessoaAppService = tipoPessoaAppService;
        }

        public async Task<IActionResult> Index()
        {
            var model = new ModelBasic<TipoDePessoaDto>
            {
                Lista = (await tipoPessoaAppService.ObterTodos()).ToList(),
                Nome = Nome,
                Role = Admin ? "Administrador" : "Usuário",
                Admin = Admin,
            };
            return View(model);
        }
        [HttpPost]
        public async Task<IActionResult> Gravar(TipoDePessoaDto tipoDePessoa)
        {
            var result = await tipoPessoaAppService.Gravar(tipoDePessoa);

            var returnData = new
            {
                Erro = false,
                Mensagem = "Tipo de Pessoa cadastrado com sucesso.",
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
            var result = await tipoPessoaAppService.Excluir(id);

            var returnData = new
            {
                Erro = false,
                Mensagem = "Tipo de Pessoa excluído com sucesso.",
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
