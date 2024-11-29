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
    public class StatusNotaFiscalService : IStatusNotaFiscalService
    {
        private readonly IStatusNotaFiscalRepository statusNotaFiscalRepository;

        public StatusNotaFiscalService(IStatusNotaFiscalRepository statusNotaFiscalRepository)
        {
            this.statusNotaFiscalRepository = statusNotaFiscalRepository;
        }

        public async Task<ValidationResult> Excluir(int id)
        {
            var validationResult = new ValidationResult();
            var tipoDePessoa = await statusNotaFiscalRepository.ObterPorId(id);
            if (tipoDePessoa == null)
            {
                validationResult.Add("Status da Nota Fiscal inexistente");
                return validationResult;
            }

            await statusNotaFiscalRepository.Remover(tipoDePessoa);

            return validationResult;
        }

        public async Task<ValidationResult> Gravar(StatusNotaFiscalDto statusNotaFiscalDados)
        {
            var validationResult = new ValidationResult();
            //add or update
            if (statusNotaFiscalDados.StatusNotaFiscalId == 0)
            {
                var statusNotaFiscal = new StatusNotaFiscal()
                {
                    Descricao = statusNotaFiscalDados.Descricao
                };

                //validate
                if (!statusNotaFiscal.IsValid())
                {
                    return statusNotaFiscal.ValidationResult;
                }

                await statusNotaFiscalRepository.Adicionar(statusNotaFiscal);
            }
            else
            {
                var statusNotaFiscal = await statusNotaFiscalRepository.ObterPorId(statusNotaFiscalDados.StatusNotaFiscalId);
                statusNotaFiscal.Descricao = statusNotaFiscalDados.Descricao;

                //validate
                if (!statusNotaFiscal.IsValid())
                {
                    return statusNotaFiscal.ValidationResult;
                }

                await statusNotaFiscalRepository.Atualizar(statusNotaFiscal);
            }
            return validationResult;
        }


        public async Task<StatusNotaFiscalDto> ObterPorId(int id)
        {
            var statusNotaFiscal = await statusNotaFiscalRepository.ObterPorId(id);

            return statusNotaFiscal.ConvertObjects<StatusNotaFiscalDto>();
        }

        public async Task<List<StatusNotaFiscalDto>> ObterTodos()
        {
            var statusNotaFiscal = await statusNotaFiscalRepository.ObterTodos();

            return statusNotaFiscal.ConvertObjects<List<StatusNotaFiscalDto>>();
        }
    }
}
