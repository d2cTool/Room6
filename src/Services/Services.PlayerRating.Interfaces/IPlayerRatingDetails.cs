namespace Services.PlayerRating.Models.BLL;

public interface IPlayerRatingDetails
{
    string GameName { get; set; }
    string TournamentName { get; set; }
    IPlayerRatingItem[] PlayerRank { get; set; }
}