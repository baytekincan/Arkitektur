using Arkitektur.Business.Base;
using Arkitektur.Business.DTOs.ChooseDtos;
using Arkitektur.DataAccess.Repositories;
using Arkitektur.DataAccess.UOW;
using Arkitektur.Entity.Entities;
using FluentValidation;
using Mapster;

namespace Arkitektur.Business.Services.ChooseServices;

public class ChooseService(IGenericRepository<Choose> _repository, IUnitOfWork _unitOfWork, IValidator<Choose> _validator) : IChooseService
{
    public async Task<BaseResult<object>> CreateAsync(CreateChooseDto createChooseDto)
    {
        var choose = createChooseDto.Adapt<Choose>();
        var validationResult = await _validator.ValidateAsync(choose);
        if (!validationResult.IsValid)
        {
            return BaseResult<object>.Fail(validationResult.Errors);
        }
        await _repository.CreateAsync(choose);
        var result = await _unitOfWork.SaveChangesAsync();
        if (result)
        {
            return BaseResult<object>.Success();
        }
        else
        {
            return BaseResult<object>.Fail("Choose could not be created.");
        }
    }

    public async Task<BaseResult<object>> DeleteAsync(int id)
    {
        var value = await _repository.GetByIdAsync(id);
        if (value is null)
        {
            return BaseResult<object>.Fail("Choose not found.");
        }
        _repository.Delete(value);
        var result = await _unitOfWork.SaveChangesAsync();
        if (result)
        {
            return BaseResult<object>.Success();
        }
        else
        {
            return BaseResult<object>.Fail("Choose could not be deleted.");
        }
    }

    public async Task<BaseResult<List<ResultChooseDto>>> GetAllAsync()
    {
        var values = await _repository.GetListAsync();
        var mappedValues = values.Adapt<List<ResultChooseDto>>();
        return BaseResult<List<ResultChooseDto>>.Success(mappedValues);
    }

    public async Task<BaseResult<ResultChooseDto>> GetByIdAsync(int id)
    {
        var value = await _repository.GetByIdAsync(id);
        if (value is null)
        {
            return BaseResult<ResultChooseDto>.Fail("Choose not found.");
        }
        var mappedValue = value.Adapt<ResultChooseDto>();
        return BaseResult<ResultChooseDto>.Success(mappedValue);
    }

    public async Task<BaseResult<object>> UpdateAsync(UpdateChooseDto updateChooseDto)
    {
        var choose = updateChooseDto.Adapt<Choose>();
        var validationResult = await _validator.ValidateAsync(choose);
        if (!validationResult.IsValid)
        {
            return BaseResult<object>.Fail(validationResult.Errors);
        }
        _repository.Update(choose);
        var result = await _unitOfWork.SaveChangesAsync();
        if (result)
        {
            return BaseResult<object>.Success();
        }
        else
        {
            return BaseResult<object>.Fail("Choose could not be updated.");
        }
    }
}
