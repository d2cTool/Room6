namespace Domain.Entities
{
    public class Player : Entity<long>
    {
        public string UserName { get; set; } = default!;
    }
}
