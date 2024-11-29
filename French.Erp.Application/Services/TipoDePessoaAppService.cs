using Dietcode.Core.DomainValidator;
using French.Erp.Application.ViewModel;
using French.Erp.Domain.Entities;
using French.Erp.Domain.Interfaces.Repository;
using French.Erp.Domain.Interfaces.Services;
using French.Erp.ViewModel.Interface;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace French.Erp.Application.Services
{
    public class TipoDePessoaAppService : BaseServiceApp<TipoDePessoaViewModel>, ITipoDePessoaAppService
    {
        private readonly ITipoDePessoaService service;
        private ValidationResult<TipoDePessoaViewModel> validationResult;

        public TipoDePessoaAppService(ITipoDePessoaService service, IUnitOfWork uow) : base(uow)
        {
            this.service = service;
            validationResult = new ValidationResult<TipoDePessoaViewModel>();
        }

        public async Task<ValidationResult<TipoDePessoaViewModel>> Gravar(TipoDePessoaViewModel tipoDePessoa)
        {
            BeginTransaction();
            var dadoIncluir = Mapper.Map<TipoDePessoa>(tipoDePessoa);
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
            validationResult.Retorno = Mapper.Map<TipoDePessoaViewModel>(retorno.Retorno);

            retorno.Erros.ToList().ForEach(e => validationResult.Add(e));
            return validationResult;


        }

        public async Task<ValidationResult<TipoDePessoaViewModel>> Excluir(int id)
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
            validationResult.Retorno = Mapper.Map<TipoDePessoaViewModel>(retorno.Retorno);

            retorno.Erros.ToList().ForEach(e => validationResult.Add(e));
            return validationResult;

        }

        public async Task<TipoDePessoaViewModel> ObterPorId(int id)
        {
            var tipoDePessoa = await service.ObterPorId(id);
            var retorno = Mapper.Map<TipoDePessoaViewModel>(tipoDePessoa);
            return retorno;
        }

        public async Task<IEnumerable<TipoDePessoaViewModel>> ObterTodos()
        {
            var tipoDePessoa = await service.ObterTodos();
            var retorno = Mapper.Map<IEnumerable<TipoDePessoaViewModel>>(tipoDePessoa);
            return retorno;

        }

    }
}
