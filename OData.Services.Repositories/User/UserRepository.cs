using OData.Application.Repositories;
using OData.Application.Repositories.User;
using OData.Core.Domain.User;

namespace OData.Services.Repositories.User;

public class UserRepository(IEventStoreRepository eventStoreRepository) : IUserRepository
{
    public async Task<Core.Domain.User.User> LoadUserAsync(string id, CancellationToken cancellationToken)
    {
        var userId = new UserId(id);
        var events = await eventStoreRepository.LoadAsync(userId, cancellationToken);
        return new Core.Domain.User.User(events);
    }

    public async Task<UserId> SaveUserAsync(Core.Domain.User.User user, CancellationToken cancellationToken)
    {
        await eventStoreRepository.SaveAsync(user.Id, user.Version, user.DomainEvents, "UserAggregateRoot", cancellationToken);
        return user.Id;
    }
}