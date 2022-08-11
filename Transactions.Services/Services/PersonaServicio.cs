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
    public class PersonaServicio:ITransactionService
    {
        RepositoriosUnit _RepositoriosUnit { get; }
        public PersonaServicio(RepositoriosUnit repositorios)
        {
            _RepositoriosUnit = repositorios;
        }

        public async Task<Response> Get<Tid>(Tid id)
        {
            return Fabrica.GetResponse<Response>(await _RepositoriosUnit.PersonaRepositorio.Get(id));
        }

        public async Task<Response> Delete<Tid>(Tid id)
        {
            var eliminado = await _RepositoriosUnit.PersonaRepositorio.Delete(id);
            return Fabrica.GetResponse<Response>(eliminado);
        }

        public Task<Response> Create<TCreate>(TCreate model)
        {
            throw new NotImplementedException();
        }

        public async Task<Response> Update<T, Tid>(T model, Tid id)
        {
            Persona persona = model as Persona;
            persona =await _RepositoriosUnit.PersonaRepositorio.Update(persona!, id);

            return Fabrica.GetResponse<Response>(persona);
        }

        public async Task<Response> GetAll()
        {
            return Fabrica.GetResponse<Response>(await _RepositoriosUnit.PersonaRepositorio.GetAll());
        }
    }
}
