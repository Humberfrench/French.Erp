using System.Collections.Generic;
using System.Text.Json.Serialization;

namespace French.Erp.Application.DataObject
{
    public partial class TipoDeClienteDto
    {
        public TipoDeClienteDto()
        {
        }

        public byte TipoDeClienteId { get; set; }
        public string Descricao { get; set; }

    }
}
