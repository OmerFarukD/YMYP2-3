using UserManagmentSystem.Models.Dtos.Roles;

namespace UserManagmentSystem.Service.Abstracts;

public interface IRoleService
{
    void Add(RoleAddRequestDto dto);
    void Delete(int id);

    RoleResponseDto? GetById(int id);

    List<RoleResponseDto> GetAll();

    void Update(RoleUpdateRequestDto dto);
}
