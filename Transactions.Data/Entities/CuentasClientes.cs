using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Transactions.Data.Entities;

public  class CuentasClientes
{
    [Key]
    public int CuentasClientesId { get; set; }
    [NotMapped]
    public string Id { get; set; }
    [ForeignKey("ClienteId")]
    public string ClienteId { get; set; }
    public Cliente Cliente { get; set; }
    [ForeignKey("CuentaId")]
    public int CuentaId { get; set; }
    public Cuenta Cuenta { get; set; }
    public bool Habilitado { get; set; }
}
