using Arkitektur.Business.Base;
using Arkitektur.Business.DTOs.CategoryDtos;
using Arkitektur.DataAccess.Repositories;
using Arkitektur.DataAccess.UOW;
using Arkitektur.Entity.Entities;
using FluentValidation;
using Mapster;
using Microsoft.EntityFrameworkCore;

namespace Arkitektur.Business.Services.CategoryServices;

public class CategoryService(IGenericRepository<Category> _repository, IUnitOfWork _unitOfWork, IValidator<Category> _validator) : ICategoryService
{
    public async Task<BaseResult<object>> CreateAsync(CreateCategoryDto createCategoryDto)
    {
        var category = createCategoryDto.Adapt<Category>();
        var validationResult = await _validator.ValidateAsync(category);
        if (!validationResult.IsValid)
        {
            return BaseResult<object>.Fail(validationResult.Errors);
        }
        await _repository.CreateAsync(category);
        var result = await _unitOfWork.SaveChangesAsync();
        if (result)
        {
            return BaseResult<object>.Success();
        }
        else
        {
            return BaseResult<object>.Fail("Category could not be created.");
        }
    }

    public async Task<BaseResult<object>> DeleteAsync(int id)
    {
        var value = await _repository.GetByIdAsync(id);
        if (value is null)
        {
            return BaseResult<object>.Fail("Category not found.");
        }
        _repository.Delete(value);
        var result = await _unitOfWork.SaveChangesAsync();
        if (result)
        {
            return BaseResult<object>.Success();
        }
        else
        {
            return BaseResult<object>.Fail("Category could not be deleted.");
        }
    }

    public async Task<BaseResult<List<ResultCategoryDto>>> GetAllAsync()
    {
        var values = await _repository.GetListAsync();
        var mappedValues = values.Adapt<List<ResultCategoryDto>>();
        return BaseResult<List<ResultCategoryDto>>.Success(mappedValues);
    }

    public async Task<BaseResult<ResultCategoryDto>> GetByIdAsync(int id)
    {
        var value = await _repository.GetByIdAsync(id);
        if (value is null)
        {
            return BaseResult<ResultCategoryDto>.Fail("Category not found.");
        }
        var mappedValue = value.Adapt<ResultCategoryDto>();
        return BaseResult<ResultCategoryDto>.Success(mappedValue);
    }

    public async Task<BaseResult<List<ResultCategoriesWithProjectsDto>>> GetCategoriesWithProjectsAsync()
    {
        var values = await _repository.GetQueryable().Include(x => x.Projects).ToListAsync();
        var mappedValues = values.Adapt<List<ResultCategoriesWithProjectsDto>>();
        return BaseResult<List<ResultCategoriesWithProjectsDto>>.Success(mappedValues);
    }

    public async Task<BaseResult<object>> UpdateAsync(UpdateCategoryDto updateCategoryDto)
    {
        var category = updateCategoryDto.Adapt<Category>();
        var validationResult = await _validator.ValidateAsync(category);
        if (!validationResult.IsValid)
        {
            return BaseResult<object>.Fail(validationResult.Errors);
        }
        _repository.Update(category);
        var result = await _unitOfWork.SaveChangesAsync();
        if (result)
        {
            return BaseResult<object>.Success();
        }
        else
        {
            return BaseResult<object>.Fail("Category could not be updated.");
        }
    }
}
