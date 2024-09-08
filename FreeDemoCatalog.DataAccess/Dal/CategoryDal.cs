using FreeDemoCatalog.DataAccess.Abstract;
using FreeDemoCategory.Core.Repositories;
using FreeDomeCatalog.Catalog.DataAccess;
using FreeDomeCatalog.Catalog.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FreeDemoCatalog.DataAccess.Dal
{
    public class CategoryDal : Repository<Category, CategoryDbContext>, ICategoryRepository
    {
        public CategoryDal(CategoryDbContext context) : base(context)
        {
        }
    }
}
