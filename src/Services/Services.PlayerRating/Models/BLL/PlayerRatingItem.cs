namespace Services.PlayerRating.Models.BLL;

public class PlayerRatingItem : IPlayerRatingItem
{
    public int Rank { get; set; }

    public string PlayerName { get; set; }

    public long Score { get; set; }
}