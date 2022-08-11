using Microsoft.AspNetCore.Identity;
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
    public class ClienteServicio: ITransactionService
    {
        RepositoriosUnit _RepositoriosUnit { get; }

         UserManager<Cliente> _UserManager { get; }

        public ClienteServicio(RepositoriosUnit repositorios, UserManager<Cliente> userManager)
        {
            _RepositoriosUnit = repositorios;
            _UserManager = userManager;
        }

        /// <summary>
        /// Elimina usuario por id
        /// </summary>
        /// <param name="idCliente"></param>
        /// <returns></returns>
        public async Task<Response> Delete<Tid>(Tid idCliente)
        {
            bool eliminado = await _RepositoriosUnit.ClienteRepositorio.Delete(idCliente);

            return Fabrica.GetResponse<Response>(eliminado);
        }

        
        public async Task<Response> Get(Expression<Func<Cliente,bool>> selector)
        {
            var clientes =await  _RepositoriosUnit.ClienteRepositorio.GetAll(selector);
            if(clientes is { Count:0})
            {
                return Fabrica.GetResponse<Response>(clientes,statusCode:404,message:"No encontrado");
            }
            return Fabrica.GetResponse<Response>(clientes);
        }
        /// <summary>
        /// obtiene cliente por id
        /// </summary>
        /// <param name="idCliente"></param>
        /// <returns></returns>
        public async Task<Response> Get<Tid>(Tid idCliente)
        {
            Cliente cliente = await _RepositoriosUnit.ClienteRepositorio.Get(idCliente);

           
           return Fabrica.GetResponse<Response>(cliente);
        }
        /// <summary>
        /// Crear un cliente mediante un modelo
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        public async Task<Response> Create<TCreate>(TCreate modelo)
        {
            CrearClienteModel model = modelo as CrearClienteModel;
            var res =await _RepositoriosUnit.PersonaRepositorio.GetAll(x => x.Identificacion == model.Identificacion);
            if(res is  {Count :>0})
            {
                var client = (await _RepositoriosUnit.ClienteRepositorio.GetAll<Persona>(incl=>incl.Persona,x => x.Persona.Identificacion==model.Identificacion)).FirstOrDefault();
                client.PasswordHash = "";
                return Fabrica.GetResponse<Response>(new CreateClienteResponseModel { Persona = res.FirstOrDefault(),Cliente  = client }, 400,"Identificacion ya existe",false);
            }


            var persona =await _RepositoriosUnit.PersonaRepositorio.Create(new Data.Entities.Persona { Edad = model.Edad, GeneroId = model.GeneroId, Habilitada = true, Identificacion = model.Identificacion, Nombre = model.Nombre, Telefono = model.Telefono, Direccion = model.Direccion });
            Cliente cliente = null;
            IdentityResult result = null;
            try
            {
               cliente = await _RepositoriosUnit.ClienteRepositorio.Create(new Data.Entities.Cliente { Identificacion = model.Identificacion, Estado = true, Edad = model.Edad, Email = model.Email, Nombre = model.Nombre, Telefono = model.Telefono, UserName = model.Email, PersonaId = persona.PersonaId, Direccion = model.Direccion });
               result =   await _UserManager.CreateAsync(cliente, model.Contraseña);
            }
            catch (Exception ex)
            {
                await  _RepositoriosUnit.PersonaRepositorio.Delete(persona.PersonaId);
                return Fabrica.GetResponse<ErrorServerResponse>(null, message: "Error al crear un cliente verifigue el log");
            }

            cliente.PasswordHash = "";
            return Fabrica.GetResponse<Response>(new CreateClienteResponseModel { Persona = persona, Cliente = cliente },success: result.Succeeded);
        }

       

        public async Task<Response> Update<T,Tid>(T model,Tid id)
        {
            Cliente modelo = model as Cliente;
            modelo = await _RepositoriosUnit.ClienteRepositorio.Update(modelo!, id);

            return Fabrica.GetResponse<Response>(modelo);
        }

        public async Task<Response> GetAll()
        {
            return Fabrica.GetResponse<Response>(await _RepositoriosUnit.ClienteRepositorio.GetAll());
        }
    }
}
