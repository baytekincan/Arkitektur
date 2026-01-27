using Arkitektur.Entity.Entities;
using FluentValidation;

namespace Arkitektur.Business.Validators;

public class ChooseValidator : AbstractValidator<Choose>
{
    public ChooseValidator()
    {
        @RuleFor(x => x.Title).NotEmpty();
        @RuleFor(x => x.Description).NotEmpty();
        @RuleFor(x => x.Icon).NotEmpty();
    }
}
