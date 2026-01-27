using Arkitektur.Business.Base;
using Arkitektur.Business.DTOs.FeatureDtos;
using Arkitektur.DataAccess.Repositories;
using Arkitektur.DataAccess.UOW;
using Arkitektur.Entity.Entities;
using FluentValidation;
using Mapster;

namespace Arkitektur.Business.Services.FeatureServices;

public class FeatureService(IGenericRepository<Feature> _repository, IUnitOfWork _unitOfWork, IValidator<Feature> _validator) : IFeatureService
{
    public async Task<BaseResult<object>> CreateAsync(CreateFeatureDto createFeatureDto)
    {
        var feature = createFeatureDto.Adapt<Feature>();
        var validationResult = await _validator.ValidateAsync(feature);
        if (!validationResult.IsValid)
        {
            return BaseResult<object>.Fail(validationResult.Errors);
        }
        await _repository.CreateAsync(feature);
        var result = await _unitOfWork.SaveChangesAsync();
        if (result)
        {
            return BaseResult<object>.Success();
        }
        else
        {
            return BaseResult<object>.Fail("Feature could not be created.");
        }
    }

    public async Task<BaseResult<object>> DeleteAsync(int id)
    {
        var value = await _repository.GetByIdAsync(id);
        if (value is null)
        {
            return BaseResult<object>.Fail("Feature not found.");
        }
        _repository.Delete(value);
        var result = await _unitOfWork.SaveChangesAsync();
        if (result)
        {
            return BaseResult<object>.Success();
        }
        else
        {
            return BaseResult<object>.Fail("Feature could not be deleted.");
        }
    }

    public async Task<BaseResult<List<ResultFeatureDto>>> GetAllAsync()
    {
        var values = await _repository.GetListAsync();
        var mappedValues = values.Adapt<List<ResultFeatureDto>>();
        return BaseResult<List<ResultFeatureDto>>.Success(mappedValues);
    }

    public async Task<BaseResult<ResultFeatureDto>> GetByIdAsync(int id)
    {
        var value = await _repository.GetByIdAsync(id);
        if (value is null)
        {
            return BaseResult<ResultFeatureDto>.Fail("Feature not found.");
        }
        var mappedValue = value.Adapt<ResultFeatureDto>();
        return BaseResult<ResultFeatureDto>.Success(mappedValue);
    }

    public async Task<BaseResult<object>> UpdateAsync(UpdateFeatureDto updateFeatureDto)
    {
        var feature = updateFeatureDto.Adapt<Feature>();
        var validationResult = await _validator.ValidateAsync(feature);
        if (!validationResult.IsValid)
        {
            return BaseResult<object>.Fail(validationResult.Errors);
        }
        _repository.Update(feature);
        var result = await _unitOfWork.SaveChangesAsync();
        if (result)
        {
            return BaseResult<object>.Success();
        }
        else
        {
            return BaseResult<object>.Fail("Feature could not be updated.");
        }
    }
}