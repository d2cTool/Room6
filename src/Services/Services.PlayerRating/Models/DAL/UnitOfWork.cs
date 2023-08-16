using Microsoft.EntityFrameworkCore;

namespace Services.PlayerRating.Models.DAL;

public class UnitOfWork:IUnitOfWork
{
    private readonly DbContext _context;

    public UnitOfWork(DbContext context)
    {
        _context = context;
    }

    public async Task SaveAsync(CancellationToken token)
    {
        await _context.SaveChangesAsync(token);
    }
}