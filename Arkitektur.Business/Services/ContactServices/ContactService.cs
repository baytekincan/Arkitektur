using Arkitektur.Business.Base;
using Arkitektur.Business.DTOs.ContactDtos;
using Arkitektur.DataAccess.Repositories;
using Arkitektur.DataAccess.UOW;
using Arkitektur.Entity.Entities;
using FluentValidation;
using Mapster;

namespace Arkitektur.Business.Services.ContactServices;

public class ContactService(IGenericRepository<Contact> _repository, IUnitOfWork _unitOfWork, IValidator<Contact> _validator) : IContactService
{
    public async Task<BaseResult<object>> CreateAsync(CreateContactDto createContactDto)
    {
        var contact = createContactDto.Adapt<Contact>();
        var validationResult = await _validator.ValidateAsync(contact);
        if (!validationResult.IsValid)
        {
            return BaseResult<object>.Fail(validationResult.Errors);
        }
        await _repository.CreateAsync(contact);
        var result = await _unitOfWork.SaveChangesAsync();
        if (result)
        {
            return BaseResult<object>.Success();
        }
        else
        {
            return BaseResult<object>.Fail("Contact could not be created.");
        }
    }

    public async Task<BaseResult<object>> DeleteAsync(int id)
    {
        var value = await _repository.GetByIdAsync(id);
        if (value is null)
        {
            return BaseResult<object>.Fail("Contact not found.");
        }
        _repository.Delete(value);
        var result = await _unitOfWork.SaveChangesAsync();
        if (result)
        {
            return BaseResult<object>.Success();
        }
        else
        {
            return BaseResult<object>.Fail("Contact could not be deleted.");
        }
    }

    public async Task<BaseResult<List<ResultContactDto>>> GetAllAsync()
    {
        var values = await _repository.GetListAsync();
        var mappedValues = values.Adapt<List<ResultContactDto>>();
        return BaseResult<List<ResultContactDto>>.Success(mappedValues);
    }

    public async Task<BaseResult<ResultContactDto>> GetByIdAsync(int id)
    {
        var value = await _repository.GetByIdAsync(id);
        if (value is null)
        {
            return BaseResult<ResultContactDto>.Fail("Contact not found.");
        }
        var mappedValue = value.Adapt<ResultContactDto>();
        return BaseResult<ResultContactDto>.Success(mappedValue);
    }

    public async Task<BaseResult<object>> UpdateAsync(UpdateContactDto updateContactDto)
    {
        var contact = updateContactDto.Adapt<Contact>();
        var validationResult = await _validator.ValidateAsync(contact);
        if (!validationResult.IsValid)
        {
            return BaseResult<object>.Fail(validationResult.Errors);
        }
        _repository.Update(contact);
        var result = await _unitOfWork.SaveChangesAsync();
        if (result)
        {
            return BaseResult<object>.Success();
        }
        else
        {
            return BaseResult<object>.Fail("Contact could not be updated.");
        }
    }
}
