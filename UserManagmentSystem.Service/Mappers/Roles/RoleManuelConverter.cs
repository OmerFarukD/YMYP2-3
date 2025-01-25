using UserManagmentSystem.Models.Dtos.Roles;
using UserManagmentSystem.Models.Entities;

namespace UserManagmentSystem.Service.Mappers.Roles;

public sealed class RoleManuelConverter : IRoleMapper
{
    public RoleResponseDto ConvertToResponse(Role role)
    {
        return new RoleResponseDto(role.Id, role.Name, role.CreatedDate, role.UpdatedDate);
    }

    public List<RoleResponseDto> ConvertToResponseList(List<Role> roles)
    {

        List<RoleResponseDto> responses = new();
        foreach (Role role in roles)
        {
            RoleResponseDto dto = ConvertToResponse(role);
            responses.Add(dto);
        }
        return responses;
    }

    public Role CovertToEntity(RoleAddRequestDto dto)
    {
        Role role = new Role
        {
            Name = dto.Name
        };

        return role;

    }

    public Role CovertToEntity(RoleUpdateRequestDto dto)
    {
        Role role = new Role
        {
            Id = dto.Id,
            Name = dto.Name
        };

        return role;
    }
}
