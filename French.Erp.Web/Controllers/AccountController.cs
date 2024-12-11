using Dietcode.Core.Lib;
using French.Erp.Application.DataObject;
using French.Erp.Application.Interfaces.Services;
using French.Erp.Web.Models;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Security.Claims;
using System.Text.Json;
using System.Threading.Tasks;

namespace French.Erp.Web.Controllers
{
    [Route("[controller]"), AllowAnonymous]
    public class AccountController : BaseController
    {
        private readonly IUsuarioService usuarioService;
        public AccountController(IUsuarioService usuarioService,
                                 IHttpContextAccessor context) : base(context)
        {
            this.usuarioService = usuarioService;
        }

        [AllowAnonymous, HttpGet("")]
        public IActionResult Login()
        {
            var model = new ModelBasic<Login>
            {
                Erro = "",
                ViewModel = new Login()
                {
                    Usuario = "",
                    Senha = "",
                    UsuarioReset = ""
                },
            };

            return View(model);
        }

        [HttpPost, AllowAnonymous]
        public async Task<IActionResult> Login(Login login)
        {
            var loginValidator = await usuarioService.Login(login.Usuario, login.Senha);
            if (!loginValidator.Valid)
            {
                var model = new ModelBasic<Login>
                {
                    Erro = RenderizeErros(loginValidator),
                    ViewModel = new Login()
                    {
                        Usuario = login.Usuario,
                        Senha = "",
                        UsuarioReset = login.UsuarioReset
                    },
                };
                return View("Index", model);
            }

            await AutenticarUsuario(loginValidator.Retorno);

            return RedirectToAction("Index", "Home");
        }

        [HttpPost, AllowAnonymous]
        public async Task<IActionResult> RecuperarSenha(Login login)
        {
            return View();
        }

        [NonAction]
        protected async Task AutenticarUsuario(UsuarioDto usuario)
        {

            var claims = new List<Claim>();
            claims.Add(new Claim(ClaimTypes.Sid, usuario.UsuarioId.ToString()));
            claims.Add(new Claim(ClaimTypes.NameIdentifier, usuario.Login));
            claims.Add(new Claim(ClaimTypes.Name, usuario.Nome));
            claims.Add(new Claim(ClaimTypes.UserData, JsonSerializer.Serialize(usuario)));
            claims.Add(new Claim(ClaimTypes.Email, usuario.Email));
            claims.Add(new Claim(ClaimTypes.MobilePhone, usuario.Celular));
            claims.Add(new Claim(ClaimTypes.GivenName, usuario.Nome.GetFirstName()));
            claims.Add(new Claim(ClaimTypes.Surname, usuario.Nome.GetLastName()));


            if (usuario.Admin)
            {
                claims.Add(new Claim(ClaimTypes.Role, "admin"));
            }
            else
            {
                claims.Add(new Claim(ClaimTypes.Role, "user"));
            }

            var identity = new ClaimsIdentity(claims, CookieAuthenticationDefaults.AuthenticationScheme);
            var tempoSessao = DateTimeOffset.Now.AddMinutes(SessionTimeInMinutes);
            var principal = new ClaimsPrincipal(identity);
            await HttpContext.SignInAsync(CookieAuthenticationDefaults.AuthenticationScheme, principal,
                                          new AuthenticationProperties()
                                          { IsPersistent = true, ExpiresUtc = tempoSessao });
        }

        [HttpGet("LogOff"), AllowAnonymous]
        public async Task<IActionResult> LogOff()
        {

            if (User.Identity.IsAuthenticated)
            {
                await HttpContext.SignOutAsync(CookieAuthenticationDefaults.AuthenticationScheme);
            }
            return RedirectToAction("Index");

        }

    }

}
