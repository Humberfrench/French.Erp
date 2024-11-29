using System;
using System.Collections.Generic;

#nullable disable

namespace French.Erp.Application.DataObject
{
    public partial class EstadoDto
    {
        public EstadoDto()
        {
            Cidade = new HashSet<CidadeDto>();
        }

        public short EstadoId { get; set; }
        /// <summary>
        /// UF
        /// </summary>
        public string SiglaUf { get; set; }
        /// <summary>
        /// Descricao
        /// </summary>
        public string NomeUf { get; set; }

        public virtual ICollection<CidadeDto> Cidade { get; set; }
    }
}