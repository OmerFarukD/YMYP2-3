using UserManagmentSystem.Models.Entities;

namespace UserManagmentSystem.Repository.Repositories.Abstracts;

public interface IRoleRepository : IRepository<Role,int>
{


    int CountByRoleName(string roleName);

    bool ExistsByRoleName(string roleName);
}
