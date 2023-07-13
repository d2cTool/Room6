using AutoMapper;
using Services.PlayerRating.Models;
using Services.PlayerRating.Models.BLL;
using Services.PlayerRating.Models.Presentation;

namespace Services.PlayerRating;

public class ModelProfile:Profile
{
    public ModelProfile()
    {
        CreateMap<ScoreDetails, ScoreModelDTO>().ReverseMap();
        CreateMap<PlayerRatingItem, PlayerRatingItemDTO>();
        CreateMap<Models.BLL.PlayerRatingDetails, PlayerRatingDTO>();
    }
}