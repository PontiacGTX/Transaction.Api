using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;
using Transactions.Data.Common;
using Transactions.Data.Entities;
using Transactions.Data.Models;
using Transactions.Repository;

namespace Transactions.Services.Services
{
    public class MovimientosServicio : ITransactionService
    {
        RepositoriosUnit _RepositoriosUnit { get; }
        public MovimientosServicio(RepositoriosUnit repositorios)
        {
            _RepositoriosUnit = repositorios;
        }
        public async Task<bool> PuedeRealizarMovimiento(Cuenta cuenta,TipoMovimientos tipoMovimiento, decimal cantidad )
        {
            string tipoMovimientoStr="";
            bool puedeRealizarMovimiento = true;
            if (cuenta.TipoCuenta.PropiedadCuenta.Nombre.ToLower() == "abonable")
            {
                tipoMovimientoStr = tipoMovimiento.TipoMovimiento.ToLower();

               
                if (tipoMovimientoStr == "debito")
                {
                    puedeRealizarMovimiento = (cuenta.SaldoInicial - cantidad) > 0;
                }
            }
            else if (cuenta.TipoCuenta.PropiedadCuenta.Nombre.ToLower() == "crediticia")
            {
                tipoMovimientoStr = tipoMovimiento.TipoMovimiento.ToLower();
                if (tipoMovimientoStr == "debito")
                {
                    //falta definir limite de credito...
                }
            }
            else
            {
                if (tipoMovimientoStr == "debito")
                {
                    puedeRealizarMovimiento = (cuenta.SaldoInicial - cantidad) > 0;
                }
            }
            return puedeRealizarMovimiento;
        }
        private  async Task<Movimientos> CrearNuevoMovimiento(Cuenta cuenta, TipoMovimientos tipoMovimiento,decimal cantidad, int cuentaId )
        {
            var tipoMovimientoStr = "";
            Movimientos mov = null;

            if (cuenta.TipoCuenta.PropiedadCuenta.Nombre.ToLower() == "abonable")
            {
                tipoMovimientoStr = tipoMovimiento.TipoMovimiento.ToLower();

                if (tipoMovimientoStr == "abono")
                {
                    var saldo =  Math.Abs(cantidad);
                    mov = new Movimientos { CuentaId = cuentaId, Fecha = DateTime.Now, Estado = true, Movimiento = saldo, TipoMovimientoId = tipoMovimiento.TipoMovimientoId };

                }
                else if (tipoMovimientoStr == "debito")
                {
                    var saldo = -1 * Math.Abs(cantidad);
                   
                    mov = new Movimientos { CuentaId = cuentaId, Fecha = DateTime.Now, Estado = true, Movimiento = saldo, TipoMovimientoId = tipoMovimiento.TipoMovimientoId };
                }
            }
            else if (cuenta.TipoCuenta.PropiedadCuenta.Nombre.ToLower() == "crediticia")
            {
                tipoMovimientoStr = tipoMovimiento.TipoMovimiento.ToLower();
                if (tipoMovimientoStr == "abono")
                {
                    var saldo = Math.Abs(cantidad);
                    mov = new Movimientos { CuentaId = cuentaId, Fecha = DateTime.Now, Estado = true, Movimiento = saldo, TipoMovimientoId = tipoMovimiento.TipoMovimientoId };

                }
                else if (tipoMovimientoStr == "debito")
                {
                    var saldo = (-1 * Math.Abs(cantidad));
                    mov = new Movimientos { CuentaId = cuentaId, Fecha = DateTime.Now, Estado = true, Movimiento = saldo, TipoMovimientoId = tipoMovimiento.TipoMovimientoId };
                }
            }

            return mov;
        }
        public async Task<Response> Get<Tid>(Tid id)
        {
            return Fabrica.GetResponse<Response>(await _RepositoriosUnit.MovimientosRepositorio.Get(id));
        }

        public async Task<Response> Delete<Tid>(Tid id)
        {
            return Fabrica.GetResponse<Response>(await _RepositoriosUnit.MovimientosRepositorio.Delete(id));
        }

