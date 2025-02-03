using Dietcode.Core.DomainValidator;
using French.Erp.Application.DataObject;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace French.Erp.Application.Interfaces.Services
{
    public interface IFaturamentoService
    {
        Task<ValidationResult> Excluir(int id);
        Task<ValidationResult> Gravar(FaturamentoDto faturamentoDados);
        Task<FaturamentoDto> ObterPorId(int id);
        Task<List<FaturamentoDadosDto>> Obter(int usuario, int cliente = 0, int mes = 0, int ano = 0, bool faturado = true);
    }
}
