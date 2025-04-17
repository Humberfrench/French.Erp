using Dapper;
using French.Erp.Application.Interfaces.Repository;
using French.Erp.Domain.Entities.Support;
using Microsoft.Data.SqlClient;
using Microsoft.Extensions.Configuration;
using System;
using System.Data;
using System.Linq;

namespace French.Erp.Repository.Support
{
    public class ConvertKey : IConvertKey, IDisposable  
    {
        private IDbConnection Connection;
        private bool disposedValue;

        public ConvertKey(IConfiguration configuration)
        {
            var connString = configuration.GetConnectionString("DbContextConnString");
            Connection = new SqlConnection(connString);
        }

        public Chave Decript(byte[] chave)
        {
            var sql = @"Exec OpenKeys

                        SELECT dbo.Decrypt(@chave) as ChaveDecript

                        Exec CloseKeys";

            Connection.Open();
            var result = Connection.Query<Chave>(sql, new { @chave = chave }).FirstOrDefault();
            if (result != null)
            {
                result.ChaveEncript = chave;
            }
            Connection.Close();

            return result;

        }

        public Chave Encript(string chave)
        {
            var sql = @"Exec OpenKeys

                        SELECT dbo.Encrypt(@chave) as ChaveEncript

                        Exec CloseKeys";

            Connection.Open();
            var result = Connection.Query<Chave>(sql, new { @chave = chave }).FirstOrDefault();
            if (result != null)
            {
                result.ChaveDecript = chave;
            }
            Connection.Close();

            return result;

        }

        protected virtual void Dispose(bool disposing)
        {
            if (!disposedValue)
            {
                if (disposing)
                {
                    Connection.Dispose();
                    Connection = null;
                }
                disposedValue = true;
            }
        }

        public void Dispose()
        {
            // Do not change this code. Put cleanup code in 'Dispose(bool disposing)' method
            Dispose(disposing: true);
            GC.SuppressFinalize(this);
        }
    }
}
