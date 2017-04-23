using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace Stc.AppTemplate.Core.Repository
{
    public interface IDatabaseConnection
    {
        Task CreateTableAsync<T>() where T : class, new();
        Task<T> SaveAsync<T>(T data);
        Task<T> UpdateAsync<T>(T data);
        Task<T> GetAsync<T>(Expression<Func<T, bool>> predicate) where T : class, new();
        Task<T> GetAsync<T>(int id) where T : class, new();
        Task<IEnumerable<T>> AllAsync<T>(Expression<Func<T, bool>> predicate = null) where T : class, new();
        Task DeleteAsync<T>(T data) where T : class, new();
        Task DeleteAllAsync<T>() where T : class, new();
    }
}
