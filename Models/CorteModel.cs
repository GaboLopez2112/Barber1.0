using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BarberApp.Models
{
    public class CorteModel
    {
        public string formaPago { get; set; }
        public string? fotoComprobante { get; set; } // base64 o URL
        public decimal precio { get; set; }
        public string tipoCorte { get; set; }
        public int idBarbero { get; set; }
    }
}
