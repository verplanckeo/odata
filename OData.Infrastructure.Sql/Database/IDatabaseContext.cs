using OData.Infrastructure.Sql.Entities;
using OData.Infrastructure.Sql.Entities.User;
using Microsoft.EntityFrameworkCore;

namespace OData.Infrastructure.Sql.Database;

public interface IDatabaseContext
{
    /// <summary>
    /// Commit changes to database.
    /// </summary>
    /// <param name="token">Cancellation token in case process is interrupted.</param>
    /// <returns></returns>
    Task<int> SaveChangesAsync(CancellationToken token = default);

    /// <summary>
    /// Domain events stored in event store db.
    /// </summary>
    DbSet<EventStoreRecord> EventStoreRecords { get; set; }

    /// <summary>
    /// Get overview of users based on it's read model.
    /// </summary>
    DbSet<ReadUser> ReadUsers { get; set; }
}