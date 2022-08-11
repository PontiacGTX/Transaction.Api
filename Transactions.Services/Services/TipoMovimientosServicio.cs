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
    public class TipoMovimientosServicio:ITransactionService
    {
        private RepositoriosUnit _Repositorio { get; }

        public TipoMovimientosServicio(RepositoriosUnit repositorio)
        {
            _Repositorio = repositorio;
        }
        public async Task<Response> Delete<Tid>(Tid id)
        {
            bool eliminado = await _Repositorio.TipoMovimientosRepositorio.Delete(id);

            return Fabrica.GetResponse<Response>(eliminado);
        }

        /// <summary>
        /// obtiene tipo de cuenta por id
        /// </summary>
        /// <param name="idTipoDeCuenta"></param>
        /// <returns></returns>
        public async Task<Response> Get<Tid>(Tid id)
        {
            var tipodeCuenta = await _Repositorio.TipoMovimientosRepositorio.Get(id);


            return Fabrica.GetResponse<Response>(tipodeCuenta);
        }
        /// <summary>
        /// Crear un tipo de cuenta mediante un modelo
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        public async Task<Response> Create<TCreate>(TCreate modelo)
        {
            TipoMovimientos model = modelo as TipoMovimientos;
            var res = await _Repositorio.TipoDeCuentasRepositorio.GetAll(x => x.Nombre==model.TipoMovimiento);
            if (res is { Count: > 0 })
            {
                return Fabrica.GetResponse<Response>(null, 400, $"Ya existe tipo de movimiento {model.TipoMovimiento}", false);
            }

            var tipoDeCuenta =await _Repositorio.TipoMovimientosRepositorio.Create(new TipoMovimientos { TipoMovimiento = model.TipoMovimiento });

            return Fabrica.GetResponse<Response>(new {  TipoDeCuenta = tipoDeCuenta });
        }


        public async Task<Response> Update<T, Tid>(T model, Tid id)
        {
            TipoMovimientos modelo = model as TipoMovimientos;
            modelo = await _Repositorio.TipoMovimientosRepositorio.Update(modelo!, id);

            return Fabrica.GetResponse<Response>(modelo);
        }

        public async Task<Response> GetAll()
        {
            return Fabrica.GetResponse<Response>(await _Repositorio.TipoMovimientosRepositorio.GetAll());
        }
    }
}
