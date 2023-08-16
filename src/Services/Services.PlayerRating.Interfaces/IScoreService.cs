namespace Services.PlayerRating.Models.BLL;

public interface IScoreService
{
    Task<IScoreDetails> AddScoreAsync(IScoreDetails details, CancellationToken token =default);
    Task<IPlayerRatingDetails?> GetPlayerRank(Guid gameID, CancellationToken token);
    Task<IGameDetails> AddGameAsync(IGameDetails details, CancellationToken token);
    Task<IPlayerDetails> AddPlayerDetailsAsync(IPlayerDetails playerDetails, CancellationToken token);
    Task<IPlayerScoreDetails> GetScoresAsync(Guid gameID, Guid playerID, CancellationToken token);
    Task<IPlayerDetails[]> GetPlayersAsync(CancellationToken token);
    Task<IGameDetails[]> GetGamesAsync(CancellationToken token);
}