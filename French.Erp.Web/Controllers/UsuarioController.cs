﻿using French.Erp.ViewModel.Interface;
using French.Erp.ViewModel.ViewModel;
using French.Erp.Web.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Linq;
using System.Threading.Tasks;

namespace French.Erp.Web.Controllers
{
    public class UsuarioController : BaseController
    {
        private readonly IUsuarioAppService usuarioAppService;
        public UsuarioController(IHttpContextAccessor context, IUsuarioAppService usuarioAppService) : base(context)
        {
            this.usuarioAppService = usuarioAppService;
        }

        public async Task<IActionResult> Index()
        {
            var model = new ModelBasic<UsuarioViewModel>
            {
                Lista = (await usuarioAppService.ObterTodos()).ToList(),
                Nome = Nome,
                Role = Admin ? "Administrador" : "Usuário",
                Admin = Admin,
            };
            return View(model);
        }
    }
}
