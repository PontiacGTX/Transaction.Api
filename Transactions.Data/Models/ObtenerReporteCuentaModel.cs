using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Transactions.Data.Models
{
    public class ObtenerReporteCuentaModel
    {
        public DateTime FechaInicio { get; set; }
        public DateTime? FechaFinal { get; set; }
        public int CuentaId { get; set; }

    }
}
