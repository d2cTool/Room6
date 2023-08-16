using AutoMapper;
using Services.PlayerRating.Models.DAL.Entity;
using Services.PlayerRating.Models.Presentation;

namespace Services.PlayerRating.Models.BLL;

public class ScoreProfile:Profile
{
    public ScoreProfile()
    {
        CreateMap<ScoreDetails, Scores>()
            //.ForMember(x=>x.ID, x=>x.Ignore())
            .ForMember(scores=>scores.PlayerID, x=>x.MapFrom(details=>details.PlayerID))
            .ForMember(scores=>scores.GameID,x=>x.MapFrom(details=>details.GameID))
            .ForMember(scores=>scores.Score,x=>x.MapFrom(details=>details.Score))
            .ReverseMap();

        CreateProjection<Scores, PlayerRatingItem>()
            .ForMember(x => x.Score, x => x.MapFrom(y => y.Score))
            .ForMember(x => x.PlayerName, x => x.MapFrom(y => y.Player.Name));

        CreateMap<GameDetails, Games>().ReverseMap();

        CreateMap<GameDTO, GameDetails>().ReverseMap();

        CreateMap<PlayerDTO, PlayerDetails>().ReverseMap();

        CreateMap<PlayerDetails, Players>().ReverseMap();

        CreateMap<Games, PlayerRatingDetails>()
            .ForMember(x => x.GameName, x => x.MapFrom(y => y.Name));

        CreateMap<PlayerRatingDTO, PlayerRatingDetails>()
            .ForMember(x=>x.PlayerRank, x=>x.MapFrom(y=>y.Ranks))
            .ReverseMap();

        CreateMap<ScoreRequestDTO, ScoreRequestDetails>().ReverseMap();

        CreateProjection<Scores, PlayerScoreDetails>()
            .ForMember(x=>x.GameName,x=>x.MapFrom(y=>y.Game.Name))
            .ForMember(x=>x.Score,x=>x.MapFrom(y=>y.Score))
            .ForMember(x=>x.PlayerName, x=>x.MapFrom(y=>y.Player.Name))
            .ForMember(x=>x.GameID,x=>x.MapFrom(y=>y.GameID))
            .ForMember(x=>x.PlayerID,x=>x.MapFrom(y=>y.PlayerID));
        CreateMap<PlayerScoreDetails, PlayerScoreDTO>();
        CreateMap<PlayerRatingItemDTO, PlayerRatingItem>().ReverseMap();
        
        
    }
}