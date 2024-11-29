using Dietcode.Core.DomainValidator;
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
    public class UsuarioAppService : BaseServiceApp<UsuarioViewModel>, IUsuarioAppService
    {
        private readonly IUsuarioService service;
        private ValidationResult<UsuarioViewModel> validationResult;

        public UsuarioAppService(IUsuarioService service, IUnitOfWork uow) : base(uow)
        {
            this.service = service;
            validationResult = new ValidationResult<UsuarioViewModel>();
        }

        public async Task<ValidationResult<UsuarioViewModel>> Gravar(UsuarioViewModel usuario)
        {
            BeginTransaction();
            var dadoIncluir = Mapper.Map<Usuario>(usuario);
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
            return validationResult;


        }

        public async Task<ValidationResult<UsuarioViewModel>> Excluir(int id)
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
            return validationResult;


        }

        public async Task<UsuarioViewModel> ObterPorId(int id)
        {
            var usuario = await service.ObterPorId(id);
            var retorno = Mapper.Map<UsuarioViewModel>(usuario);
            return retorno;
        }

        public async Task<IEnumerable<UsuarioViewModel>> ObterTodos()
        {
            var usuario = await service.ObterTodos();
            var retorno = Mapper.Map<IEnumerable<UsuarioViewModel>>(usuario);
            return retorno;

        }

        public async Task<ValidationResult<UsuarioViewModel>> Login(string login, string senha)
        {

            var usuario = await service.Login(login, senha);

            usuario.Erros.ToList().ForEach(e => validationResult.Add(e));

            validationResult.Retorno = Mapper.Map<UsuarioViewModel>(usuario.Retorno);

            return validationResult;

        }
        public async Task<ValidationResult<UsuarioViewModel>> AlterarSenha(int usuarioId, string senhaAnterior, string senhaNova)
        {
            BeginTransaction();
            var retorno = await service.AlterarSenha(usuarioId, senhaAnterior, senhaNova);
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
            return validationResult;

        }
    }
}
