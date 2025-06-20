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
    public class FeriadoController : CommonController
    {
        private readonly IFeriadoService feriadoAppService;

        public FeriadoController(IHttpContextAccessor context, 
                                 IFeriadoService feriadoAppService,
                                 IGenericsService genericService) : base(genericService, null, null, null, context)
        {
            this.feriadoAppService = feriadoAppService;
        }

        [HttpGet("")]
        public async Task<IActionResult> Index() // Todos
        {
            var model = new ModelBasic<FeriadoDto>
            {
                Lista = (await feriadoAppService.ObterTodos()).ToList(),
                Nome = Nome,
                Role = Admin ? "Administrador" : "Usuário",
                Admin = Admin,
                Seletores = new SeletoresBasic
                {
                    Seletor1 = await ObterEstadosParaCombo(),
                    Seletor2 = await ObterCidades()
                },
            };

            return View(model);

        }

        [HttpGet("Fixos")]
        public async Task<IActionResult> Fixos() // Todos
        {
            var model = new ModelBasic<FeriadoDto>
            {
                Lista = (await feriadoAppService.ObterFixos()).ToList(),
                Nome = Nome,
                Role = Admin ? "Administrador" : "Usuário",
                Admin = Admin,
                Seletores = new SeletoresBasic
                {
                    Seletor1 = await ObterEstadosParaCombo(),
                    Seletor2 = await ObterCidades()
                },
            };

            return View("Index", model);
        }

        [HttpGet("Moveis")]
        public async Task<IActionResult> Moveis() // Todos
        {
            var model = new ModelBasic<FeriadoDto>
            {
                Lista = (await feriadoAppService.ObterMoveis()).ToList(),
                Nome = Nome,
                Role = Admin ? "Administrador" : "Usuário",
                Admin = Admin,
                Seletores = new SeletoresBasic
                {
                    Seletor1 = await ObterEstadosParaCombo(),
                    Seletor2 = await ObterCidades()
                },
            };

            return View("Index", model);
        }

        [HttpGet("Locais")]
        public async Task<IActionResult> Locais() // Todos
        {
            var model = new ModelBasic<FeriadoDto>
            {
                Lista = (await feriadoAppService.ObterLocais()).ToList(),
                Nome = Nome,
                Role = Admin ? "Administrador" : "Usuário",
                Admin = Admin,
                Seletores = new SeletoresBasic
                {
                    Seletor1 = await ObterEstadosParaCombo(),
                    Seletor2 = await ObterCidades()
                },
            };

            return View("Index", model);
        }

    }
}
