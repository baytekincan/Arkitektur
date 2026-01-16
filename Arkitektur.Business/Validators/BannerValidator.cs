using Arkitektur.Entity.Entities;
using FluentValidation;

namespace Arkitektur.Business.Validators
{
    public class BannerValidator : AbstractValidator<Banner>
    {
        public BannerValidator()
        {
            RuleFor(x => x.Title).NotEmpty();
            RuleFor(x => x.Description).NotEmpty();
            RuleFor(x => x.ImageUrl).NotEmpty();
        }
    }
}
