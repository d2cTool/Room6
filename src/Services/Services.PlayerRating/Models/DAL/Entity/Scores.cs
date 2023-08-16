using System.ComponentModel.DataAnnotations.Schema;

namespace Services.PlayerRating.Models.DAL.Entity;

public class Scores
{
    public Guid ID { get; set; }
    public Guid PlayerID { get; set; }

    public Guid GameID { get; set; }
    public long Score { get; set; }
    
    [ForeignKey(nameof(GameID))]
    public virtual Games Game { get; set; }

    [ForeignKey(nameof(PlayerID))]
    public virtual Players? Player { get; set; }
    
}