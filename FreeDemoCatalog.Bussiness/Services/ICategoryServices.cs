using FreeDomeCatalog.Catalog.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace FreeDemoCatalog.Bussiness.Services
{
    public interface ICategoryServices
    {
        List<Category> GetAll();
        IQueryable<Category> GetEx(Expression<Func<Category, bool>> expression);
        Category GetById(int id);
        void UpdateById(Category entity);
        void Delete(Category entity);
        void Add(Category entity);
        int save();
    }


}
