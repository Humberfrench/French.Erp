﻿// <auto-generated> This file has been auto generated by EF Core Power Tools. </auto-generated>
using System;
using System.Collections.Generic;

#nullable disable

namespace French.Erp.Domain.Entities
{
    public partial class NotaFiscal
    {
        public NotaFiscal()
        {
            ArquivoNotaFiscal = new HashSet<ArquivoNotaFiscal>();
            ComposicaoNotaFiscal = new HashSet<ComposicaoNotaFiscal>();
            TributoNotaFiscal = new HashSet<TributoNotaFiscal>();
        }

        public int NotaFiscalId { get; set; }
        public string Numero { get; set; }
        public int ClienteId { get; set; }
        public string CodigoVerificacao { get; set; }
        public DateTime Data { get; set; }
        public decimal Valor { get; set; }
        public decimal ImpostoTotalRetido { get; set; }
        public decimal ValorLiquido { get; set; }
        public string Descricao { get; set; }
        public byte StatusNotaFiscalId { get; set; }
        public int UsuarioId { get; set; }

        public virtual Cliente Cliente { get; set; }
        public virtual StatusNotaFiscal StatusNotaFiscal { get; set; }
        public virtual ICollection<ArquivoNotaFiscal> ArquivoNotaFiscal { get; set; }
        public virtual ICollection<ComposicaoNotaFiscal> ComposicaoNotaFiscal { get; set; }
        public virtual ICollection<TributoNotaFiscal> TributoNotaFiscal { get; set; }
    }
}