using API.Model.Data;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace API.Model.Repositories
{
    public class BaseRepository<TEntity> : IRepository<TEntity>
        where TEntity : class, IEntity
    {
        protected readonly DataBaseContext _context;        

        public BaseRepository(DataBaseContext context)
        {
            _context = context;
        }

        public virtual async Task<TEntity> Add(TEntity entity)
        {
            _context.Set<TEntity>().Add(entity);
            await _context.SaveChangesAsync();

            return entity;
        }


        // TODO catch only the desired exception
        public virtual async Task<TEntity> Remove(TEntity entity)
        {
            try
            {
                var removed = _context.Set<TEntity>().Remove(entity);
                await _context.SaveChangesAsync();

                return removed.Entity;
            }
            catch
            {
                return null;
            }
        }

        public virtual async Task<TEntity> Get(int id)
        {
            return await _context.Set<TEntity>().FindAsync(id);
        }

        public virtual async Task<ICollection<TEntity>> GetAll()
        {
            return await _context.Set<TEntity>().ToListAsync();
        }

        public virtual async Task<TEntity> Update(TEntity entity)
        {
            try
            {
                _context.Entry(entity).State = EntityState.Modified;

                await _context.SaveChangesAsync();

                return entity;
            }
            catch (DbUpdateException exp)
            {
                await _context.Entry(entity).ReloadAsync();

                throw exp;
            }
        }

        #region Private methods



        #endregion
    }
}
