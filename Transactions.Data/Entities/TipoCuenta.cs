using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Transactions.Data.Entities
{
    public class TipoCuenta
    {
        [Key]
        public int TipoCuentaId { get; set; }
        public string Nombre { get; set; }
        public int PropiedadCuentaId { get; set; }
        [ForeignKey("PropiedadCuentaId")]
        public PropiedadCuenta PropiedadCuenta { get; set; }
        public IList<Cuenta> Cuentas { get; set; }
        public bool Habilitado { get; set; }
    }
}
