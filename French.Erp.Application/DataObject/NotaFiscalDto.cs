﻿// <auto-generated> This file has been auto generated by EF Core Power Tools. </auto-generated>
using French.Erp.ViewModel.Interface;
using French.Erp.ViewModel.ViewModel;
using System;
using System.Collections.Generic;

#nullable disable

namespace French.Erp.Application.ViewModel
{
    public partial class NotaFiscalDto : IViewModel
    {
        public NotaFiscalDto()
        {
            ArquivoNotaFiscal = new HashSet<ArquivoNotaFiscalDto>();
            ComposicaoNotaFiscal = new HashSet<ComposicaoNotaFiscalDto>();
            TributoNotaFiscal = new HashSet<TributoNotaFiscalDto>();
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

        public virtual ClienteDto Cliente { get; set; }
        public virtual StatusNotaFiscalDto StatusNotaFiscal { get; set; }
        public virtual ICollection<ArquivoNotaFiscalDto> ArquivoNotaFiscal { get; set; }
        public virtual ICollection<ComposicaoNotaFiscalDto> ComposicaoNotaFiscal { get; set; }
        public virtual ICollection<TributoNotaFiscalDto> TributoNotaFiscal { get; set; }
    }
}