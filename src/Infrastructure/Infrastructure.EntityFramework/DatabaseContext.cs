using Domain.Entities;
using Microsoft.EntityFrameworkCore;

namespace Infrastructure.EntityFramework
{
    public class DatabaseContext : DbContext
    {
        public DbSet<Noun> Nouns { get; set; } = null!;

        public DatabaseContext(DbContextOptions<DatabaseContext> options) : base(options)
        {
        }


        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Noun>()
                .HasKey(n => n.Id);
            modelBuilder.Entity<Noun>()
                .Property(n => n.Name)
                .IsRequired();
        }
    }
}
