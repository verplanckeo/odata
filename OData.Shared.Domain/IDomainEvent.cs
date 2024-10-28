namespace OData.Shared.Domain
{
    public interface IDomainEvent
    {
        DateTime CreatedAt { get; set; }
    }
}