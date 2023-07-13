namespace Services.PlayerRating.Models.BLL;

public class ScoreRequestDetails
{
    /// <summary>
    /// Идентификатор игрока
    /// Player identitfier
    /// </summary>
    public Guid PlayerID { get; set; }

    /// <summary>
    /// Идкнтификатор игры
    /// Tournament identifoer
    /// </summary>
    public Guid GameID { get; set; }
}