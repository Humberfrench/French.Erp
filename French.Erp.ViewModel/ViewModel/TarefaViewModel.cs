﻿// <auto-generated> This file has been auto generated by EF Core Power Tools. </auto-generated>
using System;
using System.Collections.Generic;
using French.Erp.ViewModel.Interface;

namespace French.Erp.Application.ViewModel
{
    public partial class TarefaViewModel: IViewModel
    {
        public TarefaViewModel()
        {
            ComposicaoNotaFiscal = new HashSet<ComposicaoNotaFiscalViewModel>();
            TarefaItem = new HashSet<TarefaItemViewModel>();
        }

        public int TarefaId { get; set; }
        public int ClienteId { get; set; }
        public int? NotaFiscalId { get; set; }
        public string Nome { get; set; }
        public string Observacao { get; set; }
        public decimal? ValorOrcado { get; set; }
        public decimal? TotalHoras { get; set; }
        public decimal? ValorDesconto { get; set; }
        public decimal? ValorBruto { get; set; }
        public decimal? ValorHora { get; set; }
        public decimal? ValorCobrado { get; set; }
        public decimal? Comissao { get; set; }
        public DateTime? DataInicio { get; set; }
        public DateTime? DataFim { get; set; }

        public virtual ClienteViewModel Cliente { get; set; }
        public virtual ICollection<ComposicaoNotaFiscalViewModel> ComposicaoNotaFiscal { get; set; }
        public virtual ICollection<TarefaItemViewModel> TarefaItem { get; set; }
    }
}