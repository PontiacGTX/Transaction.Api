using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.ChangeTracking;
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
    public class CuentaRepositorio : IEntityRepository<Cuenta>
    {
        private AppDbContext _ctx { get; }

        public CuentaRepositorio(AppDbContext ctx)
        {
            _ctx = ctx;
        }
        public async Task<Cuenta> Create(Cuenta Entity)
        {
            bool saved = false;
            try
            {
               var res = _ctx.Cuentas.Add(Entity);
                saved = await _ctx.SaveChangesAsync()>0;
                return saved ? res.Entity : null!;
            }
            catch (Exception ex)
            {

                throw;
            }

          
        }

        public async Task<bool> Delete<Tid>(Tid id)
        {
           var cuenta= await _ctx.Cuentas.FindAsync(id);

            if (cuenta is null)
                return true;

            cuenta.Habilitada = false;
            await _ctx.SaveChangesAsync();
            return (bool) (await _ctx.Cuentas.FindAsync(id))?.Habilitada==false;
        }

        public async Task<Cuenta> Get<TId>(TId id)
        {
            int idCuenta = Convert.ToInt32(id);
            return await _ctx.Cuentas.Include(x=>x.TipoCuenta).Include(x=>x.CuentasClientes).FirstOrDefaultAsync(x=>x.CuentaId == idCuenta);
        }

        public async Task<IList<Cuenta>> GetAll()
        {
            return await _ctx.Cuentas.ToListAsync();
        }

        public async Task<IList<Cuenta>> GetAll(Expression<Func<Cuenta, bool>> selector)
        {
            return await _ctx.Cuentas.Where(selector).ToListAsync();
        }

        public async Task<IList<Cuenta>> GetAll<TIncludeProperty>(Expression<Func<Cuenta, TIncludeProperty>> includeClause, Expression<Func<Cuenta, bool>> selector)
        {
            return await _ctx.Cuentas.Include(includeClause).Where(selector).ToListAsync();
        }
        public async Task<IList<Cuenta>> GetAll<TIncludeProperty,TSecondInclude>(Expression<Func<Cuenta, TIncludeProperty>> includeClause,Expression<Func<Cuenta, TSecondInclude>> secondIncludeClause, Expression<Func<Cuenta, bool>> selector)
        {
            return await _ctx.Cuentas.Include(includeClause).Include(secondIncludeClause).Where(selector).ToListAsync();
        }
        public async Task<IList<Cuenta>> GetAll<TIncludeProperty,TIncludeFirstThenInclude>(Expression<Func<Cuenta, TIncludeProperty>> includeClause, Expression<Func<TIncludeProperty, TIncludeFirstThenInclude>> thenInclude, Expression<Func<Cuenta, bool>> selector)
        {
              return await _ctx.Cuentas
                .Include(includeClause).ThenInclude(thenInclude)
                .Where(selector).ToListAsync();

           
        }
        public async Task<Cuenta> Update<Tid>(Cuenta Entity, Tid id)
        {
            try
            {
                var cuenta = await _ctx.Cuentas.FindAsync(id);
                _ctx.Entry(cuenta).CurrentValues.SetValues(Entity);
                await _ctx.SaveChangesAsync();
            }
            catch (Exception ex)
            {

                throw;
            }

            return (await _ctx.Cuentas.FindAsync(id))!;
        }
    }
}
