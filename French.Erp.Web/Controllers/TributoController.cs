using French.Erp.Application.ViewModel;
using French.Erp.Web.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Linq;
using System.Threading.Tasks;


namespace French.Erp.Web.Controllers
{
    public class TributoController : BaseController
    {
        private readonly ITributoAppService tributoAppService;

        public TributoController(ITributoAppService tributoAppService,
                                 IHttpContextAccessor context) : base(context)
        {
            this.tributoAppService = tributoAppService;
        }

        public async Task<IActionResult> Index()
        {
            var model = new ModelBasic<TributoDto>
            {
                Lista = (await tributoAppService.ObterTodos()).ToList(),
                Nome = Nome,
                Role = Admin ? "Administrador" : "Usuário",
                Admin = Admin,
            };
            return View(model);
        }

        [HttpPost, Route("Excluir/{id}")]
        public async Task<IActionResult> Gravar(TributoDto tributo)
        {
            var result = await tributoAppService.Gravar(tributo);

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

        [HttpPost, Route("{id}")]
        public async Task<IActionResult> Excluir(int id)
        {
            var result = await tributoAppService.Excluir(id);

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
