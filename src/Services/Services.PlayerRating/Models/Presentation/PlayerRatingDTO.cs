namespace Services.PlayerRating.Models.Presentation;

public class PlayerRatingDTO
{
    public string  GameName { get; set; }
    
    public PlayerRatingItemDTO[] Ranks { get; set; }
}