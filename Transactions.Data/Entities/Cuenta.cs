using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Transactions.Data.Entities;

public class Cuenta
{
    public int CuentaId { get; set; }
    public int TipoCuentaId  { get; set; }
    public TipoCuenta TipoCuenta { get; set; }
    public decimal SaldoInicial { get; set; }
    
    public bool Habilitada { get; set; }
    public IList<Movimientos> Movimientos { get; set; }
    public IList<CuentasClientes> CuentasClientes { get; set; }
}
