using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Transactions.Data.Models
{
    public class CrearCuentaModel
    {
        public int TipoCuentaId { get; set; }
        public decimal SaldoInicial { get; set; }
        public string ClienteId { get; set; }
    }
}
