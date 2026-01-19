using Arkitektur.Entity.Entities.Common;

namespace Arkitektur.DataAccess.Repositories
{
    public interface IGenericRepository<TEntity> where TEntity : BaseEntity
    {
        Task CreateAsync(TEntity entity);
        void Update(TEntity entity);
        void Delete(TEntity entity);
        Task<List<TEntity>> GetListAsync();
        Task<TEntity> GetByIdAsync(int id);

        IQueryable<TEntity> GetQueryable();
    }
}
