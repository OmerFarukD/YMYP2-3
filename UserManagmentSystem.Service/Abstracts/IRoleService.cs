using UserManagmentSystem.Models.Dtos.Roles;
using UserManagmentSystem.Models.Entities;

namespace UserManagmentSystem.Service.Abstracts;

public interface IRoleService
{
    void Add(RoleAddRequestDto dto);
    void Delete(int id);

    RoleResponseDto? GetById(int id);

    List<RoleResponseDto> GetAll();

    Role GetByIdForUpdate(int id);

    void Update(RoleUpdateRequestDto dto);
}
