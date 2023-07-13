namespace Services.PlayerRating.Models.BLL;

public class PlayerRatingDetails
{
    public string GameName { get; set; }
    
    public string TournamentName { get; set; }

    public PlayerRatingItem[] PlayerRank { get; set; }
}