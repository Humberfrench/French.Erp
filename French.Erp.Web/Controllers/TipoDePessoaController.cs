using French.Erp.Application.DataObject;
using French.Erp.Application.Interfaces.Services;
using French.Erp.Web.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Linq;
using System.Threading.Tasks;

namespace French.Erp.Web.Controllers
{
    public class TipoDePessoaController : BaseController
    {
        private readonly ITipoDePessoaService tipoPessoaService;

        public TipoDePessoaController(ITipoDePessoaService tipoPessoaService,
                                      IHttpContextAccessor context) : base(context)
        {
            this.tipoPessoaService = tipoPessoaService;
        }

        public async Task<IActionResult> Index()
        {
            var model = new ModelBasic<TipoDePessoaDto>
            {
                Lista = (await tipoPessoaService.ObterTodos()).ToList(),
                Nome = Nome,
                Role = Admin ? "Administrador" : "Usuário",
                Admin = Admin,
            };
            return View(model);
        }
        [HttpPost]
        public async Task<IActionResult> Gravar(TipoDePessoaDto tipoDePessoa)
        {
            var result = await tipoPessoaService.Gravar(tipoDePessoa);

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
            var result = await tipoPessoaService.Excluir(id);

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
