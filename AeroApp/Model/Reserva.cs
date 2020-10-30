using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AeroApp.Model
{
    public class Reserva
    {
        public int Id { get; set; }

        public int VooId { get; set; }
        public Voo Voo { get; set; }

        public String Documento { get; set; }

        public int Poltrona { get; set; }

    }
}
