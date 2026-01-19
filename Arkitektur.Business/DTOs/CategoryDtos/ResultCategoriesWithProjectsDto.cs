using Arkitektur.Business.DTOs.ProjectDtos;

namespace Arkitektur.Business.DTOs.CategoryDtos;

public record ResultCategoriesWithProjectsDto(int Id, string CategoryName, IList<ProjectDto> Projects);