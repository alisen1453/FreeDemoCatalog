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

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Category>()
                .HasIndex(c => c.Id).IsUnique();
            modelBuilder.Entity<Category>()
                .Property(c => c.Id)
                .HasColumnName("Categoryid")
                .HasMaxLength(20);
            modelBuilder.Entity<Category>()
                .Property(c => c.Name)
                .HasColumnName("CategoryName")
                .HasMaxLength(20);
            modelBuilder.Entity<Category>()
                .Property(c => c.Description)
                .HasColumnName("CategoryDescription")
                .HasMaxLength(200);


        }

        public virtual DbSet<TEntity> GetEntity<TEntity>() where TEntity : class
        {
            return Set<TEntity>();
        }

       

    }
}
