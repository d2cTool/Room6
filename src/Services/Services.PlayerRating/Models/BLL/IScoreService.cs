namespace Services.PlayerRating.Models.BLL;

public interface IScoreService
{
    Task<ScoreDetails> AddScoreAsync(ScoreDetails details, CancellationToken token =default);
    Task<PlayerRatingDetails?> GetPlayerRank(Guid gameID, CancellationToken token);
    Task<GameDetails> AddGameAsync(GameDetails details, CancellationToken token);
    Task<PlayerDetails> AddPlayerDetailsAsync(PlayerDetails playerDetails, CancellationToken token);
    Task<PlayerScoreDetails> GetScoresAsync(Guid gameID, Guid playerID, CancellationToken token);
    Task<PlayerDetails[]> GetPlayersAsync(CancellationToken token);
    Task<GameDetails[]> GetGamesAsync(CancellationToken token);
}