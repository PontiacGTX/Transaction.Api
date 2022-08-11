using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Transactions.Data.Entities;

public class Movimientos
{
    public int MovimientosId { get; set; }
    public DateTime Fecha { get; set; }
    public int TipoMovimientoId { get; set; }
    [ForeignKey("TipoMovimientoId")]
    public  TipoMovimientos TipoMovimiento { get; set; }
    public decimal Valor { get; set; }
    public decimal Movimiento { get; set; }
    public  int CuentaId { get; set; }
    [ForeignKey("CuentaId")]
    public Cuenta Cuenta { get; set; }
    public bool Estado { get; set; }
}
