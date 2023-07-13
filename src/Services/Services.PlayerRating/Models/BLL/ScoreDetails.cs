namespace Services.PlayerRating.Models.BLL;

public class ScoreDetails
{
    public Guid PlayerID { get; set; }

    public Guid GameID { get; set; }

    public long Score { get; set; }
}