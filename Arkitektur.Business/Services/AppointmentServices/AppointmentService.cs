using Arkitektur.Business.Base;
using Arkitektur.Business.DTOs.AppointmentDtos;
using Arkitektur.DataAccess.Repositories;
using Arkitektur.DataAccess.UOW;
using Arkitektur.Entity.Entities;
using FluentValidation;
using Mapster;

namespace Arkitektur.Business.Services.AppointmentServices
{
    public class AppointmentService(
                                    IGenericRepository<Appointment> _repository,
                                    IUnitOfWork _unitOfWork,
                                    IValidator<Appointment> _validator
                                    ) : IAppointmentService
    {
        public async Task<BaseResult<object>> CreateAsync(CreateAppointmentDto appointmentDto)
        {
            var appointment = appointmentDto.Adapt<Appointment>();
            var validationResult = await _validator.ValidateAsync(appointment);
            if (!validationResult.IsValid)
            {
                return BaseResult<object>.Fail(validationResult.Errors);
            }
            await _repository.CreateAsync(appointment);
            var result = await _unitOfWork.SaveChangesAsync();
            return result ? BaseResult<object>.Success(appointment) : BaseResult<object>.Fail("Create Failed");
        }

        public async Task<BaseResult<object>> DeleteAsync(int id)
        {
            var appointment = await _repository.GetByIdAsync(id);
            if (appointment is null)
            {
                return BaseResult<object>.Fail("Appointment Not Found");
            }
            _repository.Delete(appointment);
            var result = await _unitOfWork.SaveChangesAsync();
            return result ? BaseResult<object>.Success() : BaseResult<object>.Fail("Delete Failed");
        }

        public async Task<BaseResult<List<ResultAppointmentDto>>> GetAllAsync()
        {
            var appointments = await _repository.GetListAsync();
            var mappedResult = appointments.Adapt<List<ResultAppointmentDto>>();
            return BaseResult<List<ResultAppointmentDto>>.Success(mappedResult);
        }

        public async Task<BaseResult<ResultAppointmentDto>> GetByIdAsync(int id)
        {
            var appointment = await _repository.GetByIdAsync(id);
            if (appointment is null)
            {
                return BaseResult<ResultAppointmentDto>.Fail("Appointment Not Found");
            }
            var mappedResult = appointment.Adapt<ResultAppointmentDto>();
            return BaseResult<ResultAppointmentDto>.Success(mappedResult);
        }

        public async Task<BaseResult<object>> UpdateAsync(UpdateAppointmentDto appointmentDto)
        {
            var appointment = appointmentDto.Adapt<Appointment>();
            var validationResult = await _validator.ValidateAsync(appointment);
            if (!validationResult.IsValid)
            {
                return BaseResult<object>.Fail(validationResult.Errors);
            }

            _repository.Update(appointment);
            var result = await _unitOfWork.SaveChangesAsync();
            return result ? BaseResult<object>.Success() : BaseResult<object>.Fail("Update Failed");
        }
    }
}
