using System;
using System.Collections.Generic;

#nullable disable

namespace French.Erp.Application.DataObject
{
    public partial class TarefaItemDto
    {
        public int TarefaItemId { get; set; }
        public int TarefaId { get; set; }
        public byte Ordem { get; set; }
        public string Descricao { get; set; }
        public int ServicoId { get; set; }
        public DateTime? Data { get; set; }
        public decimal HorasOrcadas { get; set; }
        public decimal HorasGastas { get; set; }
        public decimal ValorHora { get; set; }
        public decimal ValorItem { get; set; }

        public virtual ServicoDto Servico { get; set; }
        public virtual TarefaDto Tarefa { get; set; }
    }
}