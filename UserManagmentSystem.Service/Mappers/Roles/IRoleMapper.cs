using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UserManagmentSystem.Models.Dtos.Roles;
using UserManagmentSystem.Models.Entities;

namespace UserManagmentSystem.Service.Mappers.Roles;

public interface IRoleMapper
{

    // Dynamic Polymorphism -> Override
    // Static Polymorphism -> Overloading 

    Role CovertToEntity(RoleAddRequestDto dto);

    Role CovertToEntity(RoleUpdateRequestDto dto);

    RoleResponseDto ConvertToResponse(Role role);

    List<RoleResponseDto> ConvertToResponseList(List<Role> roles);
}
