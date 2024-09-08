using FreeDemoCatalog.Bussiness.Services;
using FreeDemoCatalog.DataAccess.Abstract;
using FreeDomeCatalog.Catalog.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace FreeDemoCatalog.Bussiness
{
    public class NoteManager : INoteServices
    {
        protected readonly INoteServices repository;
        public void Add(Note entity)
        {
            repository.Add(entity); 
        }

        public void Delete(Note entity)
        {
            repository?.Delete(entity);
        }

        public List<Note> GetAll()
        {
            return repository.GetAll().ToList();
        }

        public Note GetById(int id)
        {
            return repository.GetById(id);
        }

        public IQueryable<Note> GetEx(Expression<Func<Note, bool>> expression)
        {
            return repository.GetEx(expression);
        }

        public int save()
        {
         return   repository.save();
        }

        public void UpdateById(Note entity)
        {
            repository.UpdateById(entity);
        }

        List<Note> INoteServices.GetAll()
        {
            throw new NotImplementedException();
        }
    }
}
