using System.Runtime.CompilerServices;
using System.Text;
using AutoMapper;
using Newtonsoft.Json;
using RabbitMQ.Client.Events;
using Services.PlayerRating.Models.BLL;

namespace Services.PlayerRating.Models.Presentation;

public class ScoresMQRepository
{
    private readonly IMapper _mapper;
    private readonly IScoreService _service;
    private readonly IRabbitMQRepository _repository;

    public ScoresMQRepository(IMapper mapper, IScoreService service, IRabbitMQRepository repository)
    {
        _mapper = mapper;
        _service = service;
        _repository = repository;
    }

    
}