using FreeDemoCatalog.Entities;
using System.Linq.Expressions;


namespace FreeDemoCategory.Core.Abstract
{
    public interface IRepository<TEntity> where TEntity : class
    {
        Task<TEntity> GetByIdAsync(int id);
        Task<List<TEntity>> GetAllAsync();
        Task<TEntity> AddAsync(TEntity entity);
        Task UpdateAsync(TEntity entity);
        Task DeleteAsync(int id);
        Task<int> SaveAsync();

    }

}
