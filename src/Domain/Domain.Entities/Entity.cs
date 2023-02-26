namespace Domain.Entities
{
    public class Entity<TId>
    {
        public TId Id { get; set; } = default!;

        public DateTime Created { get; set; }

        public DateTime Updated { get; set; }
    }
}