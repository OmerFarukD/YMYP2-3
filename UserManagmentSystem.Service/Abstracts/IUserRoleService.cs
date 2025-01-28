using UserManagmentSystem.Models.Dtos.UserRoles;
using UserManagmentSystem.Models.Entities;

namespace UserManagmentSystem.Service.Abstracts;

public interface IUserRoleService
{
    void Add(UserRoleAddRequestDto addRequestDto);
    void Update(UserRoleUpdateRequestDto userRoleUpdateRequestDto);
    List<UserRoleResponseDto> GetAll();
    UserRoleResponseDto? GetById(long id);

    UserRole? GetByIdForUpdate(long id);

    List<UserRoleIndexDto> GetRolesAndUsers();
    void Delete(long id);
}