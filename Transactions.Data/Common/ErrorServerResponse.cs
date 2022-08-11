using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Transactions.Data.Common
{
    public class ErrorServerResponse:Response
    {
        public override int StatusCode { get; set; } = 500;
    }
}
