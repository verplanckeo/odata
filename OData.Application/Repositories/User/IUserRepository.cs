using OData.Core.Domain.User;

namespace OData.Application.Repositories.User;

public interface IUserRepository
{
    Task<UserId> SaveUserAsync(Core.Domain.User.User user, CancellationToken cancellationToken);

    Task<Core.Domain.User.User> LoadUserAsync(string id, CancellationToken cancellationToken);
}