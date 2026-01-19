using Arkitektur.Business.Base;
using Arkitektur.Business.DTOs.ProjectDtos;
using Arkitektur.DataAccess.Repositories;
using Arkitektur.DataAccess.UOW;
using Arkitektur.Entity.Entities;
using FluentValidation;
using Mapster;
using Microsoft.EntityFrameworkCore;

namespace Arkitektur.Business.Services.ProjectServices;

public class ProjectService(IGenericRepository<Project> _repository, IUnitOfWork _unitOfWork, IValidator<Project> _validator) : IProjectService
{
    public async Task<BaseResult<object>> CreateAsync(CreateProjectDto createProjectDto)
    {
        var value = createProjectDto.Adapt<Project>();
        if (value is null) { return BaseResult<object>.Fail("Mapping Failed"); }
        await _repository.CreateAsync(value);
        var result = await _unitOfWork.SaveChangesAsync();
        return result ? BaseResult<object>.Success(value) : BaseResult<object>.Fail("Create Failed");
    }

    public async Task<BaseResult<object>> DeleteAsync(int id)
    {
        var value = await _repository.GetByIdAsync(id);
        if (value is null) { return BaseResult<object>.Fail("Project Not Found"); }
        _repository.Delete(value);
        var result = await _unitOfWork.SaveChangesAsync();
        return result ? BaseResult<object>.Success() : BaseResult<object>.Fail("Delete Failed");
    }

    public async Task<BaseResult<List<ResultProjectDto>>> GetAllAsync()
    {
        var values = await _repository.GetListAsync();
        if (values is null || !values.Any())
        {
            return BaseResult<List<ResultProjectDto>>.Fail("No Projects Found");
        }
        var result = values.Adapt<List<ResultProjectDto>>();
        return BaseResult<List<ResultProjectDto>>.Success(result);
    }

    public async Task<BaseResult<ResultProjectDto>> GetByIdAsync(int id)
    {
        var value = await _repository.GetByIdAsync(id);
        if (value is null) { return BaseResult<ResultProjectDto>.Fail("Project Not Found"); }
        var result = value.Adapt<ResultProjectDto>();
        return BaseResult<ResultProjectDto>.Success(result);
    }

    public async Task<BaseResult<List<ResultProjectDto>>> GetProjectsWithCategoriesAsync()
    {
        var queryable = _repository.GetQueryable();
        var values = await queryable.Include(x => x.Category).ToListAsync();
        var mappedResults = values.Adapt<List<ResultProjectDto>>();
        return BaseResult<List<ResultProjectDto>>.Success(mappedResults);

    }

    public async Task<BaseResult<object>> UpdateAsync(UpdateProjectDto updateProjectDto)
    {
        var value = updateProjectDto.Adapt<Project>();
        var validationResult = await _validator.ValidateAsync(value);
        if (!validationResult.IsValid)
        {
            return BaseResult<object>.Fail(validationResult.Errors);
        }
        _repository.Update(value);
        var result = await _unitOfWork.SaveChangesAsync();
        return result ? BaseResult<object>.Success() : BaseResult<object>.Fail("Update Failed");
    }
}