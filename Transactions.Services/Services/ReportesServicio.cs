using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Transactions.Data.Common;
using Transactions.Data.Entities;
using Transactions.Data.Models;
using Transactions.Repository;

namespace Transactions.Services.Services
{
    public class ReportesServicio
    {
        private RepositoriosUnit _Repositorios { get; }

        public ReportesServicio(Repository.RepositoriosUnit repositoriosUnit)
        {
            _Repositorios = repositoriosUnit;
        }
        public async Task<Response> ObtenerReporteCliente(ObtenerReporteClienteModel model)
        {
            var fechaFin = model.FechaFinal is null ? DateTime.Today.Date : (DateTime)model.FechaFinal?.Date;
            var reporte = (await _Repositorios.MovimientosRepositorio.GetMovimientos(x => x.Cuenta.CuentasClientes.Any(x => x.ClienteId == model.ClienteId) && x.Fecha.Date >= model.FechaInicio.Date && x.Fecha.Date <= fechaFin));
            if(reporte is { Count:0 })
            {
                return Fabrica.GetResponse<Response>(null, 404, "No se encontraron movimientos", true);
            }

            return Fabrica.GetResponse<Response>(reporte.Select(x => new { x.Fecha, x.Cuenta.CuentasClientes.First().Cliente.Persona.Nombre, x.Estado, x.Movimiento }));
        }
        public async Task<Response> ObtenerReporteCuenta(ObtenerReporteCuentaModel model)
        {
            var fechaFin = model.FechaFinal is null ? DateTime.Today.Date : (DateTime)model.FechaFinal?.Date;
            
            var movimientos =await _Repositorios.MovimientosRepositorio.GetMovimientos(x => 
            x.CuentaId == model.CuentaId &&
            x.Fecha.Date >= model.FechaInicio &&
            x.Fecha <= fechaFin);

            if(movimientos is { Count:0})
            {
                return Fabrica.GetResponse<Response>(Enumerable.Empty<object>(), 200);
            }

            var cuentasId = movimientos.Select(x => x.CuentaId).Distinct().ToList();
            Dictionary<int, Cuenta> cuentas = new Dictionary<int, Cuenta>();
            foreach(var cuentaId in cuentasId)
            {
                try
                {
                    var cuentaObj = await _Repositorios.CuentaRepositorio.Get(cuentaId);
                    if(!cuentas.TryGetValue(cuentaObj.CuentaId,out Cuenta cuenta))
                    {
                        cuentas.TryAdd(cuentaId, cuentaObj);
                    }
                }
                catch (Exception ex)
                {
                    //logger...
                }
            }

            
            return Fabrica.GetResponse<Response>(movimientos.Select(x =>
            {
                decimal cantidadAct = 0;
                if (cuentas.TryGetValue(x.CuentaId, out Cuenta cuenta))
                {
                    cantidadAct = cuenta.SaldoInicial;
                }

                return new MovimientoPorUsuarioFecha { Cliente = x.Cuenta.CuentasClientes?.FirstOrDefault()?.Cliente?.Nombre, Estado = x.Estado, NumeroDeCuenta = x.CuentaId, Fecha = x.Fecha, Movimiento = x.Valor, SaldoDisponible = cantidadAct };
            }));
        }
    }
}
