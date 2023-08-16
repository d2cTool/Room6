namespace Services.PlayerRating.Models.Presentation;

public class ConnectionInfo : IConnectionInfo
{
    public string HostName { get; set; }

    public string UserName { get; set; }

    public string Password { get; set; }

    public string QueueName { get; set; }

    public string SendQueueName { get; set; }
}