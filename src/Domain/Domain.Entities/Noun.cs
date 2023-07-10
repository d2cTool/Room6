namespace Domain.Entities
{
    public class Noun
    {
        public required long Id { get; init; }

        public required string Name { get; init; } = null!;
    }
}
