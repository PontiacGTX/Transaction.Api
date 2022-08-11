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
    public class MovimientosRepositorio : IEntityRepository<Movimientos>
    {
        private AppDbContext _ctx { get; }

        public MovimientosRepositorio(AppDbContext ctx)
        {
            _ctx = ctx;
        }
        public async Task<Movimientos> Create(Movimientos Entity)
        {
            bool saved = false;
            try
            {
                var res = _ctx.Movimientos.Add(Entity);
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
            var movimiento = await _ctx.Movimientos.FindAsync(id);

            if (movimiento is null)
                return true;

            movimiento.Estado = false;
            await _ctx.SaveChangesAsync();
            return (bool)(await _ctx.Movimientos.FindAsync(id))?.Estado == false;
        }

        public async Task<Movimientos> Get<TId>(TId id)
        {
            return await _ctx.Movimientos.FindAsync(id);
        }

        public async Task<IList<Movimientos>> GetAll()
        {
            return await _ctx.Movimientos.ToListAsync();
        }

        public async  Task<IList<Movimientos>> GetAll(Expression<Func<Movimientos, bool>> selector)
        {
            return await _ctx.Movimientos.Where(selector).ToListAsync();
        }

        public async Task<IList<Movimientos>> GetAll<TIncludeProperty>(Expression<Func<Movimientos, TIncludeProperty>> includeClause, Expression<Func<Movimientos, bool>> selector)
        {
            return await _ctx.Movimientos.Include(includeClause).Where(selector).ToListAsync();
        }
        public async Task<IList<Movimientos>> GetMovimientos(Expression<Func<Movimientos,bool>> selector)
        {
           return await _ctx.Movimientos
                .Include(x => x.Cuenta)
                .ThenInclude(x=>x.CuentasClientes)
                .ThenInclude(x=>x.Cliente)
                .ThenInclude(x=>x.Persona)
                .Include(x=>x.TipoMovimiento)
                .Where(selector).ToListAsync();
        }
        public async Task<IList<Movimientos>> GetAll<T,T1,T2,T3>(Expression<Func<Movimientos, bool>> selector)
        {
          return  await _ctx.Movimientos
                .Include(x => x.TipoMovimiento)
                .Include(x => x.Cuenta)
                .ThenInclude(x=>x.TipoCuenta)
                .Include(x=>x.Cuenta)
                .ThenInclude(x => x.CuentasClientes)
                .ThenInclude(x=>x.Cliente)
                .Where(selector)
                .ToListAsync();

            

        }

        public async Task<Movimientos> Update<Tid>(Movimientos Entity, Tid id)
        {
            try
            {
                var movimiento = await _ctx.Movimientos.FindAsync(id);
                _ctx.Entry(movimiento).CurrentValues.SetValues(Entity);
                await _ctx.SaveChangesAsync();
            }
            catch (Exception ex)
            {

                throw;
            }

            return (await _ctx.Movimientos.FindAsync(id))!;
        }
    }
}
