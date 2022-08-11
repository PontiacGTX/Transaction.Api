using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;
using Transactions.Data;
using Transactions.Data.Entities;
using Transactions.Repositories;

namespace Transactions.Repository.Repositorios
{
    public class ClienteRepositorio : IEntityRepository<Cliente>
    {
        public AppDbContext _ctx { get; set; }
        public ClienteRepositorio(AppDbContext ctx)
        {
            _ctx = ctx;
        }
        public async Task<Cliente> Create(Cliente Entity)
        {
            var res =await _ctx.Users.AddAsync(Entity);
            bool saved = await _ctx.SaveChangesAsync()>0;
            return saved ? res.Entity : null!;
        }

        public async Task<bool> Delete<Tid>(Tid id)
        {
           var cliente =await   _ctx.Users.FindAsync(id);

            if (cliente is null)
                return false;

            cliente.Estado = false;
            bool saved = await _ctx.SaveChangesAsync() > 0;

            return saved ? saved: await _ctx.Users.FindAsync(id)==null;
        }

        public async Task<Cliente> Get<TId>(TId id)
        {
            return (await _ctx.Users.FindAsync(id))!;
        }

        public async Task<IList<Cliente>> GetAll()
        {
            return await _ctx.Users.ToListAsync();
        }

        public async Task<IList<Cliente>> GetAll(System.Linq.Expressions.Expression<Func<Cliente, bool>> selector)
        {
         

            return await _ctx.Users.Include(x=>x.Persona)
                .ThenInclude(x=>x.Genero)
                .Where(selector)
                .ToListAsync();
        }

        public async Task<IList<Cliente>> GetAll<TIncludeProperty>(Expression<Func<Cliente, TIncludeProperty>> includeClause, Expression<Func<Cliente, bool>> selector)
        {
            return await  _ctx.Users.Include(includeClause).Where(selector).ToListAsync();
        }
       

        public async Task<Cliente> Update<Tid>(Cliente Entity, Tid id)
        {
            try
            {
                var cliente = await _ctx.Users.FindAsync(id);
                _ctx.Entry(cliente).CurrentValues.SetValues(Entity);
                await _ctx.SaveChangesAsync();
            }
            catch (Exception ex)
            {

                throw;
            }

            return (await _ctx.Users.FindAsync(id))!;
        }

    }
}
