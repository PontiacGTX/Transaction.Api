using Microsoft.AspNetCore.Mvc;
using System.ComponentModel.DataAnnotations;
using System.Linq.Expressions;
using Transactions.Data.Entities;
using Transactions.Services.Services;

namespace Transaction.Api.Controllers
{
    [Controller]
    [Route("[controller]")]
    public class CuentasClienteController : HTTPControllerBase
    {
        private CuentaClienteServicio _cuentaClienteServicio { get; }

        public CuentasClienteController(CuentaClienteServicio cuentaClienteServicio)
        {
            _cuentaClienteServicio = cuentaClienteServicio;
        }

        [HttpGet("{idCliente}")]
        public async Task<IActionResult> GetCuentasCliente([FromRoute][Required] string idCliente)
        {

            try
            {
                return await Request<Expression<Func<CuentasClientes, bool>>>(x=>x.Id ==idCliente, _cuentaClienteServicio.GetAll);
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
                return await Request<int>(id, _cuentaClienteServicio.Get);
            }
            catch (Exception ex)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, ex);
            }
        }
    }
}
