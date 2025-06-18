using Dietcode.Core.DomainValidator;
using Dietcode.Core.Lib;
using French.Erp.Application.DataObject;
using French.Erp.Application.Interfaces.Repository;
using French.Erp.Application.Interfaces.Services;
using French.Erp.Domain.Entities;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace French.Erp.Services
{
    public class LeadService : ILeadService
    {
        private readonly ILeadRepository leadRepository;
        private readonly IClienteRepository clienteRepository;

        public LeadService(ILeadRepository leadRepository, IClienteRepository clienteRepository)
        {
            this.leadRepository = leadRepository;
            this.clienteRepository = clienteRepository;
        }

        #region CriarCliente

        public async Task<ValidationResult> CriarCliente(LeadEntryDto leadEntryDto)
        {
            var retorno = await GetLead(leadEntryDto.LeadId);
            if (retorno.Invalid)
            {
                return retorno.Converter();
            }

            var cliente = retorno.Retorno.ToCliente(leadEntryDto.RazaoSocial, leadEntryDto.InscricaoEstadual,
                                                    leadEntryDto.CadastroMunicipal, leadEntryDto.Endereco,
                                                    leadEntryDto.Numero, leadEntryDto.Bairro, leadEntryDto.Complemento,
                                                    leadEntryDto.CidadeId.HasValue ? leadEntryDto.CidadeId.Value : 0,
                                                    leadEntryDto.EstadoId.HasValue ? leadEntryDto.EstadoId.Value : 0,
                                                    leadEntryDto.Cep);

            var retornoAdd = (await AddCliente(cliente));

            return retornoAdd;
        }

        public async Task<ValidationResult> CriarCliente(int id)
        {
            var retorno = await GetLead(id);
            if (retorno.Invalid)
            {
                return retorno.Converter();
            }

            var cliente = retorno.Retorno.ToCliente();

            var retornoAdd = (await AddCliente(cliente));

            return retorno.Converter();
        }

        async Task<ValidationResult> AddCliente(Cliente cliente)
        {
            var retorno = new ValidationResult();
            if (!cliente.IsValid())
            {
                retorno.GetErros(cliente.ValidationResult.Erros);
                return retorno;
            }
            await clienteRepository.Adicionar(cliente);

            return retorno;

        }

        async Task<ValidationResult<Lead>> GetLead(int id)
        {
            var retorno = new ValidationResult<Lead>();
            var lead = await leadRepository.ObterPorId(id);
            if (lead == null)
            {
                retorno.Add("Lead não encontrado.");
                return retorno;
            }

            retorno.Retorno = lead;
            return retorno;

        }

        #endregion

        public async Task<ValidationResult> Gravar(LeadDto LeadDados)
        {
            var validationResult = new ValidationResult();
            //add or update
            if (LeadDados.LeadId == 0)
            {
                var Lead = new Lead()
                {
                    Descricao = LeadDados.Descricao
                };

                //validate
                if (!Lead.IsValid())
                {
                    return Lead.ValidationResult;
                }

                await leadRepository.Adicionar(Lead);
            }
            else
            {
                var Lead = await leadRepository.ObterPorId(LeadDados.LeadId);
                Lead.Descricao = LeadDados.Descricao;

                //validate
                if (!Lead.IsValid())
                {
                    return Lead.ValidationResult;
                }

                await leadRepository.Atualizar(Lead);
            }
            return validationResult;
        }

        public async Task<LeadDto> ObterPorId(int id)
        {
            var Lead = await leadRepository.ObterPorId(id);

            return Lead.ConvertObjects<LeadDto>();
        }

        public async Task<List<LeadDto>> ObterTodos()
        {
            var Lead = await leadRepository.ObterTodos();

            return Lead.ConvertObjects<List<LeadDto>>();
        }
    }
}
