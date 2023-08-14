namespace Services.PlayerRating.Models.BLL;

public class PlayerScoreDetails : IPlayerScoreDetails
{
    public Guid  GameID { get; set; }
    
    public string GameName { get; set; }
    
    public Guid PlayerID { get; set; }
    
    public string PlayerName { get; set; }

    public long Score { get; set; }
}