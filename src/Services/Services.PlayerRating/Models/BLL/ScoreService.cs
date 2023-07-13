using AutoMapper;
using AutoMapper.QueryableExtensions;
using Microsoft.EntityFrameworkCore;
using Services.PlayerRating.Models.BLL;
using Services.PlayerRating.Models.DAL;
using Services.PlayerRating.Models.DAL.Entity;

namespace Services.PlayerRating.BLL;

public class ScoreService : IScoreService
{
    private readonly IRepository<Scores> _scoreRepository;
    private readonly IRepository<Games> _gamesRepository;
    private readonly IRepository<Players> _playersRepository;
    private readonly IUnitOfWork _unitOfWork;
    private readonly IMapper _mapper;

    public ScoreService(IMapper mapper, IRepository<Games> gamesRepository, IUnitOfWork unitOfWork, IRepository<Scores> scoreRepository, IRepository<Players> playersRepository)
    {
        _mapper = mapper;
        _gamesRepository = gamesRepository;
        _unitOfWork = unitOfWork;
        _scoreRepository = scoreRepository;
        _playersRepository = playersRepository;
    }

    public async Task<ScoreDetails> AddScoreAsync(ScoreDetails details, CancellationToken token =default)
    {
        var score = _mapper.Map<Scores>(details);
        _scoreRepository.Insert(score);
        await _unitOfWork.SaveAsync(token);
        _mapper.Map(score, details);
        return details;
    }

    public async Task<GameDetails> AddGameAsync(GameDetails details, CancellationToken token)
    {
        var game = _mapper.Map<Games>(details);
        _gamesRepository.Insert(game);
        await _unitOfWork.SaveAsync(token);
        _mapper.Map(game, details);
        return details;
    }

    public async Task<PlayerDetails> AddPlayerDetailsAsync(PlayerDetails playerDetails, CancellationToken token)
    {
        var player = _mapper.Map<Players>(playerDetails);
        _playersRepository.Insert(player);
        await _unitOfWork.SaveAsync(token);
        _mapper.Map(player, playerDetails);
        return playerDetails;
    }


    public async Task<PlayerScoreDetails> GetScoresAsync(Guid gameID, Guid playerID, CancellationToken token)
    {
        var scores = await _scoreRepository.Query().Where(x => x.GameID == gameID && x.PlayerID == playerID)
            .ProjectTo<PlayerScoreDetails>(_mapper.ConfigurationProvider)
            .FirstOrDefaultAsync(token);
        return scores;
    }

    public async Task<PlayerDetails[]> GetPlayersAsync(CancellationToken token)
    {
        return await _playersRepository.Query().ProjectTo<PlayerDetails>(_mapper.ConfigurationProvider).ToArrayAsync(token);
    }

    public async Task<GameDetails[]> GetGamesAsync(CancellationToken token)
    {
        return await _gamesRepository.Query().ProjectTo<GameDetails>(_mapper.ConfigurationProvider).ToArrayAsync(token);

    }

    public async Task<PlayerRatingDetails?> GetPlayerRank(Guid gameID, CancellationToken token)
    {
        var scores =  await _scoreRepository.Query().Where(x => x.GameID == gameID)
            .ProjectTo<PlayerRatingItem>(_mapper.ConfigurationProvider)
            .ToArrayAsync(token);
        var game = await _gamesRepository.FirstOrDefaultAsync(x => x.ID == gameID, token);
        if (game != null)
        {
            var playerRating = _mapper.Map<PlayerRatingDetails>(game);

            if (scores != null)
            {
                
                var rating = scores.OrderByDescending(x => x.Score).ToArray();
                var i = 1;
                foreach (var item in rating)
                {
                    item.Rank = i;
                    i++;
                }
                playerRating.PlayerRank = rating;
                return playerRating;
            }
        }

        return null;
    }
}