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
    public class PropiedadCuentaRepositorio : IEntityRepository<PropiedadCuenta>
    {
        public AppDbContext _ctx { get; set; }
        public PropiedadCuentaRepositorio(AppDbContext ctx)
        {
            _ctx = ctx;
        }
        public async Task<PropiedadCuenta> Create(PropiedadCuenta Entity)
        {
            var res =await _ctx.PropiedadCuentas.AddAsync(Entity);
            bool saved = await _ctx.SaveChangesAsync()>0;
            return saved ? res.Entity : null!;
        }

        public async Task<bool> Delete<Tid>(Tid id)
        {
           var cliente =await   _ctx.PropiedadCuentas.FindAsync(id);

            if (cliente is null)
                return false;

            
            bool saved = await _ctx.SaveChangesAsync() > 0;

            return saved ? saved: await _ctx.PropiedadCuentas.FindAsync(id)==null;
        }

        public async Task<PropiedadCuenta> Get<TId>(TId id)
        {
            return (await _ctx.PropiedadCuentas.FindAsync(id))!;
        }

        public async Task<IList<PropiedadCuenta>> GetAll()
        {
            return await _ctx.PropiedadCuentas.ToListAsync();
        }

        public async Task<IList<PropiedadCuenta>> GetAll(System.Linq.Expressions.Expression<Func<PropiedadCuenta, bool>> selector)
        {
            return await _ctx.PropiedadCuentas.Where(selector).ToListAsync();
        }

        public async Task<IList<PropiedadCuenta>> GetAll<TIncludeProperty>(Expression<Func<PropiedadCuenta, TIncludeProperty>> includeClause, Expression<Func<PropiedadCuenta, bool>> selector)
        {
            return await  _ctx.PropiedadCuentas.Include(includeClause).Where(selector).ToListAsync();
        }
       

        public async Task<PropiedadCuenta> Update<Tid>(PropiedadCuenta Entity, Tid id)
        {
            try
            {
                var cliente = await _ctx.PropiedadCuentas.FindAsync(id);
                _ctx.Entry(cliente).CurrentValues.SetValues(Entity);
                await _ctx.SaveChangesAsync();
            }
            catch (Exception ex)
            {

                throw;
            }

            return (await _ctx.PropiedadCuentas.FindAsync(id))!;
        }

    }
}
