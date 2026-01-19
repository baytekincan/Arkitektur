using Arkitektur.Entity.Entities;
using FluentValidation;

namespace Arkitektur.Business.Validators;

public class ProjectValidator : AbstractValidator<Project>
{
    public ProjectValidator()
    {
        @RuleFor(x => x.Title).NotEmpty();
        @RuleFor(x => x.Description).NotEmpty();
        @RuleFor(x => x.Item1).NotEmpty();
        @RuleFor(x => x.Item2).NotEmpty();
        @RuleFor(x => x.Item3).NotEmpty();
        @RuleFor(x => x.CategoryId).NotEmpty();
        @RuleFor(x => x.Category).NotEmpty();
        @RuleFor(x => x.ImageUrl).NotEmpty();
    }
}
