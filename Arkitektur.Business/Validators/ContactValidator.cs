using Arkitektur.Entity.Entities;
using FluentValidation;

namespace Arkitektur.Business.Validators;

public class ContactValidator : AbstractValidator<Contact>
{
    public ContactValidator()
    {
        @RuleFor(x => x.Address).NotEmpty();
        @RuleFor(x => x.PhoneNumber).NotEmpty();
        @RuleFor(x => x.Email).NotEmpty().EmailAddress();
        @RuleFor(x => x.MapUrl).NotEmpty();
    }
}