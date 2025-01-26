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

}
