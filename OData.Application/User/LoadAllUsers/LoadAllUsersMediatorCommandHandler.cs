using MediatR;
using OData.Application.Repositories.User;

namespace OData.Application.User.LoadAllUsers;

public class LoadAllUsersMediatorCommandHandler : IRequestHandler<LoadAllUsersMediatorCommand, LoadAllUsersMediatorCommandResponse>
{
    private readonly IReadUserRepository _repository;

    public LoadAllUsersMediatorCommandHandler(IReadUserRepository repository)
    {
        _repository = repository;
    }

    public async Task<LoadAllUsersMediatorCommandResponse> Handle(LoadAllUsersMediatorCommand request, CancellationToken cancellationToken)
    {
        var users = await _repository.LoadUsersAsync(cancellationToken);

        return LoadAllUsersMediatorCommandResponse.CreateResponse(users);
    }
}