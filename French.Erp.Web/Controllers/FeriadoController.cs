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
                    Seletor1 = await ObterEstadosParaCombo()
                },
            };

            return View(model);

        }

        [HttpGet("Fixos")]
        public IActionResult Fixos() // Todos
        {
            return View();
        }

        [HttpGet("Moveis")]
        public IActionResult Moveis() // Todos
        {
            return View();
        }

        [HttpGet("Locais")]
        public IActionResult Locais() // Todos
        {
            return View();
        }

    }
}
