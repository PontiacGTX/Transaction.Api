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
    public class CuentaServicio:ITransactionService
    {
        RepositoriosUnit _RepositoriosUnit { get; }
        public CuentaServicio(RepositoriosUnit repositoriosUnit)
        {
            _RepositoriosUnit = repositoriosUnit;
        }

        public async Task<Response> Get<Tid>(Tid id)
        {
            var cuenta = await _RepositoriosUnit.CuentaRepositorio.Get(id);

            return Fabrica.GetResponse<Response>(cuenta);
        }

        public async Task<Response> Delete<Tid>(Tid id)
        {
            var eliminado = _RepositoriosUnit.CuentaRepositorio.Delete(id);

            return Fabrica.GetResponse<Response>(eliminado);
        }

        public async Task<Response> Create<TCreate>(TCreate model)
        {
            CrearCuentaModel modelo = model as CrearCuentaModel;
            var cliente =await _RepositoriosUnit.ClienteRepositorio.Get(modelo.ClienteId);
            if(cliente is null)
            {
                return Fabrica.GetResponse<Response>(cliente,400, message: "Cliente no existe", success: false);
            }
            var tipodeCuenta = await _RepositoriosUnit.TipoDeCuentasRepositorio.Get(modelo.TipoCuentaId);
            if(tipodeCuenta is null)
            {
                return Fabrica.GetResponse<Response>(cliente,400, message: "Tipo de cuenta no existe", success: false);
            }
          
            
            var cuenta =  await   _RepositoriosUnit.CuentaRepositorio.Create(new Cuenta { Habilitada = true, SaldoInicial = modelo.SaldoInicial, TipoCuentaId = modelo.TipoCuentaId });
            if (cuenta is null)
            {
                return Fabrica.GetResponse<Response>(cuenta, 500, "Error creando cuenta", false);
            }
            var cuentacCliente = await _RepositoriosUnit.CuentasClientesRepositorio.Create(new CuentasClientes { CuentaId = cuenta.CuentaId, ClienteId = modelo.ClienteId, Habilitado = true });
            
            return Fabrica.GetResponse<Response>(new CreateCuentaResponseModel {  Cliente = cuentacCliente.Cliente.Nombre, Estado = cuenta.Habilitada, NumeroDeCuenta = cuenta.CuentaId, SaldoInicial =cuenta.SaldoInicial, Tipo = cuenta.TipoCuenta?.Nombre  });

        }
        public async Task<Response> GetAll(Expression<Func<CuentasClientes,bool>> selector)
        {
           var cuentasCliente =await  _RepositoriosUnit.CuentasClientesRepositorio.GetAll<Cuenta, Cliente>(x => x.Cuenta, x => x.Cliente, selector);
            if(cuentasCliente is { Count:0})
            {
                return Fabrica.GetResponse<Response>(cuentasCliente, 404, "No se ha Encontrado Ninguna cuenta");
            }
            return Fabrica.GetResponse<Response>(cuentasCliente);
        }

        public async Task<Response> Update<T, Tid>(T model, Tid id)
        {
            Cuenta cuenta = model as Cuenta;
            try
            {

                cuenta = await _RepositoriosUnit.CuentaRepositorio.Update(cuenta, id);
            }
            catch (Exception ex)
            {

                throw;
            }

            return Fabrica.GetResponse<Response>(cuenta);
        }

        public async Task<Response> GetAll()
        {
            return Fabrica.GetResponse<Response>(await _RepositoriosUnit.CuentaRepositorio.GetAll());
        }
    }
}
