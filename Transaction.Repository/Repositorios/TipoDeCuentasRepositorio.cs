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
    public class TipoDeCuentasRepositorio : IEntityRepository<TipoCuenta>
    {
        private AppDbContext _ctx { get; }

        public TipoDeCuentasRepositorio(AppDbContext ctx)
        {
            _ctx = ctx;
        }

        public async Task<TipoCuenta> Create(TipoCuenta Entity)
        {
            bool saved = false;
            try
            {
                var res = _ctx.TiposDeCuentas.Add(Entity);
                saved = await _ctx.SaveChangesAsync() > 0;
                return saved ? res.Entity : null!;
            }
            catch (Exception ex)
            {

                throw;
            }
        }

        public async Task<TipoCuenta> Update<Tid>(TipoCuenta Entity, Tid id)
        {
            try
            {
                var estado = await _ctx.TiposDeCuentas.FindAsync(id);
                _ctx.Entry(estado).CurrentValues.SetValues(Entity);
                await _ctx.SaveChangesAsync();
            }
            catch (Exception ex)
            {

                throw;
            }

            return (await _ctx.TiposDeCuentas.FindAsync(id))!;
        }

        public async Task<bool> Delete<Tid>(Tid id)
        {
            var tMov = await _ctx.TiposDeCuentas.FindAsync(id);

            if (tMov is null)
                return true;

            tMov.Habilitado = false;
            await _ctx.SaveChangesAsync();
            return (bool)(await _ctx.TiposDeCuentas.FindAsync(id))?.Habilitado == false;
        }

        public async Task<TipoCuenta> Get<TId>(TId id)
        {
            return await _ctx.TiposDeCuentas.FindAsync(id);
        }

        public async Task<IList<TipoCuenta>> GetAll()
        {
            return await _ctx.TiposDeCuentas.Include(x=>x.PropiedadCuenta).Where(x=>x.Habilitado).ToListAsync();
        }

        public async Task<IList<TipoCuenta>> GetAll(Expression<Func<TipoCuenta, bool>> selector)
        {
            return await _ctx.TiposDeCuentas.Where(selector).ToListAsync();
        }

        public async Task<IList<TipoCuenta>> GetAll<TIncludeProperty>(Expression<Func<TipoCuenta, TIncludeProperty>> includeClause, Expression<Func<TipoCuenta, bool>> selector)
        {
            return await _ctx.TiposDeCuentas.Include(includeClause).Where(selector).ToListAsync();
        }
    }
}
