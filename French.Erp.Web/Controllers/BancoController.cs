using French.Erp.Application.DataObject;
using French.Erp.Application.Interfaces.Services;
using French.Erp.Web.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Linq;
using System.Threading.Tasks;

namespace French.Erp.Web.Controllers
{
    public class BancoController : BaseController
    {
        private readonly IBancoService bancoAppService;

        public BancoController(IHttpContextAccessor context, IBancoService bancoAppService) : base(context)
        {
            this.bancoAppService = bancoAppService;
        }

        [HttpGet("")]
        public async Task<IActionResult> Index()
        {
            var model = new ModelBasic<BancoDto>
            {
                Lista = (await bancoAppService.ObterTodos()).ToList(),
                Nome = Nome,
                Role = Admin ? "Administrador" : "Usuário",
                Admin = Admin,
            };
            return View(model);
        }

        [HttpPost]
        public async Task<IActionResult> Gravar(BancoDto banco)
        {
            var result = await bancoAppService.Gravar(banco);

            var returnData = new
            {
                Erro = false,
                Mensagem = "Banco cadastrado com sucesso.",
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

        [HttpPost]
        public async Task<IActionResult> AlterarStatus(int banco, bool status)
        {
            var result = await bancoAppService.AlterarStatus( banco, status);

            var returnData = new
            {
                Erro = false,
                Mensagem = "Banco atualizado o status com sucesso.",
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
