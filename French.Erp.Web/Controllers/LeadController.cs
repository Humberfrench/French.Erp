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
    public class LeadController : CommonController
    {
        private readonly ILeadService leadService;

        public LeadController(ILeadService leadService,
                              IGenericsService genericService,
                              ITipoDePessoaService tipoDePessoaService,
                              ITipoDeClienteService tipoDeClienteService,
                              IClienteService clienteService,
                              IHttpContextAccessor context) : base(genericService,
                                                                   tipoDePessoaService,
                                                                   tipoDeClienteService,
                                                                   clienteService,
                                                                   context)
        {
            this.leadService = leadService;
        }

        [HttpGet("")]
        public async Task<IActionResult> Index()
        {
            var model = new ModelBasic<LeadDto>
            {
                Lista = (await leadService.ObterTodos()).ToList(),
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
    }
}
