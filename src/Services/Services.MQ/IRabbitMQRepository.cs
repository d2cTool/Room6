using RabbitMQ.Client.Events;

namespace Services.PlayerRating.Models.Presentation;

public interface IRabbitMQRepository
{
    void Stop();
    Task RunAsync(Func<BasicDeliverEventArgs, Task> runScores, IConnectionInfo configuration, CancellationToken token);
    void Send<T>(IConnectionInfo configuration, T data);
}