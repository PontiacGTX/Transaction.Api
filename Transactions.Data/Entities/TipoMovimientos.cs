using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Transactions.Data.Entities;

public class TipoMovimientos
{
    [Key]
    public int TipoMovimientoId { get; set; }
    public string TipoMovimiento { get; set; }
    public IList<Movimientos> Movimientos { get; set; }
    public bool Habilitado { get; set; }
}

