using Microsoft.AspNetCore.Mvc;
using System.ComponentModel.DataAnnotations;
using System.Linq.Expressions;
using Transactions.Data.Entities;
using Transactions.Data.Models;
using Transactions.Repository.Repositorios;
using Transactions.Services.Services;

namespace Transaction.Api.Controllers
{
    [Controller]
    [Route("[controller]")]
    public class MovimientosController : HTTPControllerBase
    {
        private MovimientosServicio _movimientoServicio { get; }

        public MovimientosController(MovimientosServicio movimientosServicio)
        {
            _movimientoServicio = movimientosServicio;
        }

        [HttpPost]
        public async Task<IActionResult> Crear([FromBody] CrearMovimientoModel model)
        {
            try
            {
                return await Request<CrearMovimientoModel>(model, _movimientoServicio.Create);
            }
            catch (Exception ex)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, ex);
            }
        }
        
        [HttpGet("Cuenta/{cuentaId}")]
        public async Task<IActionResult> GetMovimientosCliente([FromRoute][Required] int cuentaId)
        {
            try
            {
                var movimientos  = await _movimientoServicio.GetAll(x => x.CuentaId == cuentaId);
                return await  HandleResponse(movimientos);
            }
            catch (Exception ex)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, ex);
            }
        }

        [HttpGet("{idMovimiento}")]
        public async Task<IActionResult> GetCuentasCliente([FromRoute][Required] string idCliente)
        {

            try
            {
                return await Request<Expression<Func<Movimientos,bool>>>(x => x.Cuenta.CuentasClientes.FirstOrDefault(x=>x.Id ==idCliente)!=null, _movimientoServicio.GetAll);
            }
            catch (Exception ex)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, ex);
            }
        }

    }
}
