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
    public class PropiedadCuentaController : HTTPControllerBase
    {
        PropiedadCuentaServicio _PropiedadCuentaServicio { get; }

        private CuentaClienteServicio _CuentaClienteServicio { get; }

        private CuentaServicio _CuentaServicio { get; }

        public PropiedadCuentaController(PropiedadCuentaServicio propiedadCuentaServicio)
        {
            _PropiedadCuentaServicio = propiedadCuentaServicio;
        }

        [HttpGet]
        public async Task<IActionResult> GetAllPropiedadCuenta([FromRoute][Required] int id)
        {

            try
            {
                return await Request<IList<PropiedadCuenta>>(_PropiedadCuentaServicio.GetAll);
            }
            catch (Exception ex)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, ex);
            }
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> Get([FromRoute][Required] int id)
        {

            try
            {
                return await Request<int>(id, _PropiedadCuentaServicio.Get);
            }
            catch (Exception ex)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, ex);
            }
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete([FromRoute]int id)
        {
            try
            {
                return await Request<int>(id, _PropiedadCuentaServicio.Delete);
            }
            catch (Exception ex)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, ex);
            }
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> Update([FromBody]Cliente model,[FromRoute]int id)
        {
           

            try
            {
                return await Request<Cliente,int>(model,id, _PropiedadCuentaServicio.Update);
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
                var cliente = (await _PropiedadCuentaServicio.Create(model)).Data as CreateClienteResponseModel;

                
                return  Ok(Fabrica.GetResponse<Response>(cliente));
            }
            catch (Exception ex)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, ex);
            }
        }


    }
}
