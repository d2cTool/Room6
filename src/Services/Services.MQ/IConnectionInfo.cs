namespace Services.PlayerRating.Models.Presentation;

public interface IConnectionInfo
{
    string HostName { get; set; }
    string UserName { get; set; }
    string Password { get; set; }
    string QueueName { get; set; }
    string SendQueueName { get; set; }
}