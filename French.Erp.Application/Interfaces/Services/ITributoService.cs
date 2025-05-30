﻿using Dietcode.Core.DomainValidator;
using French.Erp.Application.DataObject;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace French.Erp.Application.Interfaces.Services
{
    public interface ITributoService
    {
        Task<ValidationResult> Gravar(TributoDto tributo);
        Task<ValidationResult> Excluir(int id);
        Task<IEnumerable<TributoDto>> ObterTodos();
        Task<TributoDto> ObterPorId(int id);
    }
}
