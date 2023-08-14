using System.Text;
using AutoMapper;
using Microsoft.Extensions.Options;
using Newtonsoft.Json;
using RabbitMQ.Client.Events;
using Services.PlayerRating.Models.BLL;

namespace Services.PlayerRating.Models.Presentation;

public class QueryListenerService:IHostedService
{
    private readonly IRabbitMQRepository _repository;
    private readonly IScoreService _scoreService;
    private readonly IMapper _mapper;
    private readonly IConnectionInfo? _connectionInfo;

    public QueryListenerService(IRabbitMQRepository repository, IScoreService scoreService, IMapper mapper, IOptions<IConnectionInfo> connectiionInfo)
    {
        _repository = repository;
        _scoreService = scoreService;
        _mapper = mapper;
        _connectionInfo = connectiionInfo?.Value;
    }

    public Task StartAsync(CancellationToken cancellationToken)
    {
        _repository.RunAsync(async args => await RunScores(args, cancellationToken), _connectionInfo, cancellationToken);
        return Task.CompletedTask;
    }

    public Task StopAsync(CancellationToken cancellationToken)
    {
        _repository.Stop();
        return Task.CompletedTask;
    }

    private async Task RunScores(BasicDeliverEventArgs args, CancellationToken token)
    {
        var messageString = Encoding.UTF8.GetString(args.Body.Span);
        var score = JsonConvert.DeserializeObject<ScoreModelDTO>(messageString);

        var details = _mapper.Map<ScoreDetails>(score);
        var result = await _scoreService.AddScoreAsync(details, token);
        _repository.Send(_connectionInfo, result);
    }
}