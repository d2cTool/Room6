namespace Domain.Entities
{
    public class Room
    {
        public required long Id { get; init; }

        public required DateTime Created { get; init; }

        public required long OwnerId { get; init; }

        public List<long> OpponentsIds { get; init; } = new List<long>();

        public required long Time { get; init; }
    }
}
