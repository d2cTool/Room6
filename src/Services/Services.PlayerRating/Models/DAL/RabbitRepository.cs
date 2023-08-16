namespace Services.PlayerRating.Models.DAL;

public interface RabbitRepository
{
    Task Send(object data, CancellationToken token);

    Task<T> Receive<T>(CancellationToken token);
}