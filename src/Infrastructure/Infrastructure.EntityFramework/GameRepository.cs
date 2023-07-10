using Domain.Entities;
using Microsoft.EntityFrameworkCore;

namespace Infrastructure.EntityFramework
{
    public sealed class GameRepository
    {
        private readonly IDbContextFactory<DatabaseContext> _dbContextFactory;

        private readonly Random _rnd = new();

        public GameRepository(IDbContextFactory<DatabaseContext> dbContextFactory)
        {
            _dbContextFactory = dbContextFactory;
        }

        public async Task<Noun> GetInitAsync(int from = 6, int to = 12)
        {
            using var dbContext = _dbContextFactory.CreateDbContext();

            var count = await dbContext.Nouns
                .CountAsync(x => x.Name.Length > from && x.Name.Length < to);

            return await dbContext.Nouns
                .Where(x => x.Name.Length > from && x.Name.Length < to)
                .Skip(_rnd.Next(count - 1))
                .FirstAsync();
        }
    }
}
