using FreeDemoCategory.Core.Abstract;
using FreeDomeCatalog.Catalog.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FreeDemoCatalog.DataAccess.Abstract
{
    public interface ICategoryRepository:IRepository<Category>
    {
    }
}
