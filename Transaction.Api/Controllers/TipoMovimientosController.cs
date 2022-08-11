using Microsoft.AspNetCore.Mvc;
using System.ComponentModel.DataAnnotations;
using Transactions.Data.Entities;
using Transactions.Data.Models;
using Transactions.Services.Services;

namespace Transaction.Api.Controllers
{
    [Controller]
    [Route("[controller]")]
    public class TipoMovimientosController : HTTPControllerBase
    {
        private TipoMovimientosServicio _TipoMovimientoServicio { get; }

        public TipoMovimientosController(TipoMovimientosServicio cuentaServicio)
        {
            _TipoMovimientoServicio = cuentaServicio;
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> Get([FromRoute][Required] int id)
        {

            try
            {
                return await Request<int>(id, _TipoMovimientoServicio.Get);
            }
            catch (Exception ex)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, ex);
            }
        }

        [HttpGet]
        public async Task<IActionResult> GetAllTipoSolicitudMovimiento()
        {

            try
            {
                return await Request<IList<Genero>>(_TipoMovimientoServicio.GetAll);
            }
            catch (Exception ex)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, ex);
            }
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> Update([FromBody] TipoMovimientos model, [FromRoute] int id)
        {

            try
            {
                return await Request<TipoMovimientos, int>(model, id, _TipoMovimientoServicio.Update);
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
                return await Request<int>(id, _TipoMovimientoServicio.Delete);
            }
            catch (Exception ex)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, ex);
            }
        }

        [HttpPost]
        public async Task<IActionResult> Create([FromBody] TipoMovimientos model)
        {

            try
            {
                return await Request<TipoMovimientos>(model, _TipoMovimientoServicio.Create);
            }
            catch (Exception ex)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, ex);
            }
        }
    }
}
