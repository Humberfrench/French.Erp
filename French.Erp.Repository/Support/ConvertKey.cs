using Dapper;
using French.Erp.Domain.Entities.Support;
using French.Erp.Domain.Interfaces.Repository;
using French.Erp.Repository.Interfaces;
using System.Data;
using Microsoft.Data.SqlClient;
using Microsoft.EntityFrameworkCore;
using System.Linq;

namespace French.Erp.Repository.Support
{
    public class ConvertKey : IConvertKey
    {
        private readonly IContextManager contextManager;
        private readonly IDbConnection Connection;


        public ConvertKey(IContextManager contextManager)
        {
            this.contextManager = contextManager;
            Connection = new SqlConnection(contextManager.GetConnectionString);
        }

        public Chave Decript(byte[] chave)
        {
            var sql = @"Exec OpenKeys

                        SELECT dbo.Decrypt(@chave) as ChaveDecript

                        Exec CloseKeys";

            var result = Connection.Query<Chave>(sql, new { @chave = chave }).FirstOrDefault();
            if (result != null)
            {
                result.ChaveEncript = chave;
            }

            return result;

        }

        public Chave Encript(string chave)
        {
            var sql = @"Exec OpenKeys

                        SELECT dbo.Encrypt(@chave) as ChaveEncript

                        Exec CloseKeys";

            var result = Connection.Query<Chave>(sql, new { @chave = chave }).FirstOrDefault();
            if (result != null)
            {
                result.ChaveDecript = chave;
            }

            return result;

        }



    }
}
