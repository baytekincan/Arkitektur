using Arkitektur.Entity.Entities;
using FluentValidation;

namespace Arkitektur.Business.Validators
{
    public class AppointmentValidator : AbstractValidator<Appointment>
    {
        public AppointmentValidator()
        {
            RuleFor(x => x.Email).NotEmpty().EmailAddress();
            RuleFor(x => x.PhoneNumber).NotEmpty();
            RuleFor(x => x.NameSurname).NotEmpty().MinimumLength(3);
            RuleFor(x => x.Message).NotEmpty().MaximumLength(300);
            RuleFor(x => x.ServiceName).NotEmpty();
            RuleFor(x => x.AppointmentDate).NotEmpty();
        }
    }
}
