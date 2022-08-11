using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;
namespace Transactions.Data.Entities
{
     public class Genero
    {
        [Key]
        public int GeneroId { get; set; }
        public string Nombre { get; set; }
        public List<Persona> Personas { get; set; }
    }
}
