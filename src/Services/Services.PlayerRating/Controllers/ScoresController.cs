using System.Runtime.CompilerServices;
using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Services.PlayerRating.Models;
using Services.PlayerRating.Models.BLL;
using Services.PlayerRating.Models.Presentation;

namespace Services.PlayerRating.Controllers;

[ApiController]
[Route("[controller]")]
public class ScoresController
{
    private readonly IScoreService _service;
    private readonly IMapper _mapper;

    public ScoresController(IScoreService service, IMapper mapper)
    {
        _service = service;
        _mapper = mapper;
    }

    [HttpGet("Players")]
    public async Task<PlayerDTO[]> GetPlayersAsync(CancellationToken token)
    {
        var result = await _service.GetPlayersAsync(token);
        return _mapper.Map<PlayerDTO[]>(result);
    }

    [HttpPost("Players")]
    public async Task<PlayerDTO> AddPlayerAsync(PlayerDTO player, CancellationToken token)
    {
        var playerDetails = _mapper.Map<PlayerDetails>(player);
        var resultDetails = await _service.AddPlayerDetailsAsync(playerDetails, token);
        _mapper.Map(playerDetails, player);
        return player;
    }

    [HttpGet("Games")]
    public async Task<GameDTO[]> GetGamesAsync(CancellationToken token)
    {
        var games = await _service.GetGamesAsync(token);
        return _mapper.Map<GameDTO[]>(games);
    }

    [HttpPost("Games")]
    public async Task<GameDTO> AddGameAsync(GameDTO gameDto, CancellationToken token)
    {
        var details = _mapper.Map<GameDetails>(gameDto);
        var result = await _service.AddGameAsync(details, token);
        _mapper.Map(result, gameDto);
        return gameDto;
    }
    
    /// <summary>
    /// Записывает значения очков в таблицу чемпионата
    /// Add scores into tournament table
    /// </summary>
    /// <param name="modelDto">Данные очков игрока/Player scores</param>
    /// <param name="token">Токен отмены/Cancellation token</param>
    /// <returns>Записанные очки/Written scores</returns>
    [HttpGet("Players/{playerID}/Games/{gameID}/Scores")]
    public async Task<PlayerScoreDTO> GetScoresAsync(Guid playerID,Guid gameID, CancellationToken token)
    {
        var result = await _service.GetScoresAsync(gameID, playerID, token);
        var resultModel = _mapper.Map<PlayerScoreDTO>(result);
        return resultModel;
    }

    /// <summary>
    /// Записывает значения очков в таблицу чемпионата
    /// Add scores into tournament table
    /// </summary>
    /// <param name="modelDto">Данные очков игрока/Player scores</param>
    /// <param name="token">Токен отмены/Cancellation token</param>
    /// <returns>Записанные очки/Written scores</returns>
    [HttpPost("Scores")]
    public async Task<ScoreModelDTO> AddScoresAsync(ScoreModelDTO modelDto, CancellationToken token)
    {
        var details = _mapper.Map<ScoreDetails>(modelDto);
        var result = await _service.AddScoreAsync(details, token);
        var resultModel = _mapper.Map<ScoreModelDTO>(result);
        return resultModel;
    }

    [HttpGet("Ranks/{gameID}")]
    public async Task<PlayerRatingDTO> GetRatingAsync(Guid gameID, CancellationToken token)
    {
        var details = await _service.GetPlayerRank(gameID, token);
        var result = _mapper.Map<PlayerRatingDTO>(details);
        return result;
    }

}