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
    public class ServicoController : BaseController
    {
        private readonly IServicoService servicoService;

        public ServicoController(IServicoService servicoService,
                                 IHttpContextAccessor context) : base(context)
        {
            this.servicoService = servicoService;
        }

        [HttpGet("")]
        public async Task<IActionResult> Index()
        {
            var model = new ModelBasic<ServicoDto>
            {
                Lista = (await servicoService.ObterTodos()).ToList(),
                Nome = Nome,
                Role = Admin ? "Administrador" : "Usuário",
                Admin = Admin,
            };
            return View(model);
        }

        [HttpPost]
        public async Task<IActionResult> Gravar(ServicoDto servico)
        {
            var result = await servicoService.Gravar(servico);

            var returnData = new
            {
                Erro = false,
                Mensagem = "Serviço cadastrado com sucesso.",
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
            var result = await servicoService.Excluir(id);

            var returnData = new
            {
                Erro = false,
                Mensagem = "Serviço excluído com sucesso.",
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
