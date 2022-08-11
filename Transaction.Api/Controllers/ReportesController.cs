using Microsoft.AspNetCore.Mvc;
using System.ComponentModel.DataAnnotations;
using Transactions.Data.Models;
using Transactions.Services.Services;

namespace Transaction.Api.Controllers
{
    [Controller]
    [Route("[controller]")]
    public class ReportesController : HTTPControllerBase
    {
        ReportesServicio _ReportesServicio { get; set; }
        public ReportesController(ReportesServicio reportesServicio)
        {
            _ReportesServicio = reportesServicio; 
        }

        [HttpGet("Cliente")]
        public async Task<IActionResult> GetReporte([Required][FromQuery] string clienteId, [Required][FromQuery] DateTime fechaInicio,[FromQuery] DateTime? fechaFinal)
        {
            try
            {
                return await Request(new 
                    ObtenerReporteClienteModel 
                     {
                        ClienteId = clienteId,
                        FechaInicio = fechaInicio, 
                        FechaFinal = fechaFinal
                     }, 
                    _ReportesServicio.ObtenerReporteCliente);
            }
            catch (Exception ex)
            {

                throw;
            }
        }
        [HttpGet("Cuenta")]
        public async Task<IActionResult> GetReporte([Required][FromQuery] int cuentaId, [Required][FromQuery] DateTime fechaInicio, [FromQuery] DateTime? fechaFinal)
        {
            try
            {
                return await Request(new
                    ObtenerReporteCuentaModel
                {
                    CuentaId = cuentaId,
                    FechaInicio = fechaInicio,
                    FechaFinal = fechaFinal
                },
                    _ReportesServicio.ObtenerReporteCuenta);
            }
            catch (Exception ex)
            {

                throw;
            }
        }

    }
}
