using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace NLayerApp.Core.Repositories
{
    public interface IGenericRepository <T> where T : class
    {
        Task<T> GetByIdAsync(int id);
        
        //Task<IQueryable<T>> GetAllAsync();
        //IQueryable<T> GetAllAsync();
        Task<IEnumerable<T>> GetAllAsync();
        
        // Where(x => x.Id > 5)
        IQueryable<T> Where(Expression<Func<T, bool>> expression);
        
        Task AddAsync(T entity);
        void Remove(T entity);
        T Update(T entity);
        
        Task<bool> AnyAsync(Expression<Func<T, bool>> expression);
        Task AddRangeAsync(IEnumerable<T> entities);
        void RemoveRange(IEnumerable<T> entities);
    }
}
