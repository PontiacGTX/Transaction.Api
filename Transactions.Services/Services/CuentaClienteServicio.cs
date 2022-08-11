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

namespace Transactions.Services.Services;

public class CuentaClienteServicio: ITransactionService
{
    RepositoriosUnit _RepositoriosUnit { get; }
    public CuentaClienteServicio(RepositoriosUnit repositorios)
    {
        _RepositoriosUnit = repositorios;
    }

    public async Task<Response> Get<Tid>(Tid id)
    {
        return Fabrica.GetResponse<Response>(await _RepositoriosUnit.CuentasClientesRepositorio.Get(id));
    }

    public async Task<Response> Delete<Tid>(Tid id)
    {
        var eliminado = await _RepositoriosUnit.CuentasClientesRepositorio.Delete(id);
        return Fabrica.GetResponse<Response>(eliminado,message: eliminado?"Ok":"Failed", success: eliminado) ;
    }

    public async Task<Response> Create<TCreate>(TCreate model)
    {
        var modelo = model as CreateCuentaClienteModel;

        var cuentaCliente = await _RepositoriosUnit.CuentasClientesRepositorio.Create(new CuentasClientes { Id = modelo.ClientId, CuentaId = modelo.CuentaId });

        return Fabrica.GetResponse<Response>(cuentaCliente);
    }

    public async Task<Response> Update<T, Tid>(T model, Tid id)
    {

        var cuentasClientes = await _RepositoriosUnit.CuentasClientesRepositorio.Update(model as CuentasClientes, id);

        return Fabrica.GetResponse<Response>(cuentasClientes);

    }

    public async Task<Response> GetAll(Expression<Func<CuentasClientes,bool>> getcuentaClienteSelector)
    {
        return Fabrica.GetResponse<Response>(await _RepositoriosUnit.CuentasClientesRepositorio.GetAll<Cuenta,Cliente>(x=>x.Cuenta,x=>x.Cliente,getcuentaClienteSelector));
    }

    public async Task<Response> GetAll()
    {
        return Fabrica.GetResponse<Response>(await _RepositoriosUnit.CuentasClientesRepositorio.GetAll());
    }
}