namespace Services.PlayerRating.Models.BLL;

public class PlayerDetails : IPlayerDetails
{
    public Guid ID { get; set; }
    
    public string Name { get; set; }
}