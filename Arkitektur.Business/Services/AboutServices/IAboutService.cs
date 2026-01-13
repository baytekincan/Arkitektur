using Arkitektur.Business.Base;
using Arkitektur.Business.DTOs.AboutDtos;

namespace Arkitektur.Business.Services.AboutServices
{
    public interface IAboutService
    {
        Task<BaseResult<List<ResultAboutDto>>> GetAllAsync();
        Task<BaseResult<ResultAboutDto>> GetByIdAsync(int id);
        Task<BaseResult<object>> CreateAsync(CreateAboutDto createAboutDto);
        Task<BaseResult<object>> DeleteAsync(int id);
        Task<BaseResult<object>> UpdateAsync(UpdateAboutDto updateAboutDto);
    }
}
