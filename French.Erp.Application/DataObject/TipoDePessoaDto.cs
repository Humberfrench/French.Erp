using System;
using System.Collections.Generic;

#nullable disable

namespace French.Erp.Application.ViewModel
{
    public partial class TipoDePessoaDto
    {
        public TipoDePessoaDto()
        {
            Cliente = new HashSet<ClienteDto>();
        }

        public byte TipoDePessoaId { get; set; }
        public string Descricao { get; set; }

        public virtual ICollection<ClienteDto> Cliente { get; set; }
    }
}