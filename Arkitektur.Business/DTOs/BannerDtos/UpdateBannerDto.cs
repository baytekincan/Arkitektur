namespace Arkitektur.Business.DTOs.BannerDtos;
public record UpdateBannerDto(
    int Id,
    string Title,
    string Description,
    string ImageUrl);