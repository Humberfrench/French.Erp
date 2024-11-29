using French.Erp.Application.ViewModel;
using French.Erp.ViewModel.Interface;
using French.Erp.Web.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Linq;
using System.Threading.Tasks;

namespace French.Erp.Web.Controllers
{
    public class StatusNotaFiscalController : BaseController
    {
        private readonly IStatusNotaFiscalAppService statusNotaFiscalAppService;

        public StatusNotaFiscalController(IStatusNotaFiscalAppService statusNotaFiscalAppService,
                                          IHttpContextAccessor context) : base(context)
        {
            this.statusNotaFiscalAppService = statusNotaFiscalAppService;
        }

        public async Task<IActionResult> Index()
        {
            var model = new ModelBasic<StatusNotaFiscalViewModel>
            {
                Lista = (await statusNotaFiscalAppService.ObterTodos()).ToList(),
                Nome = Nome,
                Role = Admin ? "Administrador" : "Usuário",
                Admin = Admin,
            };
            return View(model);
        }

        [HttpPost]
        public async Task<IActionResult> Gravar(StatusNotaFiscalViewModel statusNotaFiscal)
        {
            var result = await statusNotaFiscalAppService.Gravar(statusNotaFiscal);

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

        [HttpPost, Route("Excluir/{id}")]
        public async Task<IActionResult> Excluir(int id)
        {
            var result = await statusNotaFiscalAppService.Excluir(id);

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
