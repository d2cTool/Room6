using AutoMapper;
using MassTransit;
using Services.PlayerRating.Models.BLL;

namespace Services.PlayerRating.Models.Presentation.Rabbit;

public class ScoreModelConsumer:IConsumer<ScoreModelDTO>
{
    private readonly IScoreService _scoreService;
    private readonly IMapper _mapper;

    public ScoreModelConsumer(IScoreService scoreService, IMapper mapper)
    {
        _scoreService = scoreService;
        _mapper = mapper;
    }

    public async Task Consume(ConsumeContext<ScoreModelDTO> context)
    {
        var result = await RunScoresAsync(context.Message);
        await context.RespondAsync(result);
    }
    
    private async Task<IScoreDetails> RunScoresAsync(ScoreModelDTO score, CancellationToken token = default)
    {

        var details = _mapper.Map<ScoreDetails>(score);
        var result = await _scoreService.AddScoreAsync(details, token);
        return result;
    }
}