using Microsoft.AspNetCore.Mvc;
using Transactions.Data.Common;

namespace Transaction.Api.Controllers
{
    public class HTTPControllerBase : ControllerBase
    {
        [ApiExplorerSettings(IgnoreApi = true)]
        public async  Task<IActionResult> HandleResponse(Response response)
        {
            return response.StatusCode switch
            {
                StatusCodes.Status200OK => Ok(response),
                StatusCodes.Status400BadRequest => BadRequest(response),
                StatusCodes.Status404NotFound => NotFound(response),
                _ => throw new Exception(response.Message),
            };
        }
        public async Task<IActionResult> Request<T1>(Func<Task<Response>> method)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            Response response = null;
            try
            {
                response = await method.Invoke();
                return await HandleResponse(response);

            }
            catch (Exception ex)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, Fabrica.GetResponse<ErrorServerResponse>(ex.Message, 500, message: "Ocurrio un Error inesperado", false)); ;
            }
        }


        public  async Task<IActionResult> Request<T>(T param,Func<T,Task<Response>> method )
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            Response response = null;
            try
            {
                response = await method.Invoke(param);
                return await HandleResponse(response);

            }
            catch (Exception ex)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, Fabrica.GetResponse<ErrorServerResponse>(ex.Message,500, message: "Ocurrio un Error inesperado", false)); ;
            }
        }
        public async Task<IActionResult> Request<T, TSecond>(T param, TSecond param2, Func<T, TSecond, Task<Response>> method)
        {

            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }


            Response response = null;
            try
            {
                response = await method.Invoke(param, param2);
                return await HandleResponse(response);

            }
            catch (Exception ex)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, Fabrica.GetResponse<ErrorServerResponse>(ex.Message, 500, message: "Ocurrio un Error inesperado", false)); ;
            }
        }

       
    }
    
}
