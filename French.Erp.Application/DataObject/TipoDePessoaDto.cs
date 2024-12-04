using Newtonsoft.Json;
using System.Collections.Generic;

#nullable disable

namespace French.Erp.Application.DataObject
{
    public partial class TipoDePessoaDto
    {
        public TipoDePessoaDto()
        {
        }

        public byte TipoDePessoaId { get; set; }
        public string Descricao { get; set; }

    }
}