        public async Task<Response> GetDailyMovimientos(Expression<Func<Movimientos,bool>> selector)
        {
            return Fabrica.GetResponse<Response>(await _RepositoriosUnit.MovimientosRepositorio.GetMovimientos(selector));
        }
        public async Task<Response> Create<TCreate>(TCreate model)
        {
            var movimientoModel = model as CrearMovimientoModel;
            DateTime today = DateTime.Today.Date;
            var tipoMovimientoDebito = (await _RepositoriosUnit.TipoMovimientosRepositorio.GetAll(x => x.TipoMovimiento.ToLower() == "debito")).FirstOrDefault();
            var movimientos = await GetDailyMovimientos(x => x.Fecha.Date == today && x.CuentaId == movimientoModel.CuentaId) as IList<Movimientos>;
           
            decimal? totalRetiro = movimientos?.Where(x => x.TipoMovimientoId == tipoMovimientoDebito.TipoMovimientoId).Select(x => Math.Abs(x.Movimiento)).Sum();
            
            if(totalRetiro is not null && totalRetiro > (decimal?)1000)
            {
                return Fabrica.GetResponse<Response>("No puede realizar mas de retiros  en total mayor a 1000 por dia", 400, "Cupo Diario Excedido", false);
            }

            var cuenta = (await _RepositoriosUnit.CuentaRepositorio.GetAll<TipoCuenta,PropiedadCuenta>(y=>y.TipoCuenta,t=>t.PropiedadCuenta,x => x.CuentaId == movimientoModel.CuentaId)).FirstOrDefault();
            if (cuenta == null)
            {
                return Fabrica.GetResponse<ErrorServerResponse>(cuenta, 404, "Cuenta no existe", false);
            }

            var tipoMovimiento = (await _RepositoriosUnit.TipoMovimientosRepositorio.Get(movimientoModel.TipoMovimientoId));
            if(tipoMovimiento == null)
            {
                return Fabrica.GetResponse<ErrorServerResponse>(tipoMovimiento, 404, "No pudo encontrar tipo de movimiento", false);
            }

            var movimiento = await CrearNuevoMovimiento(cuenta, tipoMovimiento, movimientoModel.Cantidad, movimientoModel.CuentaId);

            if (! await PuedeRealizarMovimiento(cuenta, tipoMovimiento, movimiento.Movimiento))
            {
                return Fabrica.GetResponse<Response>(null, 400, "Saldo no disponible", false);
            }
            var resultado =await _RepositoriosUnit.MovimientosRepositorio.Create(movimiento);
            decimal saldoInicial = cuenta.SaldoInicial;
            cuenta.SaldoInicial = cuenta.SaldoInicial + movimiento.Movimiento;

            try
            {
                cuenta = await _RepositoriosUnit.CuentaRepositorio.Update(cuenta, cuenta.CuentaId);
            }
            catch (Exception ex)
            {

            }

            return Fabrica.GetResponse<Response>(new CrearMovimientoResponseModel { Estado = cuenta.Habilitada, SaldoInicial =saldoInicial, Movimiento = $"{tipoMovimiento.TipoMovimiento} de {movimientoModel.Cantidad}", NumeroDeCuenta = cuenta.CuentaId, Tipo = cuenta.TipoCuenta?.Nombre },statusCode:201);

        }

        public async Task<Response> Update<T, Tid>(T model, Tid id)
        {
            Movimientos movimiento = model as Movimientos;
            movimiento =await  _RepositoriosUnit.MovimientosRepositorio.Update(movimiento, id);
            return Fabrica.GetResponse<Response>(movimiento);
        }

        public async Task<Response> GetAll()
        {
            return Fabrica.GetResponse<Response>(await _RepositoriosUnit.MovimientosRepositorio.GetAll());
        }
        public async Task<Response> GetAll(Expression<Func<Movimientos, bool>> selector)
        {
            var movimientos = await _RepositoriosUnit.MovimientosRepositorio.GetAll<TipoMovimientos, Cuenta, IList<CuentasClientes>, Cliente>(selector);
           
            return Fabrica.GetResponse<Response>(movimientos.GroupBy(x => x.Cuenta.CuentaId, x => x)
                .Select(x => x.Select(x => x).Select(y => new { Movimiento = y.Movimiento, y.Cuenta.CuentaId, y.Fecha, Tipo = y.Cuenta.TipoCuenta.Nombre, Cliente = y.Cuenta.CuentasClientes.FirstOrDefault().Cliente.Nombre })).ToList());
        }
    }
}
