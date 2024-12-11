using Dietcode.Core.Lib;
using French.Erp.Web.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;

namespace French.Erp.Web.Controllers
{
    [Route("[controller]")]
    public class HomeController : BaseController
    {

        public HomeController(IHttpContextAccessor context) : base(context)
        {

        }


        [HttpGet("")]
        public IActionResult Index()
        {
            if (!IsValid())
            {
                return RedirectToAction("Login", "Account");
            }
            var model = new DataSystem
            {
                Nome = $"{Nome.GetFirstAndLastName()}",
                Online = true,
                Role = Admin ? "Administrador" : "Usuário",
                Admin = Admin,
            };
            return View(model);

        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        [HttpGet("Error")]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        [HttpGet("404")]
        public IActionResult Erro404()
        {
            return View("404");
        }
    }
}
