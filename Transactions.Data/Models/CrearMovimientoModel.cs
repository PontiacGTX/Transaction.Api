using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Transactions.Data.Models
{
    public class CrearMovimientoModel
    {
        public int CuentaId { get; set; }
        public int TipoMovimientoId { get; set; }
        public decimal Cantidad { get; set; }
    }
}
