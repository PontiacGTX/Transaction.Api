using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Transactions.Data.Common;

namespace Transactions.Services
{
    internal interface ITransactionService
    {
        public Task<Response> GetAll();
        public Task<Response> Get<Tid>(Tid id);
        public Task<Response> Delete<Tid>(Tid id);
        public Task<Response> Create<TCreate>(TCreate model);
        public Task<Response> Update<T, Tid>(T model,Tid id);

    }
}
