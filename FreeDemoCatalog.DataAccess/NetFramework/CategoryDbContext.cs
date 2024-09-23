using FreeDemoCatalog.Entities.Entity.Models;
using FreeDomeCatalog.Catalog.Models;
using Microsoft.EntityFrameworkCore;

namespace FreeDomeCatalog.Catalog.DataAccess
{
    public class CategoryDbContext: DbContext
    {
        public CategoryDbContext(DbContextOptions options) : base(options)
        {
        }


        public DbSet<Category> Categories { get; set; }
        public DbSet<Note> Notes { get; set; }

        public virtual DbSet<TEntity> GetEntity<TEntity>() where TEntity : class
        {
            return Set<TEntity>();
        }

    }
}
