using Domain.Entities;
using Microsoft.EntityFrameworkCore;

namespace Infrastructure.EntityFramework
{
    public class DatabaseContext : DbContext
    {
        public DbSet<Noun> Nouns { get; set; } = null!;

        public DatabaseContext(DbContextOptions<DatabaseContext> options) : base(options)
        {
            ChangeTracker.AutoDetectChangesEnabled = false;
        }


        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {

        }
    }
}
