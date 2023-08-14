namespace Services.PlayerRating.Models.BLL;

public interface IPlayerRatingItem
{
    int Rank { get; set; }
    string PlayerName { get; set; }
    long Score { get; set; }
}