namespace Arkitektur.Business.DTOs.ContactDtos;

public record UpdateContactDto(int Id, string Address, string PhoneNumber, string Email, string MapUrl);
