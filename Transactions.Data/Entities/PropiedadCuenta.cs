using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Transactions.Data.Entities
{
    public class PropiedadCuenta: ITipoDeCuentaProperty
    {
        public int PropiedadCuentaId { get; set; }
        public string Nombre { get; set; }
        public List<TipoCuenta> TipoDeCuenta { get; set; }
    }
}
