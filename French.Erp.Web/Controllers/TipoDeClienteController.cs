using French.Erp.ViewModel.Interface;
using French.Erp.ViewModel.ViewModel;
using French.Erp.Web.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Linq;
using System.Threading.Tasks;

namespace French.Erp.Web.Controllers
{
    public class TipoDeClienteController : BaseController
    {
        private readonly ITipoDeClienteAppService tipoTarefaAppService;

        public TipoDeClienteController(ITipoDeClienteAppService tipoTarefaAppService,
                                       IHttpContextAccessor context) : base(context)
        {
            this.tipoTarefaAppService = tipoTarefaAppService;
        }

        public async Task<IActionResult> Index()
        {
            var model = new ModelBasic<TipoDeClienteViewModel>
            {
                Lista = (await tipoTarefaAppService.ObterTodos()).ToList(),
                Nome = Nome,
                Role = Admin ? "Administrador" : "Usuário",
                Admin = Admin,
            };
            return View(model);
        }

        [HttpPost]
        public async Task<IActionResult> Gravar(TipoDeClienteViewModel tipoDeTarefa)
        {
            var result = await tipoTarefaAppService.Gravar(tipoDeTarefa);

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

        [HttpPost, Route("Excluir/{id}")]
        public async Task<IActionResult> Excluir(int id)
        {
            var result = await tipoTarefaAppService.Excluir(id);

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
