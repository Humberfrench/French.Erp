using Dietcode.Core.DomainValidator.Interfaces;
using French.Erp.ViewModel.ViewModel;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using System;
using System.IO;
using System.Linq;
using System.Security.Claims;
using System.Text.Json;

namespace French.Erp.Web.Controllers
{
    public class BaseController : Controller
    {
        private readonly IHttpContextAccessor context;
        private readonly int sessionTimeInMinutes;

        public BaseController(IHttpContextAccessor context)
        {
            this.context = context;

            IConfigurationRoot configuration = new ConfigurationBuilder()
               .SetBasePath(Directory.GetCurrentDirectory())
               .AddJsonFile("appsettings.json")
               .Build();
            sessionTimeInMinutes = Convert.ToInt32(configuration.GetSection("SessionTimeInMinutes").Value);

        }

        protected bool IsValid()
        {
            if (!User.Identity.IsAuthenticated)
            {
                return false;
            }
            if (UsuarioId == 0)
            {
                return false;

            }
            return true;
        }

        public UsuarioDto UsuarioViewModel
        {
            get
            {
                var user = context.HttpContext.User.FindFirst(ClaimTypes.UserData);
                if (user == null)
                {
                    return new UsuarioDto();
                }

                return JsonSerializer.Deserialize<UsuarioDto>(user.Value);
            }
        }

        protected int UsuarioId
        {
            get
            {
                var data = context.HttpContext.User.FindFirst(ClaimTypes.Sid);
                if (data == null)
                {
                    return 0;
                }

                return Convert.ToInt32(data.Value);
            }
        }

        protected int LoginName
        {
            get
            {
                var data = context.HttpContext.User.FindFirst(ClaimTypes.NameIdentifier);
                if (data == null)
                {
                    return 0;
                }

                return Convert.ToInt32(data.Value);
            }
        }

        protected string Nome
        {
            get
            {
                var data = context.HttpContext.User.FindFirst(ClaimTypes.Name);
                if (data == null)
                {
                    return "";
                }

                return data.Value;
            }
        }

        protected string PrimeiroNome
        {
            get
            {
                var data = context.HttpContext.User.FindFirst(ClaimTypes.GivenName);
                if (data == null)
                {
                    return "";
                }

                return data.Value;
            }
        }

        protected string Email
        {
            get
            {
                var data = context.HttpContext.User.FindFirst(ClaimTypes.GivenName);
                if (data == null)
                {
                    return "";
                }

                return data.Value;
            }
        }

        protected bool Admin
        {
            get
            {
                var data = context.HttpContext.User.FindFirst(ClaimTypes.Role);
                if (data == null)
                {
                    return false;
                }
                if (string.Equals(data.Value, "admin", StringComparison.CurrentCultureIgnoreCase))
                {
                    return true;
                }
                return false;
            }
        }

        protected int SessionTimeInMinutes => sessionTimeInMinutes;

        protected string RenderizeErros(IValidationResult resultValue) => resultValue.Erros.Select(itemErro =>
                $"- {itemErro.Message} <br />").Aggregate(string.Empty, (current, retornoTemp) => current + retornoTemp);

        //protected void GetUserData()
        //{
        //    ViewData["User"] = Nome;
        //    ViewData["Role"] = Admin ? "Administrador" : "Usuário";

        //}

    }
}

