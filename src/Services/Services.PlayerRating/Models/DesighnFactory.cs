using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;
using Services.PlayerRating.Models.DAL;

namespace Services.PlayerRating.Models;

public class PgContextDesignFactory : IDesignTimeDbContextFactory<PgContext>
{
    public PgContext CreateDbContext(string[] args)
    {
        var optionsBuilder = new DbContextOptionsBuilder<PgContext>();
        optionsBuilder.UseNpgsql(args[0]);

        return new PgContext(optionsBuilder.Options);
    }
}