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
    public class StatusNotaFiscalController : BaseController
    {
        private readonly IStatusNotaFiscalService statusNotaFiscalService;

        public StatusNotaFiscalController(IStatusNotaFiscalService statusNotaFiscalService,
                                          IHttpContextAccessor context) : base(context)
        {
            this.statusNotaFiscalService = statusNotaFiscalService;
        }

        [HttpGet("")]
        public async Task<IActionResult> Index()
        {
            var model = new ModelBasic<StatusNotaFiscalDto>
            {
                Lista = (await statusNotaFiscalService.ObterTodos()).ToList(),
                Nome = Nome,
                Role = Admin ? "Administrador" : "Usuário",
                Admin = Admin,
            };
            return View(model);
        }

        [HttpPost("Gravar")]
        public async Task<IActionResult> Gravar(StatusNotaFiscalDto statusNotaFiscal)
        {
            var result = await statusNotaFiscalService.Gravar(statusNotaFiscal);

            var returnData = new
            {
                Erro = false,
                Mensagem = "Status Nota Fiscal cadastrado com sucesso.",
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
            var result = await statusNotaFiscalService.Excluir(id);

            var returnData = new
            {
                Erro = false,
                Mensagem = "Tipo de Cliente excluído com sucesso.",
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
