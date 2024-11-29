﻿using Dietcode.Core.Lib;
using System.Collections.Generic;

namespace French.Erp.Web.Models
{
    public class ModelBasic<T, TItem>
    {
        public IList<TItem> Lista { get; set; } = new List<TItem>();
        public T ViewModel { get; set; }
        public SeletoresBasic Seletores { get; set; }
        public dynamic Valor1 { get; set; }
        public bool IsValid => Erro.IsNullOrEmptyOrWhiteSpace();
        public string Erro { get; set; }
        public string Nome { get; set; }
        public string Role { get; set; }
        public bool Admin { get; set; }

    }
}