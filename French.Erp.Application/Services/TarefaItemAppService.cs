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
    public class TarefaItemAppService : BaseServiceApp<TarefaItemViewModel>, ITarefaItemAppService
    {
        private readonly ITarefaItemService service;
        private ValidationResult<TarefaItemViewModel> validationResult;

        public TarefaItemAppService(ITarefaItemService service, IUnitOfWork uow) : base(uow)
        {
            this.service = service;
            validationResult = new ValidationResult<TarefaItemViewModel>();
        }

        public async Task<ValidationResult<TarefaItemViewModel>> Gravar(TarefaItemViewModel tarefa)
        {
            BeginTransaction();
            var dadoIncluir = Mapper.Map<TarefaItem>(tarefa);
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
            validationResult.Retorno = Mapper.Map<TarefaItemViewModel>(retorno.Retorno);

            retorno.Erros.ToList().ForEach(e => validationResult.Add(e));
            return validationResult;


        }

        public async Task<ValidationResult<TarefaItemViewModel>> Excluir(int id)
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
            validationResult.Retorno = Mapper.Map<TarefaItemViewModel>(retorno.Retorno);

            retorno.Erros.ToList().ForEach(e => validationResult.Add(e));
            return validationResult;


        }

        public async Task<TarefaItemViewModel> ObterPorId(int id)
        {
            var tarefa = await service.ObterPorId(id);
            var retorno = Mapper.Map<TarefaItemViewModel>(tarefa);
            return retorno;
        }

        public async Task<IEnumerable<TarefaItemViewModel>> ObterTodos()
        {
            var tarefa = await service.ObterTodos();
            var retorno = Mapper.Map<IEnumerable<TarefaItemViewModel>>(tarefa);
            return retorno;

        }
        public async Task<IEnumerable<TarefaItemViewModel>> ObterTodosItensDaTarefa(int tarefaId)
        {
            var tarefa = await service.ObterTodosItensDaTarefa(tarefaId);
            var retorno = Mapper.Map<IEnumerable<TarefaItemViewModel>>(tarefa);
            return retorno;

        }

    }
}
