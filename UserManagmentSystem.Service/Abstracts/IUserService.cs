using UserManagmentSystem.Models.Dtos.Users;
using UserManagmentSystem.Models.Entities;

namespace UserManagmentSystem.Service.Abstracts;

public interface IUserService
{
    void Add(UserAddRequestDto userAddRequestDto);
    void Login(LoginRequestDto loginRequestDto);
    UserDetailResponseDto? GetById(Guid id);
    List<UserDetailResponseDto> GetAllDetails();
    User GetByIdForUpdate(Guid id);
    List<UserResponseDto> GetAllUsers();
    void Delete(Guid id);
    
    
}