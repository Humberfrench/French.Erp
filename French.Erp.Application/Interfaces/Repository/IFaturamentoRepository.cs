using French.Erp.Application.DataObject;
using French.Erp.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Dietcode.Database.Domain;

namespace French.Erp.Application.Interfaces.Repository
{
    public interface IFaturamentoRepository : IBaseRepository<Faturamento>
    {
        Task<List<FaturamentoDadosDto>> Obter(int usuario, int cliente = 0, int mes = 0, int ano = 0, bool faturado = true);

    }
}
