using Dietcode.Core.DomainValidator;
using Dietcode.Core.Lib;
using French.Erp.Application.DataObject;
using French.Erp.Application.Interfaces.Repository;
using French.Erp.Application.Interfaces.Services;
using French.Erp.Domain.Entities;
using System.Collections.Generic;
using System.Threading.Tasks;
using static Dietcode.Core.Lib.Extensions;

namespace French.Erp.Services
{
    public class TipoDeClienteService : ITipoDeClienteService
    {
        private readonly ValidationResult validationResult;
        private readonly ITipoDeClienteRepository tipoDeClienteRepository;

        public TipoDeClienteService(ITipoDeClienteRepository tipoDeClienteRepository)
        {
            this.tipoDeClienteRepository = tipoDeClienteRepository;
            validationResult = new ValidationResult();
        }

        public async Task<ValidationResult> Excluir(int id)
        {
            var tipoDeCliente = await tipoDeClienteRepository.ObterPorId(id);
            if (tipoDeCliente == null)
            {
                validationResult.Add("Tipo de Cliente inexistente");
                return validationResult;
            }

            await tipoDeClienteRepository.Remover(tipoDeCliente);

            return validationResult;
        }

        public async Task<ValidationResult> Gravar(TipoDeClienteDto tipoDeClienteDados)
        {

            //add or update
            if (tipoDeClienteDados.TipoDeClienteId == 0)
            {
                var tipoDeCliente = new TipoDeCliente()
                {
                    Descricao = tipoDeClienteDados.Descricao
                };

                //validate
                if (!tipoDeCliente.IsValid())
                {
                    return tipoDeCliente.ValidationResult;
                }

                await tipoDeClienteRepository.Adicionar(tipoDeCliente);
            }
            else
            {
                var tipoDeCliente = await tipoDeClienteRepository.ObterPorId(tipoDeClienteDados.TipoDeClienteId);
                tipoDeCliente.Descricao = tipoDeClienteDados.Descricao;

                //validate
                if (!tipoDeCliente.IsValid())
                {
                    return tipoDeCliente.ValidationResult;
                }

                await tipoDeClienteRepository.Atualizar(tipoDeCliente);
            }


            return validationResult;
        }

        public async Task<IEnumerable<TipoDeClienteDto>> ObterTodos()
        {
            var tipoDeClientes = await tipoDeClienteRepository.ObterTodos();

            //return tipoDeClientes.ConvertObjects<List<TipoDeClienteDto>>();
            return ConverterObjects<List<TipoDeClienteDto>>(tipoDeClientes);
        }

        Destiny ConverterObjects<Destiny>(object data) where Destiny : new()
        {
            string value = SerializeObject(data);
            Destiny result = new Destiny();
            try
            {
                result = DeserializeObject<Destiny>(value);
                return result;
            }
            catch
            {
                return result;
            }
        }

    }
}
