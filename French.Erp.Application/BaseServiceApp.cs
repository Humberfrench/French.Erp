using AutoMapper;
using Dietcode.Core.DomainValidator;
using French.Erp.Application.AutoMapper;
using French.Erp.Domain.Interfaces.Repository;
using French.Erp.ViewModel.Interface;
using System.Linq;
using System.Threading.Tasks;

namespace French.Erp.Application
{
    public class BaseServiceApp<T> : IBaseServiceApp where T: IViewModel, new()
    {
        private readonly IUnitOfWork uow;
        protected readonly IMapper Mapper;
        protected ValidationResult<T> baseValidationResult;

        public BaseServiceApp(IUnitOfWork uow)
        {
            this.uow = uow;
            AutoMapperConfig.RegisterMappings();
            Mapper = AutoMapperConfig.Config.CreateMapper();
            baseValidationResult = new ValidationResult<T>();
        }

        public void BeginTransaction()
        {
            uow.BeginTransaction();
        }

        public async Task Commit()
        {
            var retorno = await Task.Run(() => uow.SaveChanges());

            if (!retorno.Valid)
            {
                retorno.Erros.ToList().ForEach(e => baseValidationResult.Add(e.Message));
            }
        }

    }
}
