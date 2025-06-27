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
    public class TipoDeClienteController : BaseController
    {
        private readonly ITipoDeClienteService tipoDeClienteService;

        public TipoDeClienteController(ITipoDeClienteService tipoDeClienteService,
                                       IHttpContextAccessor context) : base(context)
        {
            this.tipoDeClienteService = tipoDeClienteService;
        }

        [HttpGet("")]
        public async Task<IActionResult> Index()
        {
            var model = new ModelBasic<TipoDeClienteDto>
            {
                Lista = (await tipoDeClienteService.ObterTodos()).ToList(),
                Nome = Nome,
                Role = Admin ? "Administrador" : "Usuário",
                Admin = Admin,
            };
            return View(model);
        }

        [HttpPost("Gravar")]
        public async Task<IActionResult> Gravar([FromBody] TipoDeClienteDto tipoDeTarefa)
        {
            var result = await tipoDeClienteService.Gravar(tipoDeTarefa);

            var returnData = new
            {
                Erro = false,
                Mensagem = "Tipo de Tarefa cadastrado com sucesso.",
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
        public async Task<IActionResult> Excluir(byte id)
        {
            var result = await tipoDeClienteService.Excluir(id);

            var returnData = new
            {
                Erro = false,
                Mensagem = "Tipo de Tarefa excluído com sucesso.",
            };
            if (!result.Valid)
                returnData = new
                {
                    Erro = true,
                    Mensagem = RenderizeErros(result)
                };
            return Json(returnData);
        }

    }
}
