
namespace Services.PlayerRating.Models.DAL;

public interface IUnitOfWork
{
    public Task SaveAsync(CancellationToken token);
}