namespace Arkitektur.Business.DTOs.RoleAssingDtos;

public class AssingRoleDto
{
    public int UserId { get; set; }
    public int RoleId { get; set; }
    public string RoleName { get; set; }
    public bool RoleExist { get; set; }
}
