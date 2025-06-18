using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
#nullable enable

namespace French.Erp.Application.DataObject
{

    public class FeriadoDto
    {
        public FeriadoDto()
        {
            Nome = string.Empty;
        }

        public int FeriadoId { get; set; }
        public string Nome { get; set; }

        public byte Dia { get; set; }

        public byte Mes { get; set; }

        public short Ano { get; set; }

        public int CidadeId { get; set; }

        public int EstadoId { get; set; }

        public CidadeDto? Cidade { get; set; }

        public EstadoDto? Estado { get; set; }
    }
}
