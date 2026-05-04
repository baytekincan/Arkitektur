using Arkitektur.Business.Base;
using Arkitektur.Business.DTOs.RoleAssingDtos;

namespace Arkitektur.Business.Services.RoleAssignService.cs;

public interface IRoleAssignService
{
    Task<BaseResult<List<AssingRoleDto>>> GetUserForRoleAssignAsync(int id);
    Task<BaseResult<object>> AssingRoleToUserAsync(List<AssingRoleDto> assingRoleDto);
}
