using Arkitektur.Business.Base;
using Arkitektur.Business.DTOs.ProjectDtos;

namespace Arkitektur.Business.Services.ProjectServices;

public interface IProjectService
{
    Task<BaseResult<List<ResultProjectDto>>> GetAllAsync();
    Task<BaseResult<List<ResultProjectDto>>> GetProjectsWithCategoriesAsync();
    Task<BaseResult<ResultProjectDto>> GetByIdAsync(int id);
    Task<BaseResult<object>> CreateAsync(CreateProjectDto createProjectDto);
    Task<BaseResult<object>> DeleteAsync(int id);
    Task<BaseResult<object>> UpdateAsync(UpdateProjectDto updateProjectDto);
}
