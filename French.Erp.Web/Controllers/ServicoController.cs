using French.Erp.Application.ViewModel;
using French.Erp.ViewModel.Interface;
using French.Erp.Web.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Linq;
using System.Threading.Tasks;

namespace French.Erp.Web.Controllers
{
    public class ServicoController : BaseController
    {
        private readonly IServicoAppService servicoAppService;

        public ServicoController(IServicoAppService servicoAppService,
                                 IHttpContextAccessor context) : base(context)
        {
            this.servicoAppService = servicoAppService;
        }

        public async Task<IActionResult> Index()
        {
            var model = new ModelBasic<ServicoViewModel>
            {
                Lista = (await servicoAppService.ObterTodos()).ToList(),
                Nome = Nome,
                Role = Admin ? "Administrador" : "Usuário",
                Admin = Admin,
            };
            return View(model);
        }

        [HttpPost]
        public async Task<IActionResult> Gravar(ServicoViewModel servico)
        {
            var result = await servicoAppService.Gravar(servico);

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

        [HttpPost, Route("Excluir/{id}")]
        public async Task<IActionResult> Excluir(int id)
        {
            var result = await servicoAppService.Excluir(id);

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
