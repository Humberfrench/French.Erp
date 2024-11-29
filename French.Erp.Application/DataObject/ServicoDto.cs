using System;
using System.Collections.Generic;

#nullable disable

namespace French.Erp.Application.DataObject
{
    public partial class ServicoDto
    {
        public ServicoDto()
        {
            TarefaItem = new HashSet<TarefaItemDto>();
        }

        public int ServicoId { get; set; }
        public string Nome { get; set; }
        public string Descricao { get; set; }

        public virtual ICollection<TarefaItemDto> TarefaItem { get; set; }
    }
}