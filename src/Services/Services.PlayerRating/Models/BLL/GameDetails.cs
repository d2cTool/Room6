namespace Services.PlayerRating.Models.BLL;

public class GameDetails : IGameDetails
{
    public Guid ID { get; set; }
    
    public string Name { get; set; }
}