

using AutoMapper;
using UserManagmentSystem.Models.Dtos.Roles;
using UserManagmentSystem.Models.Entities;

namespace UserManagmentSystem.Service.Mappers.Profiles;

public class MappingProfiles : Profile
{
    public MappingProfiles()
    {
        CreateMap<Role,RoleResponseDto>();
        CreateMap<RoleAddRequestDto, Role>();
        CreateMap<RoleUpdateRequestDto, Role>();
    }
}
