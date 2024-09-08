using FreeDomeCatalog.Catalog.Models;
using System.Linq.Expressions;

namespace FreeDemoCatalog.Bussiness.Services
{
    public interface INoteServices
    {
        List<Note> GetAll();
        IQueryable<Note> GetEx(Expression<Func<Note, bool>> expression);
        Note GetById(int id);
        void UpdateById(Note entity);
        void Delete(Note entity);
        void Add(Note entity);
        int save();
    }


}
