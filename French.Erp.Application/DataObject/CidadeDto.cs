using System;
using System.Collections.Generic;
using System.Text.Json;
using System.Text.Json.Serialization;

#nullable disable

namespace French.Erp.Application.ViewModel
{
    public partial class CidadeDto 
    {
        public CidadeDto()
        {
            Cliente = new HashSet<ClienteDto>();
        }

        /// <summary>
        /// Codigo
        /// </summary>
        public int CidadeId { get; set; }
        /// <summary>
        /// Nome
        /// </summary>
        public string Nome { get; set; }
        public short EstadoId { get; set; }

        [JsonIgnore]
        public virtual EstadoDto Estado { get; set; }
        [JsonIgnore]
        public virtual ICollection<ClienteDto> Cliente { get; set; }
    }
}