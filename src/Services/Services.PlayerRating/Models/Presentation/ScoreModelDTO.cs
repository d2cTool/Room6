namespace Services.PlayerRating.Models.Presentation;

/// <summary>
/// Очки игрока в данном чемпионате
/// Tournament player scores
/// </summary>
public class ScoreModelDTO
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

    /// <summary>
    /// Очки
    /// Score
    /// </summary>
    public long Score { get; set; }
    
}