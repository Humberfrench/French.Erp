﻿// <auto-generated> This file has been auto generated by EF Core Power Tools. </auto-generated>
using System;
using System.Collections.Generic;
using French.Erp.ViewModel.Interface;

#nullable disable

namespace French.Erp.Application.ViewModel
{
    public partial class ServicoViewModel : IViewModel
    {
        public ServicoViewModel()
        {
            TarefaItem = new HashSet<TarefaItemViewModel>();
        }

        public int ServicoId { get; set; }
        public string Nome { get; set; }
        public string Descricao { get; set; }

        public virtual ICollection<TarefaItemViewModel> TarefaItem { get; set; }
    }
}