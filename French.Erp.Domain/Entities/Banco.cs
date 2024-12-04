using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace French.Erp.Domain.Entities
{
    public partial class Banco
    {
        public int BancoId { get; set; }

        public string Codigo { get; set; }

        public string Nome { get; set; }

        public bool Status { get; set; }
    }
}
