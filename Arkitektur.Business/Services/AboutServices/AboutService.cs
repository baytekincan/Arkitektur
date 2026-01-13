using Arkitektur.Business.Base;
using Arkitektur.Business.DTOs.AboutDtos;
using Arkitektur.DataAccess.Repositories;
using Arkitektur.DataAccess.UOW;
using Arkitektur.Entity.Entities;
using Mapster;

namespace Arkitektur.Business.Services.AboutServices
{
    public class AboutService(IGenericRepository<About> aboutRepository, IUnitOfWork unitOfWork) : IAboutService
    {
        public async Task<BaseResult<object>> CreateAsync(CreateAboutDto createAboutDto)
        {
            var about = createAboutDto.Adapt<About>();
            await aboutRepository.CreateAsync(about);
            var result = await unitOfWork.SaveChangesAsync();
            return result ? BaseResult<object>.Success(about) : BaseResult<object>.Fail("Create Failed");
        }

        public async Task<BaseResult<object>> DeleteAsync(int id)
        {
            var about = await aboutRepository.GetByIdAsync(id);
            if (about is null)
            {
                return BaseResult<object>.Fail("About not found");
            }
            aboutRepository.Delete(about);
            var result = await unitOfWork.SaveChangesAsync();
            return result ? BaseResult<object>.Success() : BaseResult<object>.Fail("Delete Failed");
        }

        public async Task<BaseResult<List<ResultAboutDto>>> GetAllAsync()
        {
            var abouts = await aboutRepository.GetListAsync();
            var mappedValue = abouts.Adapt<List<ResultAboutDto>>();
            return BaseResult<List<ResultAboutDto>>.Success(mappedValue);
        }

        public async Task<BaseResult<ResultAboutDto>> GetByIdAsync(int id)
        {
            var about = await aboutRepository.GetByIdAsync(id);
            if (about is null)
            {
                return BaseResult<ResultAboutDto>.Fail("About not found");
            }
            var mappedResult = about.Adapt<ResultAboutDto>();
            return BaseResult<ResultAboutDto>.Success(mappedResult);
        }

        public async Task<BaseResult<object>> UpdateAsync(UpdateAboutDto updateAboutDto)
        {
            var about = updateAboutDto.Adapt<About>();
            aboutRepository.Update(about);
            var result = await unitOfWork.SaveChangesAsync();
            return result ? BaseResult<object>.Success(about) : BaseResult<object>.Fail("Update Failed");
        }
    }
}
