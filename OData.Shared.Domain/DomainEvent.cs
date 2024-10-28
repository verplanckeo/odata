namespace OData.Shared.Domain
{
    public class DomainEvent : IDomainEvent
    {
        public DateTime CreatedAt { get; set; } = DateTime.UtcNow;
    }
}