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
    public class TarefaAppService : BaseServiceApp<TarefaViewModel>, ITarefaAppService
    {
        private readonly ITarefaService service;
        private ValidationResult<TarefaViewModel> validationResult;

        public TarefaAppService(ITarefaService service, IUnitOfWork uow) : base(uow)
        {
            this.service = service;
            validationResult = new ValidationResult<TarefaViewModel>();
        }

        public async Task<ValidationResult<TarefaViewModel>> Gravar(TarefaViewModel tarefa)
        {
            BeginTransaction();
            var dadoIncluir = Mapper.Map<Tarefa>(tarefa);
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
            validationResult.Retorno = Mapper.Map<TarefaViewModel>(retorno.Retorno);

            retorno.Erros.ToList().ForEach(e => validationResult.Add(e));
            return validationResult;


        }

        public async Task<ValidationResult<TarefaViewModel>> Excluir(int id)
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
            validationResult.Retorno = Mapper.Map<TarefaViewModel>(retorno.Retorno);

            retorno.Erros.ToList().ForEach(e => validationResult.Add(e));
            return validationResult;


        }

        public async Task<TarefaViewModel> ObterPorId(int id)
        {
            var tarefa = await service.ObterPorId(id);
            var retorno = Mapper.Map<TarefaViewModel>(tarefa);
            return retorno;
        }

        public async Task<IEnumerable<TarefaViewModel>> ObterTodos()
        {
            var tarefa = await service.ObterTodos();
            var retorno = Mapper.Map<IEnumerable<TarefaViewModel>>(tarefa);
            return retorno;

        }
        public async Task<IEnumerable<TarefaViewModel>> ObterTodosDoCliente(int clienteId)
        {
            var tarefa = await service.ObterTodosDoCliente(clienteId);
            var retorno = Mapper.Map<IEnumerable<TarefaViewModel>>(tarefa);
            return retorno;

        }
        public async Task<string> ObterNumeroDaNota(int tarefaId)
        {
            var retorno = await service.ObterNumeroDaNota(tarefaId);
            return retorno;

        }

    }
}
