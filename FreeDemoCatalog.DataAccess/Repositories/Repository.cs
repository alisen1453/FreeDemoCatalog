using AutoMapper;
using FreeDemoCatalog.Entities;
using FreeDemoCategory.Core.Abstract;
using FreeDomeCatalog.Catalog.DataAccess;
using Microsoft.EntityFrameworkCore;
using System.Linq.Expressions;

namespace FreeDemoCatalog.DataAccess.Repositories
{
    public class Repository<TEntity> : IRepository<TEntity>
        where TEntity : class
    {
       
        private readonly CategoryDbContext _context;
        private readonly DbSet<TEntity> _dbSet;

        public Repository(CategoryDbContext context)
        {
            _context = context;
            _dbSet = context.Set<TEntity>();
        }
        public async Task<TEntity> GetByIdAsync(int id)
        {
            return await _dbSet.FindAsync(id);
        }
        public async Task<List<TEntity>> GetAllAsync()
        {
            return await _dbSet.ToListAsync();
        }
        public async Task<TEntity> AddAsync(TEntity entity)
        {
            await _dbSet.AddAsync(entity);
            await SaveAsync();
            return entity;
          

        }
        public async Task UpdateAsync(TEntity entity)
        {
            _context.Entry(entity).State = EntityState.Modified;
            await SaveAsync();
        }
        public async Task DeleteAsync(int id)
        {
            var entity = await GetByIdAsync(id);
            if (entity != null)
            {
                _dbSet.Remove(entity);
                await SaveAsync();
            }
        }
        public async Task<int> SaveAsync()
        {
            return await _context.SaveChangesAsync();
        }

        //public Task<List<TEntity>> GetEx(Expression<Func<TEntity, bool>> expression)
        //{
        //    throw new NotImplementedException();
        //}


    }
}
