using Microsoft.EntityFrameworkCore;
using Newtonsoft.Json;
using OData.Application.Repositories;
using OData.Infrastructure.Sql.Database;
using OData.Infrastructure.Sql.Entities;
using OData.Shared.Domain;
using Formatting = System.Xml.Formatting;

namespace OData.Services.Repositories;

public class EventStoreRepository : IEventStoreRepository
{
    private readonly IDatabaseContext _dbContext;

    private readonly JsonSerializerSettings _jsonSettings = new JsonSerializerSettings
    {
        TypeNameHandling = TypeNameHandling.All,
        NullValueHandling = NullValueHandling.Ignore
    };

    public EventStoreRepository(IDatabaseContext dbContext)
    {
        _dbContext = dbContext;
    }

    public async Task SaveAsync(IEntityId aggregateId, int originatingVersion, IReadOnlyCollection<IDomainEvent> events, string aggregateName, CancellationToken cancellationToken)
    {
        if (!events.Any()) return;
        
        var records = events.Select(evt => EventStoreRecord.CreateRecord(
            recordId : Guid.NewGuid(),
            serializedData: JsonConvert.SerializeObject(evt, Newtonsoft.Json.Formatting.Indented, _jsonSettings),
            version: ++originatingVersion,
            createdAt: evt.CreatedAt,
            domainEventName: evt.GetType().Name,
            aggregateName: aggregateName,
            aggregateRootId: aggregateId.ToString()
        ));

        await _dbContext.EventStoreRecords.AddRangeAsync(records, cancellationToken);
        await _dbContext.SaveChangesAsync(cancellationToken);
    }

    public async Task<IReadOnlyCollection<IDomainEvent>> LoadAsync(IEntityId aggregateRootId, CancellationToken cancellationToken)
    {
        if(aggregateRootId == null) throw new AggregateException($"{nameof(aggregateRootId)} cannot be null");

        var events = await _dbContext.EventStoreRecords.Where(record => record.AggregateRootId == aggregateRootId.ToString())
            .OrderBy(record => record.Version).ToListAsync(cancellationToken).ConfigureAwait(false);

        return events.Select(Transform).ToList().AsReadOnly();
    }

    private IDomainEvent Transform(EventStoreRecord record)
    {
        var data = JsonConvert.DeserializeObject(record.Data, _jsonSettings);
        var evt = data as IDomainEvent;

        return evt;
    }
}