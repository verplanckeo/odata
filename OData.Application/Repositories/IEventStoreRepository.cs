using OData.Shared.Domain;

namespace OData.Application.Repositories;

public interface IEventStoreRepository
{
    Task SaveAsync(IEntityId aggregateId, int originatingVersion, IReadOnlyCollection<IDomainEvent> events, string aggregateName, CancellationToken cancellationToken);

    Task<IReadOnlyCollection<IDomainEvent>> LoadAsync(IEntityId aggregateRootId, CancellationToken cancellationToken);
}