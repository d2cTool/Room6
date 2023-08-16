namespace Services.PlayerRating.Models.BLL;

public interface IScoreDetails
{
    Guid PlayerID { get; set; }
    Guid GameID { get; set; }
    long Score { get; set; }
}