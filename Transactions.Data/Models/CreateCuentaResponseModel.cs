using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace Transactions.Data.Models
{
    public class CreateCuentaResponseModel
    {
        [JsonPropertyName("Numero de Cuenta")]
        public int NumeroDeCuenta { get; set; }
        public string Tipo { get; set; }

        [JsonPropertyName("Saldo Inicial")]
        public decimal SaldoInicial { get; set; }
        public bool Estado { get; set; }
        public string Cliente { get; set; }
    }
}
