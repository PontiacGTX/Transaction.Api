using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Transactions.Data.Common
{
    public class Response
    {
        public virtual int StatusCode { get; set; }
        public object Data { get; set; }
        public string Message { get; set; }
        public bool Success { get; set; }
        public Response SetData(object obj)
        {
            Data = obj;
            return this;
        }
    }
}
