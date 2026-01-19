using Arkitektur.Business.DTOs.ProjectDtos;

namespace Arkitektur.Business.DTOs.CategoryDtos;

public record ResultCategoryDto(int Id, string CategoryName, IList<ResultProjectDto> Projects);
