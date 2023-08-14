namespace Services.PlayerRating.Models.BLL;

public class PlayerRatingDetails : IPlayerRatingDetails
{
    public string GameName { get; set; }
    
    public string TournamentName { get; set; }

    public IPlayerRatingItem[] PlayerRank { get; set; }
}