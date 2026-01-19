namespace Arkitektur.Business.DTOs.ProjectDtos;

public record UpdateProjectDto(int Id,
                               string ImageUrl,
                               string Title,
                               string Description,
                               string Item1,
                               string Item2,
                               string Item3,
                               int CategoryId);
