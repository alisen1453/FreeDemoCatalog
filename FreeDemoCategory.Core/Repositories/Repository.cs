using FreeDemoCategory.Core.Abstract;
using FreeDemoCategory.Core.Entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace FreeDemoCategory.Core.Repositories
{
    public class Repository<Tentity, Tcontext> : IRepository<Tentity>
        where Tentity : class,IEntity
        where Tcontext : DbContext

    {
        protected readonly Tcontext context;

        public Repository(Tcontext context)
        {
            this.context = context;
        }

        public void Add(Tentity entity)
        {
           context.Set<Tentity>().Add(entity);
            save();
        }

        public void Delete(Tentity entity)
        {
            context.Set<Tentity>().Remove(entity);
            save();
        }

        public IQueryable<Tentity> GetAll()
        {
            return context.Set<Tentity>();
        }

        public Tentity GetById(int id)
        {
            return context.Set<Tentity>().Find(id);
        }

        public IQueryable<Tentity> GetEx(Expression<Func<Tentity, bool>> expression)
        {
            return context.Set<Tentity>().Where(expression);
        }

        public int save()
        {
         return   context.SaveChanges();
        }

        public void UpdateById(Tentity entity)
        {
            context.Set<Tentity>().Update(entity);
            save();
        }
    }
}
