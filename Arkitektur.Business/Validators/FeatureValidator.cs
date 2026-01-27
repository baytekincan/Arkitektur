using Arkitektur.Entity.Entities;
using FluentValidation;

namespace Arkitektur.Business.Validators;

public class FeatureValidator : AbstractValidator<Feature>
{
    public FeatureValidator()
    {
        @RuleFor(x => x.Description).NotEmpty();
        @RuleFor(x => x.BackgroundImage).NotEmpty();
        @RuleFor(x => x.Icon).NotEmpty();
        @RuleFor(x => x.Title).NotEmpty();
    }
}