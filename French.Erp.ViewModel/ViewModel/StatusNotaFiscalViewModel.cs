﻿// <auto-generated> This file has been auto generated by EF Core Power Tools. </auto-generated>
using System;
using System.Collections.Generic;
using French.Erp.ViewModel.Interface;

#nullable disable

namespace French.Erp.Application.ViewModel
{
    public partial class StatusNotaFiscalViewModel : IViewModel
    {
        public StatusNotaFiscalViewModel()
        {
            NotaFiscal = new HashSet<NotaFiscalViewModel>();
        }

        public byte StatusNotaFiscalId { get; set; }
        public string Descricao { get; set; }

        public virtual ICollection<NotaFiscalViewModel> NotaFiscal { get; set; }
    }
}