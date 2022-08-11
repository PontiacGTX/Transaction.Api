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
    public class CuentasClientesRepository : IEntityRepository<CuentasClientes>
    {
        private AppDbContext _ctx { get; }

        public CuentasClientesRepository(AppDbContext ctx)
        {
            _ctx = ctx;
        }
        public async Task<CuentasClientes> Create(CuentasClientes Entity)
        {
            bool saved = false;
            try
            {
                var res = _ctx.CuentasClientes.Add(Entity);
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
            var cclientes = await _ctx.CuentasClientes.FindAsync(id);

            if (cclientes is null)
                return true;

            cclientes.Habilitado = false;
            await _ctx.SaveChangesAsync();
            return (bool)(await _ctx.CuentasClientes.FindAsync(id))?.Habilitado == false;
        }

        public async Task<CuentasClientes> Get<TId>(TId id)
        {
            return await _ctx.CuentasClientes.FindAsync(id);
        }

        public  async Task<IList<CuentasClientes>> GetAll()
        {
            return await _ctx.CuentasClientes.ToListAsync();
        }

        public async Task<IList<CuentasClientes>> GetAll(Expression<Func<CuentasClientes, bool>> selector)
        {
            return await _ctx.CuentasClientes.Where(selector).ToListAsync();
        }

        public async Task<IList<CuentasClientes>> GetAll<TIncludeProperty>(Expression<Func<CuentasClientes, TIncludeProperty>> includeClause, Expression<Func<CuentasClientes, bool>> selector)
        {
            return await _ctx.CuentasClientes.Include(includeClause).Where(selector).ToListAsync();
        }

        public async Task<IList<CuentasClientes>> GetAll<TIncludeProperty,TSecondIncludeProperty>(Expression<Func<CuentasClientes, TIncludeProperty>> includeClause, Expression<Func<CuentasClientes, TSecondIncludeProperty>> secondIncludeClause, Expression<Func<CuentasClientes, bool>> selector)
        {
            return await _ctx.CuentasClientes.Include(includeClause).Include(secondIncludeClause).Where(selector).ToListAsync();
        }
        public async Task<CuentasClientes> Update<Tid>(CuentasClientes Entity, Tid id)
        {
            try
            {
                var estado = await _ctx.CuentasClientes.FindAsync(id);
                _ctx.Entry(estado).CurrentValues.SetValues(Entity);
                await _ctx.SaveChangesAsync();
            }
            catch (Exception ex)
            {

                throw;
            }

            return (await _ctx.CuentasClientes.FindAsync(id))!;
        }
    }
}
