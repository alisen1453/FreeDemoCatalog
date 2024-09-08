using FreeDemoCategory.Core.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace FreeDemoCategory.Core.Abstract
{
    public interface IRepository<T> where T : class, IEntity
    {
        IQueryable<T> GetAll();
        IQueryable<T> GetEx(Expression<Func<T, bool>> expression);
        T GetById(int id);
        void UpdateById(T entity);
        void Delete(T entity);
        void Add(T entity);
        int save();

    }

}
