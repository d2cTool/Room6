// using Microsoft.Extensions.Hosting;
//
// namespace Services.PlayerRating.Models.Presentation;
//
// public class QueryListenerService:IHostedService
// {
//     private readonly IRabbitMQRepository _repository;
//
//     public QueryListenerService(IRabbitMQRepository repository)
//     {
//         _repository = repository;
//     }
//
//     public Task StartAsync(CancellationToken cancellationToken)
//     {
//         return _repository.Run(cancellationToken);
//         return Task.CompletedTask;
//     }
//
//     public Task StopAsync(CancellationToken cancellationToken)
//     {
//         _repository.Stop();
//         return Task.CompletedTask;
//     }
// }