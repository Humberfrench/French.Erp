﻿// <auto-generated> This file has been auto generated by EF Core Power Tools. </auto-generated>
using System;
using System.Collections.Generic;

#nullable disable

namespace French.Erp.Domain.Entities
{
    public partial class ComposicaoNotaFiscal
    {
        public int ComposicaoNotaFiscalId { get; set; }
        public int NotaFiscalId { get; set; }
        public int TarefaId { get; set; }
        public decimal Total { get; set; }

        public virtual NotaFiscal NotaFiscal { get; set; }
        public virtual Tarefa Tarefa { get; set; }
    }
}