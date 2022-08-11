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
    public class TipoMovimientosRepositorio:IEntityRepository<TipoMovimientos>
    {
        private AppDbContext _ctx { get; }

        public TipoMovimientosRepositorio(AppDbContext ctx)
        {
            _ctx = ctx;
        }

        public async Task<TipoMovimientos> Create(TipoMovimientos Entity)
        {
            bool saved = false;
            try
            {
                var res = _ctx.TipoDeMovimientos.Add(Entity);
                saved = await _ctx.SaveChangesAsync() > 0;
                return saved ? res.Entity : null!;
            }
            catch (Exception ex)
            {

                throw;
            }
        }

        public async Task<TipoMovimientos> Update<Tid>(TipoMovimientos Entity, Tid id)
        {
            try
            {
                var estado = await _ctx.TipoDeMovimientos.FindAsync(id);
                _ctx.Entry(estado).CurrentValues.SetValues(Entity);
                await _ctx.SaveChangesAsync();
            }
            catch (Exception ex)
            {

                throw;
            }

            return (await _ctx.TipoDeMovimientos.FindAsync(id))!;
        }

        public async Task<bool> Delete<Tid>(Tid id)
        {
            var tMov = await _ctx.TipoDeMovimientos.FindAsync(id);

            if (tMov is null)
                return true;

            tMov.Habilitado = false;
            await _ctx.SaveChangesAsync();
            return (bool)(await _ctx.TipoDeMovimientos.FindAsync(id))?.Habilitado == false;
        }

        public async Task<TipoMovimientos> Get<TId>(TId id)
        {
            return await _ctx.TipoDeMovimientos.FindAsync(id);
        }

        public async Task<IList<TipoMovimientos>> GetAll()
        {
            return await _ctx.TipoDeMovimientos.ToListAsync();
        }

        public async Task<IList<TipoMovimientos>> GetAll(Expression<Func<TipoMovimientos, bool>> selector)
        {
            return await _ctx.TipoDeMovimientos.Where(selector).ToListAsync();
        }

        public async Task<IList<TipoMovimientos>> GetAll<TIncludeProperty>(Expression<Func<TipoMovimientos, TIncludeProperty>> includeClause, Expression<Func<TipoMovimientos, bool>> selector)
        {
            return await _ctx.TipoDeMovimientos.Include(includeClause).Where(selector).ToListAsync();
        }
    }
}
