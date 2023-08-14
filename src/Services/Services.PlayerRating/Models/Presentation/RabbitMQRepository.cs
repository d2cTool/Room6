// using System.Text;
// using AutoMapper;
// using Microsoft.Extensions.Options;
// using Newtonsoft.Json;
// using RabbitMQ.Client;
// using RabbitMQ.Client.Events;
// using Services.PlayerRating.Models.BLL;
//
// namespace Services.PlayerRating.Models.Presentation;
//
// public class RabbitMQRepository : IRabbitMQRepository
// {
//     private readonly IConnectionInfo _configuration;
//     private readonly IMapper _mapper;
//     private readonly IScoreService _service;
//     private readonly CountdownEvent _event;
//
//     public RabbitMQRepository(IOptions<IConnectionInfo> configuration, IMapper mapper, IScoreService service)
//     {
//         _mapper = mapper;
//         _service = service;
//         _configuration = configuration?.Value;
//         _event = new CountdownEvent(1);
//     }
//
//     public void Stop()
//     {
//         _event.Signal();
//     }
//
//     public async Task Run(Func<BasicDeliverEventArgs, Task> runScores, IConnectionInfo configuration,
//         CancellationToken token)
//     {
//         var factory = new ConnectionFactory()
//         {
//             HostName = _configuration.HostName,
//             UserName = _configuration.UserName,
//             Password = _configuration.Password,
//         };
//
//         using var connection =  factory.CreateConnection();
//         using var channel = connection.CreateModel();
//         
//         channel.BasicQos(0,10,false);
//         var configurationQueueName = _configuration.QueueName;
//         channel.QueueDeclare(configurationQueueName, false, false, false, null);
//         channel.QueueBind(configurationQueueName,"exchange.score","score", null);
//
//         var consumer = new EventingBasicConsumer(channel);
//
//         async void OnConsumerOnReceived(object sender, BasicDeliverEventArgs args)
//         {
//             await runScores(args);
//         }
//
//         consumer.Received += OnConsumerOnReceived;
//
//         channel.BasicConsume(configurationQueueName, true, consumer);
//         
//         await Task.Yield();
//         //todo:проверить на выход до завершения
//         _event.Wait(token);
//     }
//     
//     public void Send<T>(T data)
//     {
//         var factory = new ConnectionFactory()
//         {
//             HostName = _configuration.HostName,
//             UserName = _configuration.UserName,
//             Password = _configuration.Password,
//         };
//
//         using var connection =  factory.CreateConnection();
//         using var channel = connection.CreateModel();
//         
//         channel.BasicQos(0,10,false);
//         var configurationQueueName = _configuration.SendQueueName;
//         var exchangeScore = "exchange.score";
//         var routingKey = "score";
//         channel.QueueBind(configurationQueueName,exchangeScore,routingKey, null);
//
//         IBasicProperties props = channel.CreateBasicProperties();
//         props.ContentType = "json/raw";
//         props.DeliveryMode = 2;
//
//         var mesage = JsonConvert.SerializeObject(data);
//
//         var binary = Encoding.Default.GetBytes(mesage);
//         
//         channel.BasicPublish(exchangeScore, routingKey, props, binary);
//
//     }
//
//     public async Task RunScores(CancellationToken token, BasicDeliverEventArgs args)
//     {
//         var messageString = Encoding.UTF8.GetString(args.Body.Span);
//         var score = JsonConvert.DeserializeObject<ScoreModelDTO>(messageString);
//
//         var details = _mapper.Map<ScoreDetails>(score);
//         var result = await _service.AddScoreAsync(details, token);
//         Send(result);
//     }
// }