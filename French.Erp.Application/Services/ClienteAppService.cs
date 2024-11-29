using Dietcode.Core.DomainValidator;
using French.Erp.Application.ViewModel;
using French.Erp.Domain.Entities;
using French.Erp.Domain.Interfaces.Repository;
using French.Erp.Domain.Interfaces.Services;
using French.Erp.ViewModel.Interface;
using French.Erp.ViewModel.ViewModel;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace French.Erp.Application.Services
{
    public class ClienteAppService : BaseServiceApp<ClienteViewModel>, IClienteAppService
    {
        private readonly IClienteService service;
        private ValidationResult<UsuarioViewModel> validationResult;

        public ClienteAppService(IClienteService service, IUnitOfWork uow) : base(uow)
        {
            this.service = service;
            validationResult = new ValidationResult<UsuarioViewModel>();
        }

        public async Task<ValidationResult<ClienteViewModel>> Gravar(ClienteViewModel cliente)
        {
            BeginTransaction();
            var dadoIncluir = Mapper.Map<Cliente>(cliente);
            var retorno = await service.Gravar(dadoIncluir);
            if (retorno.Valid)
            {
                //commit transaction
                await Commit();
                //commit error
                if (!baseValidationResult.Valid)
                {
                    return baseValidationResult;
                }
            }
            validationResult.Retorno = Mapper.Map<UsuarioViewModel>(retorno.Retorno);

            retorno.Erros.ToList().ForEach(e => validationResult.Add(e));
            return baseValidationResult;

        }

        public async Task<ValidationResult<ClienteViewModel>> Excluir(int id)
        {
            BeginTransaction();
            var retorno = await service.Excluir(id);
            if (retorno.Valid)
            {
                //commit transaction
                await Commit();
                //commit error
                if (!baseValidationResult.Valid)
                {
                    return baseValidationResult;
                }
            }
            validationResult.Retorno = Mapper.Map<UsuarioViewModel>(retorno.Retorno);

            retorno.Erros.ToList().ForEach(e => validationResult.Add(e));
            return baseValidationResult;

        }

        public async Task<ClienteViewModel> ObterPorId(int id)
        {
            var cliente = await service.ObterPorId(id);
            var retorno = Mapper.Map<ClienteViewModel>(cliente);
            return retorno;
        }

        public async Task<IEnumerable<ClienteViewModel>> ObterTodos()
        {
            var cliente = await service.ObterTodos();
            var retorno = Mapper.Map<IEnumerable<ClienteViewModel>>(cliente);
            return retorno;

        }

        public async Task<IEnumerable<ClienteDadosViewModel>> ObterTodosParaCombo()
        {
            var cliente = await service.ObterTodosParaCombo();
            var retorno = Mapper.Map<IEnumerable<ClienteDadosViewModel>>(cliente);
            return retorno;

        }
    }
}
