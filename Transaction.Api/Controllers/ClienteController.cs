using Microsoft.AspNetCore.Mvc;
using System.ComponentModel.DataAnnotations;
using Transactions.Data.Common;
using Transactions.Data.Entities;
using Transactions.Data.Models;
using Transactions.Services.Services;

namespace Transaction.Api.Controllers
{
    [Route("[controller]")]
    [Controller]
    public class ClienteController : HTTPControllerBase
    {
        ClienteServicio _ClienteServicio { get; }

        private CuentaClienteServicio _CuentaClienteServicio { get; }

        private CuentaServicio _CuentaServicio { get; }

        public ClienteController(ClienteServicio clienteServicio,CuentaServicio cuentaServicio, CuentaClienteServicio cuentaClienteServicio)
        {
            _ClienteServicio = clienteServicio;
            _CuentaClienteServicio = cuentaClienteServicio;
            _CuentaServicio = cuentaServicio;
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> Get([FromRoute][Required] string id)
        {

            try
            {
                return await Request<string>(id, _ClienteServicio.Get);
            }
            catch (Exception ex)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, ex);
            }
        }

        [HttpGet("FindBy/email/{email}")]
        public async Task<IActionResult> GetClienteByEmail([FromRoute] string email)
        {
            try
            {
                var response =await _ClienteServicio.Get(x => x.Estado == true && x.Email == email);
                response.SetData((response.Data as IList<Cliente>)?.FirstOrDefault());
                return await HandleResponse(response);

            }
            catch (Exception ex)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, ex);
                throw;
            }
        }

        [HttpGet("Cliente/Identificacion/{identificacion}")]
        public async Task<IActionResult> GetClienteByIdentificacion([FromRoute] string identificacion)
        {
            try
            {
                var response = await _ClienteServicio.Get(x => x.Estado == true && x.Identificacion.ToLower() == identificacion);
                response.SetData((response.Data as IList<Cliente>)?.FirstOrDefault());
                return await HandleResponse(response);

            }
            catch (Exception ex)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, ex);
                throw;
            }
        }

        [HttpGet("Cliente/Name/{clienteNombre}")]
        public async Task<IActionResult> GetClienteByName([FromRoute] string clienteNombre)
        {
            try
            {
                var response = await _ClienteServicio.Get(x => x.Estado == true && x.Nombre.ToLower() == clienteNombre);
                response.SetData((response.Data as IList<Cliente>)?.FirstOrDefault());
                return await HandleResponse(response);

            }
            catch (Exception ex)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, ex);
                throw;
            }
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete([FromRoute]string id)
        {
            try
            {
                return await Request<string>(id, _ClienteServicio.Delete);
            }
            catch (Exception ex)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, ex);
            }
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> Update([FromBody]Cliente model,[FromRoute]string id)
        {
           

            try
            {
                return await Request<Cliente,string>(model,id, _ClienteServicio.Update);
            }
            catch (Exception ex)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, ex);
            }
        }

        [HttpPost]
        public async Task<IActionResult> Create([FromBody] CrearClienteModel model)
        {
           

            try
            {
                var cliente = (await _ClienteServicio.Create(model)).Data as CreateClienteResponseModel;

                
                return  Ok(Fabrica.GetResponse<Response>(cliente));
            }
            catch (Exception ex)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, ex);
            }
        }


    }
}
