using Dietcode.Core.DomainValidator;
using French.Erp.Application.Interfaces.Repository;
using French.Erp.Repository.Context;
using French.Erp.Repository.Interfaces;
using System;

namespace French.Erp.Repository.UnitOfWork
{
    public class UnitOfWork : IUnitOfWork
    {

        private readonly FrenchContext dbContext;
        private readonly ValidationResult validationResult;

        private bool _disposed;

        public UnitOfWork(IContextManager contextManager)
        {
            this.dbContext = contextManager.GetContext();
            validationResult = new ValidationResult();
        }

        public void BeginTransaction()
        {
            this._disposed = false;
        }
        public void Dispose()
        {
            this.Dispose(true);
            GC.SuppressFinalize(this);
        }

        public ValidationResult SaveChanges()
        {
            try
            {
                var dados = this.dbContext.SaveChanges();
            }
            //EntityValidationException
            catch (Exception ex)
            {
                if (ex.Message == "An error occurred while updating the entries. See the inner exception for details.")
                {
                    var inner = ex.InnerException;
                    if (inner != null)
                    {
                        if (inner.Message == "An error occurred while updating the entries. See the inner exception for details.")
                        {
                            var inner2 = inner.InnerException;
                            if (inner2 != null)
                            {
                                validationResult.Add(inner2.Message);
                            }
                        }
                        else
                        {
                            validationResult.Add(inner.Message);
                        }
                    }
                }
                else
                {
                    validationResult.Add(ex.Message);
                }
            }
            return validationResult;
        }

        protected virtual void Dispose(bool disposing)
        {
            if (!this._disposed)
            {
                if (disposing)
                {
                    this.dbContext.Dispose();
                }
            }
            this._disposed = true;
        }
    }
}
