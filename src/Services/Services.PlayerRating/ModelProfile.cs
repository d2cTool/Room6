using AutoMapper;
using Services.PlayerRating.Models;
using Services.PlayerRating.Models.BLL;
using Services.PlayerRating.Models.DAL.Entity;
using Services.PlayerRating.Models.Presentation;

namespace Services.PlayerRating;

public class ModelProfile:Profile
{
    public ModelProfile()
    {
        CreateMap<ScoreDetails, ScoreModelDTO>().ReverseMap();
        CreateMap<IScoreDetails, Scores>();
        CreateMap<Scores, ScoreDetails>();
        CreateProjection<Scores, ScoreDetails>();
        CreateMap<Scores, IScoreDetails>().As<ScoreDetails>();
        CreateProjection<Scores, PlayerScoreDetails>();
        CreateProjection<Scores, PlayerRatingItem>();
        CreateMap<Games, GameDetails>();
        CreateMap<IGameDetails, Games>();
        CreateMap<Games, GameDetails>();
        CreateMap<Games, IGameDetails>().As<GameDetails>();
        CreateMap<IPlayerDetails, Players>();
        CreateMap<Players, PlayerDetails>();
        CreateProjection<Players, PlayerDetails>();
        CreateMap<Players,IPlayerDetails>().As<PlayerDetails>();
        CreateProjection<Scores, PlayerScoreDetails>();
        CreateMap<PlayerRatingItem, PlayerRatingItemDTO>();
        CreateMap<PlayerRatingDetails, PlayerRatingDTO>();
    }
}