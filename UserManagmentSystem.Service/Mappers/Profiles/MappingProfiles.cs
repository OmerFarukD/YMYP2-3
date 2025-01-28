

using AutoMapper;
using UserManagmentSystem.Models.Dtos.Roles;
using UserManagmentSystem.Models.Dtos.UserRoles;
using UserManagmentSystem.Models.Dtos.Users;
using UserManagmentSystem.Models.Entities;

namespace UserManagmentSystem.Service.Mappers.Profiles;

public class MappingProfiles : Profile
{
    public MappingProfiles()
    {
        CreateMap<Role,RoleResponseDto>();
        CreateMap<RoleAddRequestDto, Role>();
        CreateMap<RoleUpdateRequestDto, Role>();
        CreateMap<User, UserResponseDto>();
        
        CreateMap<UserRole, UserRoleResponseDto>().ReverseMap();
        CreateMap<UserRoleAddRequestDto, UserRole>().ReverseMap();
        CreateMap<UserRoleUpdateRequestDto, UserRole>().ReverseMap();

        CreateMap<User, UserDetailResponseDto>()
            .ForMember(x => x.Roles,
                opt =>
                    opt.MapFrom(x=>x.UserRoles.Select(r=>r.Role.Name))
            );
    }
}
