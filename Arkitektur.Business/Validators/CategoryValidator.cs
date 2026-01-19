using Arkitektur.Entity.Entities;
using FluentValidation;

namespace Arkitektur.Business.Validators;

public class CategoryValidator : AbstractValidator<Category>
{
    public CategoryValidator()
    {
        RuleFor(x => x.CategoryName).NotEmpty();
    }
}
