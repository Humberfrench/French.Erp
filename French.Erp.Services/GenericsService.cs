using Dietcode.Core.DomainValidator;
using Dietcode.Core.Lib;
using French.Erp.Application.DataObject;
using French.Erp.Application.Interfaces.Repository;
using French.Erp.Application.Interfaces.Services;
using French.Erp.Domain.Entities;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace French.Erp.Services
{
    public class GenericsService : IGenericsService
    {
        private readonly ICidadeRepository cidadeRepository;
        private readonly IEstadoRepository estadoRepository;
        private readonly ValidationResult validationResult;

        public GenericsService(ICidadeRepository cidadeRepository,
                               IEstadoRepository estadoRepository)
        {
            this.cidadeRepository = cidadeRepository;
            this.estadoRepository = estadoRepository;
            validationResult = new ValidationResult();
        }

        public async Task<IEnumerable<EstadoDto>> ObterEstados()
        {
            return (await estadoRepository.ObterTodos()).ConvertObjects<List<EstadoDto>>();
        }
        public async Task<IEnumerable<CidadeDto>> ObterCidades(int uf)
        {
            return (await cidadeRepository.ObterCidades(uf)).ConvertObjects<List<CidadeDto>>();
        }

        public async Task<IEnumerable<CidadeDto>> ObterCidades()
        {
            return (await cidadeRepository.ObterTodos()).ConvertObjects<List<CidadeDto>>();
        }

    }
}
