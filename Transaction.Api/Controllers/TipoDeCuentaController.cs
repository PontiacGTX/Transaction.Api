using Microsoft.AspNetCore.Mvc;
using System.ComponentModel.DataAnnotations;
using Transactions.Data.Entities;
using Transactions.Data.Models;
using Transactions.Services.Services;

namespace Transaction.Api.Controllers
{
    [Controller]
    [Route("[controller]")]
    public class TipoDeCuentaController : HTTPControllerBase
    {
        private TipoDeCuentaServicio _TipoDeCuentaServicio { get; }

        public TipoDeCuentaController(TipoDeCuentaServicio cuentaServicio)
        {
            _TipoDeCuentaServicio = cuentaServicio;
        }

        [HttpGet]
        public async Task<IActionResult> GetAllTipoDeCuenta()
        {

            try
            {
                return await Request<IList<TipoCuenta>>(_TipoDeCuentaServicio.GetAll);
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
                return await Request<int>(id, _TipoDeCuentaServicio.Get);
            }
            catch (Exception ex)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, ex);
            }
        }

        

        [HttpPut("{id}")]
        public async Task<IActionResult> Update([FromBody] TipoCuenta model, [FromRoute] int id)
        {

            try
            {
                return await Request<TipoCuenta, int>(model, id, _TipoDeCuentaServicio.Update);
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
                return await Request<int>(id, _TipoDeCuentaServicio.Delete);
            }
            catch (Exception ex)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, ex);
            }
        }

        [HttpPost]
        public async Task<IActionResult> Create([FromBody] TipoCuenta model)
        {

            try
            {
                return await Request<TipoCuenta>(model, _TipoDeCuentaServicio.Create);
            }
            catch (Exception ex)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, ex);
            }
        }
    }
}
