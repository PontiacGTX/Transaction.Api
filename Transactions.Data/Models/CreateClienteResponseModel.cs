using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Transactions.Data.Entities;

namespace Transactions.Data.Models
{
    public class CreateClienteResponseModel
    {
        public Cliente Cliente { get; set; }
        public Persona Persona { get; set; }
    }
}
