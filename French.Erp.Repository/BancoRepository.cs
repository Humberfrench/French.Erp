﻿using Dietcode.Database.Domain;
using Dietcode.Database.Orm;
using Dietcode.Database.Orm.Context;
using French.Erp.Application.Interfaces.Repository;
using French.Erp.Domain.Entities;

namespace French.Erp.Repository
{
    public class BancoRepository : BaseRepository<Banco>, IBancoRepository, IBaseRepository<Banco>
    {
        public BancoRepository(IMyContextManager<ThisDatabase<Banco>> contextManager) : base(contextManager)
        {

        }
    }
}
