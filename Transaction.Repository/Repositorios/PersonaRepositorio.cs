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
    public class PersonaRepositorio : IEntityRepository<Persona>
    {
        private AppDbContext _ctx { get; }

        public PersonaRepositorio(AppDbContext ctx)
        {
            _ctx = ctx;
        }
        public async Task<Persona> Create(Persona Entity)
        {
            bool saved = false;
            try
            {
                var res = _ctx.Personas.Add(Entity);
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
             var persona = await _ctx.Personas.FindAsync(id);

            if (persona is null)
                return true;

            persona.Habilitada = false;
            await _ctx.SaveChangesAsync();
            return (bool)(await _ctx.Personas.FindAsync(id))?.Habilitada == false;
        }

        public async Task<Persona> Get<TId>(TId id)
        {
            return await _ctx.Personas.FindAsync(id);
        }

        public async Task<IList<Persona>> GetAll()
        {
            return await _ctx.Personas.ToListAsync();
        }

        public async Task<IList<Persona>> GetAll(Expression<Func<Persona, bool>> selector)
        {
            return await _ctx.Personas.Include(x=>x.Genero).Where(selector).ToListAsync();
        }

        public async Task<IList<Persona>> GetAll<TIncludeProperty>(Expression<Func<Persona, TIncludeProperty>> includeClause, Expression<Func<Persona, bool>> selector)
        {
            return await _ctx.Personas.Include(includeClause).Where(selector).ToListAsync();
        }

        public async Task<Persona> Update<Tid>(Persona Entity, Tid id)
        {
            try
            {
                var persona = await _ctx.Personas.FindAsync(id);
                _ctx.Entry(persona).CurrentValues.SetValues(Entity);
                await _ctx.SaveChangesAsync();
            }
            catch (Exception ex)
            {

                throw;
            }

            return (await _ctx.Personas.FindAsync(id))!;
        }
    }
}
