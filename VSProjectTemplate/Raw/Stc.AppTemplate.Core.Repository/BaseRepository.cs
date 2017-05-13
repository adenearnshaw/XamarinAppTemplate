using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Threading.Tasks;
using $safeprojectname$.Entities;

namespace $safeprojectname$
{
    internal abstract class BaseRepository<T> where T : class, IEntity, new()
    {
        private readonly IDatabaseConnection _databaseConnection;

        protected BaseRepository(IDatabaseConnection databaseConnection)
        {
            _databaseConnection = databaseConnection;
        }

        public virtual async Task<T> GetAsync(int id)
        {
            var result = await _databaseConnection.GetAsync<T>(id);
            return result;
        }

        public virtual async Task<IEnumerable<T>> All(Expression<Func<T, bool>> predicate)
        {
            var results = await _databaseConnection.AllAsync(predicate);
            return results;
        }

        public virtual async Task SaveAsync(T entityToSave)
        {
            try
            {
                var exists = await GetAsync(entityToSave.ID) != null;

                if (exists)
                {
                    await _databaseConnection.UpdateAsync(entityToSave);
                }
                else
                {
                    await _databaseConnection.SaveAsync(entityToSave);
                }
            }
            catch (Exception)
            {
                //Ignore
            }
        }

        public virtual async Task DeleteAsync(T entityToDelete)
        {
            await _databaseConnection.DeleteAsync(entityToDelete);
        }

        public virtual async Task DeleteAllAsync()
        {
            await _databaseConnection.DeleteAllAsync<T>();
        }
    }
}
