using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;

namespace French.Erp.Application.DataObject
{
    public class BancoDto
    {
        [Required]
        public int BancoId { get; set; }

        [Required, StringLength(10)]
        public string Codigo { get; set; }

        [Required, StringLength(150)]
        public string Nome { get; set; }

        [Required]
        public bool Status { get; set; }
    }
}
