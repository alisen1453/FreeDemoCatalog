using FreeDemoCatalog.Bussiness.Services;
using FreeDemoCatalog.DataAccess.Abstract;
using FreeDomeCatalog.Catalog.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Net.Http.Headers;
using System.Text;
using System.Threading.Tasks;

namespace FreeDemoCatalog.Bussiness
{
    public class CategoryManager : ICategoryServices
    {
        ICategoryRepository repository;

        public CategoryManager(ICategoryRepository repository)
        {
            this.repository = repository;
        }

        public void Add(Category entity)
        {
            repository.Add(entity);
        }

        public void Delete(Category entity)
        {

            repository.Delete(entity);
        }
        public List<Category> GetAll()
        {
            return repository.GetAll().ToList();
        }

        public Category GetById(int id)
        {
            return repository.GetById(id);
        }

        public IQueryable<Category> GetEx(Expression<Func<Category, bool>> expression)
        {
            return repository.GetEx(expression);
        }

        public int save()
        {
            return repository.save();
        }

        public void UpdateById(Category entity)
        {
            repository.UpdateById(entity);
        }
    }
}
