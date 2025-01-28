using AutoMapper;
using UserManagmentSystem.Models.Dtos.UserRoles;
using UserManagmentSystem.Models.Entities;
using UserManagmentSystem.Repository.Repositories.Abstracts;
using UserManagmentSystem.Service.Abstracts;
using UserManagmentSystem.Service.Exceptions.Types;

namespace UserManagmentSystem.Service.Concretes;

public sealed class UserRoleService(IUserRoleRepository userRoleRepository,
    IRoleService roleService,
    IUserService userService,
    IMapper mapper) : IUserRoleService
{
    public void Add(UserRoleAddRequestDto addRequestDto)
    {

        bool isPresent = userRoleRepository.ExistsUserRole(addRequestDto.UserId,addRequestDto.RoleId);
        if (isPresent)
        {
            throw new BusinessException("Kullanıcıya aynı rolü ekleyemezsiniz.");
        }
        
        var user = userService.GetByIdForUpdate(addRequestDto.UserId);
        var role = roleService.GetByIdForUpdate(addRequestDto.RoleId);
        
        UserRole userRole = mapper.Map<UserRole>(addRequestDto);
        userRole.User = user;
        userRole.Role = role;
        userRoleRepository.Add(userRole);
    }

    public void Update(UserRoleUpdateRequestDto userRoleUpdateRequestDto)
    {
        UserRole userRole = mapper.Map<UserRole>(userRoleUpdateRequestDto);
        userRoleRepository.Add(userRole);
    }

    public List<UserRoleResponseDto> GetAll()
    {
        List<UserRole> userRoles = userRoleRepository.GetAll();
        List<UserRoleResponseDto> responses = mapper.Map<List<UserRoleResponseDto>>(userRoles);
        return responses;
    }

    public UserRoleResponseDto? GetById(long id)
    {
        var userRole = userRoleRepository.GetById(id);
        if (userRole is null)
        {
            throw new NotFoundException("İlgili Id ye göre Kullanıcı rolü bulunamadı.");
        }
        
        UserRoleResponseDto dto = mapper.Map<UserRoleResponseDto>(userRole);
        return dto;
    }

    public UserRole? GetByIdForUpdate(long id)
    {
        var userRole = userRoleRepository.GetById(id);
        if (userRole is null)
        {
            throw new NotFoundException("İlgili Id ye göre Kullanıcı rolü bulunamadı.");
        }

        return userRole;
    }

    public List<UserRoleIndexDto> GetRolesAndUsers()
    {
        var users = userService.GetAllDetails();
        List<UserRoleIndexDto> responses = new List<UserRoleIndexDto>();
        users.ForEach(u =>
        {
            UserRoleIndexDto dto = new UserRoleIndexDto()
            {
                Id = u.Id,
                Email = u.Email,
                Role = u.Roles,
                Username = u.Username
            };
            responses.Add(dto);
        });
        return responses;
    }

    public void Delete(long id)
    {
        var userRole = userRoleRepository.GetById(id);
        if (userRole is null)
        {
            throw new NotFoundException("İlgili Id ye göre Kullanıcı rolü bulunamadı.");
        }
        userRoleRepository.Delete(userRole);
    }
}