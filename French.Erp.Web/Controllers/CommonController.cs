using Dietcode.Core.DomainValidator.Interfaces;
using French.Erp.Application.DataObject;
using French.Erp.Application.Interfaces.Services;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.Extensions.Configuration;
using System;
using System.IO;
using System.Linq;
using System.Security.Claims;
using System.Text.Json;
using System.Threading.Tasks;

namespace French.Erp.Web.Controllers
{
    public class CommonController : BaseController
    {
        private readonly IGenericsService genericService;
        private readonly IClienteService clienteService;
        private readonly ITipoDePessoaService tipoDePessoaService;
        private readonly ITipoDeClienteService tipoDeClienteService;

        public CommonController(IGenericsService genericService,
                                ITipoDePessoaService tipoDePessoaService,
                                ITipoDeClienteService tipoDeClienteService,
                                IClienteService clienteService,
                                IHttpContextAccessor context) : base(context)
        {
        }
        #region Endpoints Comuns

        [HttpGet("ObterCidades/{id}")]
        public async Task<IActionResult> ObterCidades(int id)
        {
            var dados = await genericService.ObterCidades(id);
            return Json(dados);

        }

        [NonAction]
        public async Task<SelectList> ObterTipoDeClienteParaCombo()
        {
            var dados = await tipoDeClienteService.ObterTodos();
            var dadosSelect = new SelectList(dados, "TipoDeClienteId", "Descricao");

            return dadosSelect;
        }

        [NonAction]
        public async Task<SelectList> ObterTipoDePessoaParaCombo()
        {
            var dados = await tipoDePessoaService.ObterTodos();
            var dadosSelect = new SelectList(dados, "TipoDePessoaId", "Descricao");

            return dadosSelect;
        }

        [NonAction]
        public async Task<SelectList> ObterEstadosParaCombo()
        {
            var dados = await genericService.ObterEstados();
            var dadosSelect = new SelectList(dados, "EstadoId", "NomeUf");

            return dadosSelect;
        }
        [NonAction]
        public async Task<SelectList> ObterClienteParaCombo()
        {
            var dados = await clienteService.ObterTodosParaCombo();
            var dadosSelect = new SelectList(dados, "ClienteId", "NomeCompleto");

            return dadosSelect;
        }


        #endregion

    }
}
