using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Transactions.Data.Common
{
    public class Fabrica
    {
       public static Response GetResponse<T>(object response, int statusCode=200, string message="Ok",bool success=true)
            
        {
            var tipo = typeof(T);
            if (tipo == typeof(Response))
            {
                return new Response { Data = response, Message = message, StatusCode = statusCode, Success = success };
            }
            else if (tipo == typeof(ErrorServerResponse))
            {
                return new ErrorServerResponse { Data = null, Message = message, Success = false };
            }
            return null!;
        }
    }
}
