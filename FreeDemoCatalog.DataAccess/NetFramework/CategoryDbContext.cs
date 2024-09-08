using FreeDomeCatalog.Catalog.Models;
using Microsoft.EntityFrameworkCore;

namespace FreeDomeCatalog.Catalog.DataAccess
{
    public class CategoryDbContext : DbContext
    {
        public CategoryDbContext(DbContextOptions<CategoryDbContext> options) : base(options)
        {
        }

        public DbSet<Category> Categories { get; set; }
        public DbSet<Note> Notes { get; set; }
    }
}
