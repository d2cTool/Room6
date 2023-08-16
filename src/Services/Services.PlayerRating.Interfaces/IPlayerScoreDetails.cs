namespace Services.PlayerRating.Models.BLL;

public interface IPlayerScoreDetails
{
    Guid GameID { get; set; }
    string GameName { get; set; }
    Guid PlayerID { get; set; }
    string PlayerName { get; set; }
    long Score { get; set; }
}