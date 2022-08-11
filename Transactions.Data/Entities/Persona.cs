using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations.Schema;
namespace Transactions.Data.Entities
{
    public class Persona: IPersona
    {
        [Key]
        public int PersonaId { get; set; }
        public Cliente Cliente { get; set; }
        public bool Habilitada { get; set; }
        public string Nombre { get  ; set  ; }
        public int GeneroId { get  ; set  ; }
        [ForeignKey("GeneroId")]
        public Genero Genero { get; set; }
        public int Edad { get  ; set  ; }
        public string Identificacion { get  ; set  ; }
        public string Telefono { get  ; set  ; }
        public string Direccion { get ; set ; }
    }
}
