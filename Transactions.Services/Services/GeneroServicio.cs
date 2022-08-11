using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Transactions.Data.Common;
using Transactions.Data.Entities;
using Transactions.Repository;

namespace Transactions.Services.Services
{
    public class GeneroServicio:ITransactionService
    {
        RepositoriosUnit _RepositoriosUnit { get; }
        public GeneroServicio(RepositoriosUnit repositorios)
        {
            _RepositoriosUnit = repositorios;
        }

        public async Task<Response> Get<Tid>(Tid id)
        {
            return Fabrica.GetResponse<Response>(await _RepositoriosUnit.GeneroRepositorio.Get(id));
        }

        public async Task<Response> Delete<Tid>(Tid id)
        {
            var eliminado = await _RepositoriosUnit.GeneroRepositorio.Delete(id);
            return Fabrica.GetResponse<Response>(eliminado);
        }

        public Task<Response> Create<TCreate>(TCreate model)
        {
            throw new NotImplementedException();
        }

        public async Task<Response> Update<T, Tid>(T model, Tid id)
        {
            Genero persona = model as Genero;
            persona =await _RepositoriosUnit.GeneroRepositorio.Update(persona!, id);

            return Fabrica.GetResponse<Response>(persona);
        }

        public async Task<Response> GetAll()
        {
            return Fabrica.GetResponse<Response>(await _RepositoriosUnit.GeneroRepositorio.GetAll());
        }
    }
}
