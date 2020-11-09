using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AeroApp.DTO
{
    public class VooDTO
    {
        public int Id { get; set; }
        public int IdOrigem { get; set; }
        public int IdDestino { get; set; }
        public DateTime DataIda { get; set; }
        public DateTime DataVolta { get; set; }
        public String Classe { get; set; }
        public int QtdPassageiros { get; set; }

    }
}
