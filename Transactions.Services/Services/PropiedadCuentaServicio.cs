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
    public class PropiedadCuentaServicio : ITransactionService
    {
        RepositoriosUnit _RepositoriosUnit { get; }
        public PropiedadCuentaServicio(RepositoriosUnit repositorios)
        {
            _RepositoriosUnit = repositorios;
        }

        /// <summary>
        /// Elimina usuario por id
        /// </summary>
        /// <param name="idCliente"></param>
        /// <returns></returns>
        public async Task<Response> Delete<Tid>(Tid id)
        {
            bool eliminado = await _RepositoriosUnit.PropiedadCuentaRepositorio.Delete(id);

            return Fabrica.GetResponse<Response>(eliminado);
        }

        /// <summary>
        /// obtiene cliente por id
        /// </summary>
        /// <param name="idCliente"></param>
        /// <returns></returns>
        public async Task<Response> Get<Tid>(Tid id)
        {
            PropiedadCuenta cliente = await _RepositoriosUnit.PropiedadCuentaRepositorio.Get(id);

           
           return Fabrica.GetResponse<Response>(cliente);
        }
        /// <summary>
        /// Crear un cliente mediante un modelo
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        public async Task<Response> Create<TCreate>(TCreate model)
        {
            PropiedadCuenta modelo = model as PropiedadCuenta;
            modelo = await _RepositoriosUnit.PropiedadCuentaRepositorio.Create(modelo);

            return Fabrica.GetResponse<Response>(modelo);
        }

       

        public async Task<Response> Update<T, Tid>(T model, Tid id)
        {
            PropiedadCuenta modelo = model as PropiedadCuenta;
            modelo = await _RepositoriosUnit.PropiedadCuentaRepositorio.Update(modelo!, id);

            return Fabrica.GetResponse<Response>(modelo);
        }

        public async Task<Response> GetAll()
        {
            return Fabrica.GetResponse<Response>(await _RepositoriosUnit.PropiedadCuentaRepositorio.GetAll());
        }
    }
}
