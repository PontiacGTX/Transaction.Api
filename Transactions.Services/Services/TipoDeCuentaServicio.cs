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
    public class TipoDeCuentaServicio:ITransactionService
    {
        private RepositoriosUnit _Repositorio { get; }

        public TipoDeCuentaServicio(RepositoriosUnit repositorio)
        {
            _Repositorio = repositorio;
        }
        public async Task<Response> Delete<Tid>(Tid id)
        {
            bool eliminado = await _Repositorio.TipoDeCuentasRepositorio.Delete(id);

            return Fabrica.GetResponse<Response>(eliminado);
        }

        /// <summary>
        /// obtiene tipo de cuenta por id
        /// </summary>
        /// <param name="idTipoDeCuenta"></param>
        /// <returns></returns>
        public async Task<Response> Get<Tid>(Tid id)
        {
            TipoCuenta tipodeCuenta = await _Repositorio.TipoDeCuentasRepositorio.Get(id);


            return Fabrica.GetResponse<Response>(tipodeCuenta);
        }
        /// <summary>
        /// Crear un tipo de cuenta mediante un modelo
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        public async Task<Response> Create<TCreate>(TCreate modelo)
        {
            CrearTipoDeCuentaModel model = modelo as CrearTipoDeCuentaModel;
            var res = await _Repositorio.TipoDeCuentasRepositorio.GetAll(x => x.Nombre==model.Nombre);
            if (res is { Count: > 0 })
            {
                return Fabrica.GetResponse<Response>(null, 400, $"Ya existe tipo de cuenta {model.Nombre}", false);
            }

            var tipoDeCuenta =await _Repositorio.TipoDeCuentasRepositorio.Create(new TipoCuenta { Habilitado = true, Nombre = model.Nombre });

            return Fabrica.GetResponse<Response>(new {  TipoDeCuenta = tipoDeCuenta });
        }


        public async Task<Response> Update<T, Tid>(T model, Tid id)
        {
            TipoCuenta modelo = model as TipoCuenta;
            modelo = await _Repositorio.TipoDeCuentasRepositorio.Update(modelo!, id);

            return Fabrica.GetResponse<Response>(modelo);
        }

        public async Task<Response> GetAll()
        {
            return Fabrica.GetResponse<Response>(await _Repositorio.TipoDeCuentasRepositorio.GetAll());
        }
    }
}
