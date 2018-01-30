using Microsoft.EntityFrameworkCore;
using SIENN.DbAccess.EntityConfiguration;

namespace SIENN.DbAccess
{
    public class SiennDbContext : DbContext
    {
        public SiennDbContext(DbContextOptions<SiennDbContext> options) : base(options)
        {
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfiguration(new ProductEntityConfiguration());
            modelBuilder.ApplyConfiguration(new ProductCategoryEntityConfiguration());
            modelBuilder.ApplyConfiguration(new CategoryEntityConfiguration());
            modelBuilder.ApplyConfiguration(new UnitEntityConfiguration());
            modelBuilder.ApplyConfiguration(new ProductTypeEntityConfiguration());
            base.OnModelCreating(modelBuilder);
        }
    }
}