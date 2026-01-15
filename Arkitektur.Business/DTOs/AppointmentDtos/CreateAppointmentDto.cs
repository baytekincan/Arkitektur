using Arkitektur.Entity.Enums;

namespace Arkitektur.Business.DTOs.AppointmentDtos
{
    public record CreateAppointmentDto(
        string NameSurname,
        string Email,
        DateTime AppointmentDate,
        string PhoneNumber,
        string ServiceName,
        string Message,
        AppointmentStatus Status = 0
    );
}
