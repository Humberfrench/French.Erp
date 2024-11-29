﻿using Dietcode.Core.DomainValidator;
using System.Collections.Generic;
using System.Threading.Tasks;
using French.Erp.Domain.Entities;
using French.Erp.Application.DataObject;

namespace French.Erp.Application.Interfaces.Services
{
    public interface ITarefaService 
    {
        Task<ValidationResult> Gravar(TarefaDto tarefaDados);
        Task<ValidationResult> Excluir(int id);
        Task<IEnumerable<TarefaDto>> ObterTodos();
        Task<TarefaDto> ObterPorId(int id);
        Task<IEnumerable<TarefaDto>> ObterTodosDoCliente(int clienteId);
        Task<string> ObterNumeroDaNota(int tarefaId);
    }
}
