using MediatR;
using OData.Application.Repositories.User;

namespace OData.Application.User.UpdateReadUser;

public class UpdateReadUserCommandHandler : IRequestHandler<UpdateReadUserCommand>
{
    private readonly IReadUserRepository _repository;

    public UpdateReadUserCommandHandler(IReadUserRepository repository)
    {
        _repository = repository;
    }

    public async Task Handle(UpdateReadUserCommand request, CancellationToken cancellationToken)
    {
        var result = await _repository.SaveOrUpdateUserAsync(ReadUserModel.CreateNewReadUser(request.AggregateRootId, request.FirstName, request.LastName, request.UserName, request.Version), cancellationToken);

        if (string.IsNullOrEmpty(result))
        {
            //could not save / update read model
        }
    }
}