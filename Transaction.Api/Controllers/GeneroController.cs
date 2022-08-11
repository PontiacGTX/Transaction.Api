using Microsoft.AspNetCore.Mvc;
using System.ComponentModel.DataAnnotations;
using Transactions.Data.Entities;
using Transactions.Data.Models;
using Transactions.Services.Services;

namespace Transaction.Api.Controllers
{
    [Controller]
    [Route("[controller]")]
    public class GeneroController : HTTPControllerBase
    {
        private GeneroServicio _GeneroServicio { get; }

        public GeneroController(GeneroServicio cuentaServicio)
        {
            _GeneroServicio = cuentaServicio;
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> Get([FromRoute][Required] int id)
        {

            try
            {
                return await Request<int>(id, _GeneroServicio.Get);
            }
            catch (Exception ex)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, ex);
            }
        }

        [HttpGet]
        public async Task<IActionResult> GetAllGeneros()
        {

            try
            {
                return await Request<IList<Genero>>(_GeneroServicio.GetAll);
            }
            catch (Exception ex)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, ex);
            }
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> Update([FromBody] Genero model, [FromRoute] int id)
        {

            try
            {
                return await Request<Genero, int>(model, id, _GeneroServicio.Update);
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
                return await Request<int>(id, _GeneroServicio.Delete);
            }
            catch (Exception ex)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, ex);
            }
        }

        [HttpPost]
        public async Task<IActionResult> Create([FromBody] Genero model)
        {

            try
            {
                return await Request<Genero>(model, _GeneroServicio.Create);
            }
            catch (Exception ex)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, ex);
            }
        }
    }
}
