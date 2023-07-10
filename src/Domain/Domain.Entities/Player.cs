namespace Domain.Entities
{
    public class Player
    {
        public required long Id { get; init; }

        public required string UserName { get; set; } = default!;
    }
}
