using MediatR;
using OData.Application.Mediator;
using OData.Application.Repositories.User;
using OData.Application.User.UpdateReadUser;

namespace OData.Application.User.Register;

public class RegisterUserMediatorCommandHandler : IRequestHandler<RegisterUserMediatorCommand, RegisterUserMediatorCommandResponse>
{
    private readonly IUserRepository _repository;
    private readonly IMediatorFactory _mediatorFactory;

    public RegisterUserMediatorCommandHandler(IUserRepository repository, IMediatorFactory mediatorFactory)
    {
        _repository = repository;
        _mediatorFactory = mediatorFactory;
    }

    public async Task<RegisterUserMediatorCommandResponse> Handle(RegisterUserMediatorCommand request, CancellationToken cancellationToken)
    {
        var scope = _mediatorFactory.CreateScope();

        var domainUser = Core.Domain.User.User.CreateNewUser(request.UserName, request.FirstName, request.LastName);
        var id = await _repository.SaveUserAsync(domainUser, cancellationToken);

        await scope.SendAsync(UpdateReadUserCommand.CreateCommand(id.ToString(), request.FirstName, request.LastName, request.UserName, domainUser.Version), cancellationToken);

        return RegisterUserMediatorCommandResponse.CreateResponse(id.ToString());
    }
}