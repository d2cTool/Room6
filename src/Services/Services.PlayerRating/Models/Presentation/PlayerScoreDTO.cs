namespace Services.PlayerRating.Models.Presentation;

public class PlayerScoreDTO
{
    public Guid  GameID { get; set; }
    
    public string GameName { get; set; }
    
    public Guid PlayerID { get; set; }
    
    public string PlayerName { get; set; }

    public long Score { get; set; }
}