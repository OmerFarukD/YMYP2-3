using UserManagmentSystem.Models.Dtos.Users;
using UserManagmentSystem.Models.Entities;

namespace UserManagmentSystem.Repository.Repositories.Abstracts;

// DRY -> Don t Repeat Yourself
public interface IUserRepository : IRepository<User,Guid>
{

    // SELECT COUNT(*) from Users WHERE username='text' or email='text'
    int CountUserByEmail(string email);
    int CountUserByUsername(string username);

    User? GetByUsername(string username);
    User? GetByEmail(string email);

    List<User> GetAllDetails();
    List<UserDetailResponseDto> GetAllDetails1();
    List<UserDetailResponseDto> GetAllDetails2();

    User? GetDetailsById(Guid id);
    UserDetailResponseDto? GetDetailsById1(Guid id);
    UserDetailResponseDto? GetDetailsById2(Guid id);
}
