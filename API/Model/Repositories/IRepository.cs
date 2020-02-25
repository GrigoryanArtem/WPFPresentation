using API.Model.Data;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace API.Model.Repositories
{
    public interface IRepository<TEntity>
        where TEntity : class, IEntity
    {
        Task<ICollection<TEntity>> GetAll();

        Task<TEntity> Get(int id);
        Task<TEntity> Add(TEntity entity);
        Task<TEntity> Update(TEntity entity);
        Task<TEntity> Remove(TEntity entity);
    }
}
