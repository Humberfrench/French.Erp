using Dietcode.Core.DomainValidator;
using French.Erp.Domain.Entities;
using French.Erp.Domain.Interfaces.Repository;
using French.Erp.Domain.Interfaces.Services;
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

        public async Task<IEnumerable<Estado>> ObterEstados()
        {
            return await estadoRepository.ObterTodos();
        }
        public async Task<IEnumerable<Cidade>> ObterCidades(int uf)
        {
            return await cidadeRepository.ObterCidades(uf);
        }

    }
}
