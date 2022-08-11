using Microsoft.AspNetCore.Mvc;
using System.ComponentModel.DataAnnotations;
using System.Linq.Expressions;
using Transactions.Data.Entities;
using Transactions.Data.Models;
using Transactions.Services.Services;

namespace Transaction.Api.Controllers
{
    [Controller]
    [Route("[controller]")]
    public class CuentaController : HTTPControllerBase
    {
        private CuentaServicio _CuentaServicio { get; }

        private ClienteServicio _ClienteServicio;
        private CuentaClienteServicio _CuentaClienteServicio { get; }

        public CuentaController(ClienteServicio clienteServicio,CuentaServicio cuentaServicio, CuentaClienteServicio cuentaClienteServicio)
        {
            _CuentaServicio = cuentaServicio;
            _ClienteServicio = clienteServicio;
            _CuentaClienteServicio = cuentaClienteServicio;
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> Get([FromRoute][Required] int id)
        {

            try
            {
                return await Request<int>(id, _CuentaServicio.Get);
            }
            catch (Exception ex)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, ex);
            }
        }

        [HttpGet("Cliente/Identificacion/{identificacion}")]
        public async Task<IActionResult> GetCuentaClientePorIdentificacion([FromRoute] string identificacion)
        {
            try
            {
                var cuentas = await _CuentaServicio.GetAll(x => x.Cliente.Identificacion==identificacion);
                return await HandleResponse(cuentas);
            }
            catch (Exception ex)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, ex);
            }
        }

        [HttpGet("Cliente/Nombre/{nombreCliente}/TipoCuenta/{tipoCuentaId}")]
        public async Task<IActionResult> GetCuentaClientePorIdentificacion([FromRoute] string nombreCliente, [FromRoute]int tipoCuentaId)
        {
            try
            {
                nombreCliente = nombreCliente.ToLower();
                var cuentas = await _CuentaServicio.GetAll(x => x.Cliente.Nombre ==  nombreCliente && x.Cuenta.TipoCuentaId == tipoCuentaId);
                return await HandleResponse(cuentas);
            }
            catch (Exception ex)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, ex);
            }
        }
        [HttpPut("{id}")]
        public async Task<IActionResult> Update([FromBody] Cuenta model, [FromRoute] int id)
        {

            try
            {
                return await Request<Cuenta, int>(model, id, _CuentaServicio.Update);
            }
            catch (Exception ex)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, ex);
            }
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete([FromRoute] int id)
        {
            try
            {
                return await Request<int>(id, _CuentaServicio.Delete);
            }
            catch (Exception ex)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, ex);
            }
        }

        [HttpPost]
        public async Task<IActionResult> Create([FromBody] CrearCuentaModel model)
        {

            try
            {
                return await Request(model, _CuentaServicio.Create);
            }
            catch (Exception ex)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, ex);
            }
        }
    }
}
