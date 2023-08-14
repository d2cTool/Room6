using System.Text;
using Newtonsoft.Json;
using RabbitMQ.Client;
using RabbitMQ.Client.Events;

namespace Services.PlayerRating.Models.Presentation;

public class RabbitMqRepository : IRabbitMQRepository
{
    private readonly CountdownEvent _event;

    public RabbitMqRepository()
    {
        _event = new CountdownEvent(1);
    }

    public void Stop()
    {
        _event.Signal();
    }

    public async Task RunAsync(Func<BasicDeliverEventArgs, Task> runScores, IConnectionInfo configuration,
        CancellationToken token)
    {
        var factory = new ConnectionFactory()
        {
            HostName = configuration.HostName,
            UserName = configuration.UserName,
            Password = configuration.Password,
        };

        using var connection =  factory.CreateConnection();
        using var channel = connection.CreateModel();
        
        channel.BasicQos(0,10,false);
        var configurationQueueName = configuration.QueueName;
        channel.QueueDeclare(configurationQueueName, false, false, false, null);
        channel.QueueBind(configurationQueueName,"exchange.score","score", null);

        var consumer = new EventingBasicConsumer(channel);

        async void OnConsumerOnReceived(object sender, BasicDeliverEventArgs args)
        {
            await runScores(args);
        }

        consumer.Received += OnConsumerOnReceived;

        channel.BasicConsume(configurationQueueName, true, consumer);
        
        await Task.Yield();
        //todo:проверить на выход до завершения
        _event.Wait(token);
    }

    public void Send<T>(IConnectionInfo configuration, T data)
    {
        var factory = new ConnectionFactory()
        {
            HostName = configuration.HostName,
            UserName = configuration.UserName,
            Password = configuration.Password,
        };

        using var connection =  factory.CreateConnection();
        using var channel = connection.CreateModel();
        
        channel.BasicQos(0,10,false);
        var configurationQueueName = configuration.SendQueueName;
        var exchangeScore = "exchange.score";
        var routingKey = "score";
        channel.QueueBind(configurationQueueName,exchangeScore,routingKey, null);

        IBasicProperties props = channel.CreateBasicProperties();
        props.ContentType = "json/raw";
        props.DeliveryMode = 2;

        var mesage = JsonConvert.SerializeObject(data);

        var binary = Encoding.Default.GetBytes(mesage);
        
        channel.BasicPublish(exchangeScore, routingKey, props, binary);

    }

   
}