using FluentValidation;

namespace OData.Application.User.LoadSingleUser;

public class LoadSingleUserMediatorQueryValidator : AbstractValidator<LoadSingleUserMediatorQuery>
{
    public LoadSingleUserMediatorQueryValidator()   
    {
        RuleFor(model => model.AggregateRootId)
            .NotNull()
            .NotEmpty()
            .MinimumLength(36);
    }
}