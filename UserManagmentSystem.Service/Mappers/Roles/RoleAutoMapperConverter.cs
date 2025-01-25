using AutoMapper;
using UserManagmentSystem.Models.Dtos.Roles;
using UserManagmentSystem.Models.Entities;

namespace UserManagmentSystem.Service.Mappers.Roles
{
    public sealed class RoleAutoMapperConverter : IRoleMapper
    {
        private readonly IMapper _mapper;

        public RoleAutoMapperConverter(IMapper mapper)
        {
            _mapper = mapper;
        }

        public RoleResponseDto ConvertToResponse(Role role)
        {
            return _mapper.Map<RoleResponseDto>(role);
        }

        public List<RoleResponseDto> ConvertToResponseList(List<Role> roles)
        {
            return _mapper.Map<List<RoleResponseDto>>(roles);
        }

        public Role CovertToEntity(RoleAddRequestDto dto)
        {
            return _mapper.Map<Role>(dto);
        }

        public Role CovertToEntity(RoleUpdateRequestDto dto)
        {
            return _mapper.Map<Role>(dto);
        }
    }
}
