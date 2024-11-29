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
    public class TributoService : ITributoService
    {
        private readonly ITributoRepository tributoRepository;
        private readonly ValidationResult validationResult;

        public TributoService(ITributoRepository tributoRepository)
        {
            this.tributoRepository = tributoRepository;
            validationResult = new ValidationResult();
        }

        public async Task<ValidationResult> Excluir(int id)
        {
            var tributo = await tributoRepository.ObterPorId(id);
            if (tributo == null)
            {
                validationResult.Add("Tributo inexistente");
                return validationResult;
            }

            await tributoRepository.Remover(tributo);

            return validationResult;
        }

        public async Task<ValidationResult> Gravar(TributoDto tributoDados)
        {
            var validationResult = new ValidationResult();
            //add or update
            if (tributoDados.TributoId == 0)
            {
                var tributo = new Tributo()
                {
                    Descricao = tributoDados.Descricao
                };

                //validate
                if (!tributo.IsValid())
                {
                    return tributo.ValidationResult;
                }

                await tributoRepository.Adicionar(tributo);
            }
            else
            {
                var tributo = await tributoRepository.ObterPorId(tributoDados.TributoId);
                tributo.Descricao = tributoDados.Descricao;

                //validate
                if (!tributo.IsValid())
                {
                    return tributo.ValidationResult;
                }

                await tributoRepository.Atualizar(tributo);
            }

            return validationResult;
        }

        public async Task<TributoDto> ObterPorId(int id)
        {
            var tipoDeClientes = await tributoRepository.ObterPorId(id);

            return tipoDeClientes.ConvertObjects<TributoDto>();
        }

        public async Task<IEnumerable<TributoDto>> ObterTodos()
        {
            var tipoDeClientes = await tributoRepository.ObterTodos();

            return tipoDeClientes.ConvertObjects<List<TributoDto>>();
        }
    }
}
