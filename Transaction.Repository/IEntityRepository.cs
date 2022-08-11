using System;
using System.Collections.Generic;
using System.Linq;
using Microsoft.EntityFrameworkCore;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace Transactions.Repositories
{
    public interface IEntityRepository<T> where T : class
    {
        public Task<T> Create(T Entity);
        public Task<T> Update<TId>(T Entity, TId id);
        public Task<bool> Delete<TId>(TId id);
        public Task<T> Get<TId>(TId id);
        public Task<IList<T>> GetAll();
        public Task<IList<T>> GetAll(Expression<Func<T,bool>> selector);
        public Task<IList<T>> GetAll<TIncludeProperty>(Expression<Func<T, TIncludeProperty>> includeClause, Expression<Func<T, bool>> selector);



    }
}
