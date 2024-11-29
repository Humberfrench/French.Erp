﻿using French.Erp.Application.DataObject;
using French.Erp.Application.Interfaces.Services;
using French.Erp.Web.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Linq;
using System.Threading.Tasks;

namespace French.Erp.Web.Controllers
{
    public class UsuarioController : BaseController
    {
        private readonly IUsuarioService usuarioAppService;
        public UsuarioController(IHttpContextAccessor context, IUsuarioService usuarioAppService) : base(context)
        {
            this.usuarioAppService = usuarioAppService;
        }

        public async Task<IActionResult> Index()
        {
            var model = new ModelBasic<UsuarioDto>
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
