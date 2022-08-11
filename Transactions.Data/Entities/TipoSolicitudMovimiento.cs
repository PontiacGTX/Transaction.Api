using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Transactions.Data.Entities
{
    public class TipoSolicitudMovimiento
    {
        [Key]
        public int TipoSolicitudMovimientoId { get; set; }
        [Required]
        public string Nombre { get; set; }
    }
}
