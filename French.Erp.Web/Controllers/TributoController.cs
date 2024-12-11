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
    public class TributoController : BaseController
    {
        private readonly ITributoService tributoService;

        public TributoController(ITributoService tributoService,
                                 IHttpContextAccessor context) : base(context)
        {
            this.tributoService = tributoService;
        }

        [HttpGet("")]
        public async Task<IActionResult> Index()
        {
            var model = new ModelBasic<TributoDto>
            {
                Lista = (await tributoService.ObterTodos()).ToList(),
                Nome = Nome,
                Role = Admin ? "Administrador" : "Usuário",
                Admin = Admin,
            };
            return View(model);
        }

        [HttpPost("Excluir/{id}")]
        public async Task<IActionResult> Gravar(TributoDto tributo)
        {
            var result = await tributoService.Gravar(tributo);

            var returnData = new
            {
                Erro = false,
                Mensagem = "Serviço cadastrado com sucesso.",
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
            var result = await tributoService.Excluir(id);

            var returnData = new
            {
                Erro = false,
                Mensagem = "Tipo de Cliente excluído com sucesso.",
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
