using Services.PlayerRating.Models.BLL;

namespace WebApp.Server.Services;

public class ScoreService:IScoreService
{
    public Task<IScoreDetails> AddScoreAsync(IScoreDetails details, CancellationToken token = default)
    {
        throw new NotImplementedException();
    }

    public Task<IPlayerRatingDetails?> GetPlayerRank(Guid gameID, CancellationToken token)
    {
        throw new NotImplementedException();
    }

    public Task<IGameDetails> AddGameAsync(IGameDetails details, CancellationToken token)
    {
        throw new NotImplementedException();
    }

    public Task<IPlayerDetails> AddPlayerDetailsAsync(IPlayerDetails playerDetails, CancellationToken token)
    {
        throw new NotImplementedException();
    }

    public Task<IPlayerScoreDetails> GetScoresAsync(Guid gameID, Guid playerID, CancellationToken token)
    {
        throw new NotImplementedException();
    }

    public Task<IPlayerDetails[]> GetPlayersAsync(CancellationToken token)
    {
        throw new NotImplementedException();
    }

    public Task<IGameDetails[]> GetGamesAsync(CancellationToken token)
    {
        throw new NotImplementedException();
    }
}