using Arkitektur.Business.DTOs.CategoryDtos;

namespace Arkitektur.Business.DTOs.ProjectDtos;

public record ResultProjectDto(string ImageUrl,
                               string Title,
                               string Description,
                               string Item1,
                               string Item2,
                               string Item3,
                               int CategoryId,
                               ResultCategoryDto Category);