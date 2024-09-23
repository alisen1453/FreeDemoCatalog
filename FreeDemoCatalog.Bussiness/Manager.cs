using Azure;
using FreeDemoCatalog.Bussiness.Services;
using FreeDemoCatalog.Entities;
using FreeDemoCatalog.Entities.Entity.Models;
using FreeDemoCategory.Core.Abstract;
using System.Linq.Expressions;
using System.Threading;

namespace FreeDemoCatalog.Bussiness
{
    public class Manager<TEntity> : IServices<TEntity> where TEntity : class
    {
        private readonly IRepository<TEntity> _repository;
        public Manager(IRepository<TEntity> repository)
        {
            _repository = repository;
        }
        public async Task<TEntity> GetByIdAsync(int id)
        {
            return await _repository.GetByIdAsync(id);
        }
        public async Task<List<TEntity>> GetAllAsync()
        {
            return await _repository.GetAllAsync();
        }
        public async Task<TEntity> CreateAsync(TEntity entity)
        {
            return await _repository.AddAsync(entity);
     
        }
        public async Task UpdateAsync(TEntity entity)
        {
            await _repository.UpdateAsync(entity);
        }
        public async Task DeleteAsync(int id)
        {
            await _repository.DeleteAsync(id);
        }
    }
}
