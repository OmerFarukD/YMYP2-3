using UserManagmentSystem.Models.Entities;

namespace UserManagmentSystem.Repository.Repositories.Abstracts;

// DRY -> Don t Repeat Yourself
public interface IUserRepository : IRepository<User,Guid>
{
 
}
