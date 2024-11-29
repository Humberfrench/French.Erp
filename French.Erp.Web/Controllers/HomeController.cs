using Dietcode.Core.Lib;
using French.Erp.Web.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;

namespace French.Erp.Web.Controllers
{
    public class HomeController : BaseController
    {

        public HomeController(IHttpContextAccessor context) : base(context)
        {

        }


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
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Erro404()
        {
            return View("404");
        }
    }
}
