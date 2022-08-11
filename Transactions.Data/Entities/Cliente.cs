using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Transactions.Data.Entities;

[Table("Clientes")]
public class Cliente : IdentityUser,IPersona
{
   
    public bool Estado { get; set; }
    
    public string Nombre { get; set; }
    public int Edad { get; set; }
    public string Identificacion { get; set; }
    public string Telefono { get; set; }
    public IList<CuentasClientes> CuentasClientes { get; set; }
    [ForeignKey("PersonaId")]
    public int PersonaId { get; set; }
    public Persona Persona { get; set; }
    public string Direccion { get ; set ; }
}
