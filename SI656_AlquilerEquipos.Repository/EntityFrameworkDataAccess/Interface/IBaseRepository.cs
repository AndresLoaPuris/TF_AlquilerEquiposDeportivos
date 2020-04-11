using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace SI656_AlquilerEquipos.Repository.EntityFrameworkDataAccess.Interface
{
    public interface IBaseRepository<T>
    {
        Task<T> AddAsync(T entity);
        Task<T> EditAsync(T entity);
        Task DeleteAsync(int id);
        Task<List<T>> ListAsync();
        Task<T> GetByIdAsync(int id);
        Task<TResult> GetByIdAsync<TResult>(int id, Expression<Func<T, TResult>> selector);
        Task<List<TResult>> GetAllAsync<TResult>(Expression<Func<T, TResult>> selector);
        Task SaveChange();
    }

}
