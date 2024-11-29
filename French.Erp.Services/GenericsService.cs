using Dietcode.Core.DomainValidator;
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
