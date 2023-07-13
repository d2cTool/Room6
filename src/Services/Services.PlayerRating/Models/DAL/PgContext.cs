using Microsoft.EntityFrameworkCore;
using Services.PlayerRating.Models.DAL.Entity;

namespace Services.PlayerRating.Models.DAL;

public sealed class PgContext:DbContext
{
    public PgContext(DbContextOptions<PgContext> options)
        : base(options)
    {
        Database.Migrate();
    }
    
    public DbSet<Scores> Scores { get; set; }
    
    public DbSet<Games> Games { get; set; }
    
    public DbSet<Players> Players { get; set; }
    
}