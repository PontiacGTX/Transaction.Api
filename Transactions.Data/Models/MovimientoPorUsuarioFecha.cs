using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Transactions.Data.Models
{
    public class MovimientoPorUsuarioFecha
    {
        public DateTime Fecha { get; set; }
        public string Cliente { get; set; }
        public int NumeroDeCuenta { get; set; }
        public string Tipo { get; set; }
        public bool Estado { get; set; }
        public decimal Movimiento { get; set; }
        public decimal SaldoDisponible { get; set; }
    }
}
