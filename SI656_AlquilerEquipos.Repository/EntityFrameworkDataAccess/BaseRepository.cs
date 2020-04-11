using SI656_AlquilerEquipos.Data;
using SI656_AlquilerEquipos.Repository.EntityFrameworkDataAccess.Interface;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SI656_AlquilerEquipos.Repository.EntityFrameworkDataAccess
{
    public class BaseRepository<T> : IBaseRepository<T> where T : class
    {
        private db_AlquilerEquipoEntities _context = null;
        private DbSet<T> table = null;

        public BaseRepository()
        {
            if (_context == null)
                this._context = new db_AlquilerEquipoEntities();
            table = _context.Set<T>();
        }

        public virtual async Task<T> AddAsync(T entity)
        {
            table.Add(entity);
            await _context.SaveChangesAsync();
            return entity;
        }

        public virtual async Task DeleteAsync(int id)
        {
            T existing = await table.FindAsync(id);
            table.Remove(existing);
            await _context.SaveChangesAsync();
        }

        public virtual async Task<T> EditAsync(T entity)
        {
            //table.Attach( entity );
            //_context.Entry( entity ).State = EntityState.Modified;
            await _context.SaveChangesAsync();
            return entity;
        }

        public virtual async Task<List<TResult>> GetAllAsync<TResult>(System.Linq.Expressions.Expression<Func<T, TResult>> selector)
        {
            return await table.Select(selector).ToListAsync();
        }

        public virtual async Task<T> GetByIdAsync(int id)
        {
            return await table.FindAsync(id);
        }

        public virtual Task<TResult> GetByIdAsync<TResult>(int id, System.Linq.Expressions.Expression<Func<T, TResult>> selector)
        {
            throw new NotImplementedException();
        }

        public virtual async Task<List<T>> ListAsync()
        {
            return await table.ToListAsync();
        }

        public virtual async Task SaveChange()
        {
            await _context.SaveChangesAsync();
        }

    }
}
