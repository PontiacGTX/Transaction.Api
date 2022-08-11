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
    public class GeneroRepositorio : IEntityRepository<Genero>
    {
        private AppDbContext _ctx { get; }

        public GeneroRepositorio(AppDbContext ctx)
        {
            _ctx = ctx;
        }
        public async Task<Genero> Create(Genero Entity)
        {
            bool saved = false;
            try
            {
                var res = _ctx.Generos.Add(Entity);
                saved = await _ctx.SaveChangesAsync() > 0;
                return saved ? res.Entity : null!;
            }
            catch (Exception ex)
            {

                throw;
            }
        }

        public async Task<bool> Delete<Tid>(Tid id)
        {
             var persona = await _ctx.Generos.FindAsync(id);

            if (persona is null)
                return true;

            await _ctx.SaveChangesAsync();
            return (await _ctx.Generos.FindAsync(id)) == null;
        }

        public async Task<Genero> Get<TId>(TId id)
        {
            return await _ctx.Generos.FindAsync(id);
        }

        public async Task<IList<Genero>> GetAll()
        {
            return await _ctx.Generos.ToListAsync();
        }

        public async Task<IList<Genero>> GetAll(Expression<Func<Genero, bool>> selector)
        {
            return await _ctx.Generos.Where(selector).ToListAsync();
        }

        public async Task<IList<Genero>> GetAll<TIncludeProperty>(Expression<Func<Genero, TIncludeProperty>> includeClause, Expression<Func<Genero, bool>> selector)
        {
            return await _ctx.Generos.Include(includeClause).Where(selector).ToListAsync();
        }

        public async Task<Genero> Update<Tid>(Genero Entity, Tid id)
        {
            try
            {
                var persona = await _ctx.Generos.FindAsync(id);
                _ctx.Entry(persona).CurrentValues.SetValues(Entity);
                await _ctx.SaveChangesAsync();
            }
            catch (Exception ex)
            {

                throw;
            }

            return (await _ctx.Generos.FindAsync(id))!;
        }
    }
}
