using UserManagmentSystem.Models.Entities;
using UserManagmentSystem.Repository.Contexts;

namespace UserManagmentSystem.Repository.Repositories.Abstracts;

public interface IUserRoleRepository : IRepository<UserRole,long>
{
    bool ExistsUserRole(Guid userId, int roleId);
}
