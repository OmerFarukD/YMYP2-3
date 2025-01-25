using UserManagmentSystem.Models.Entities;
using UserManagmentSystem.Repository.Contexts;
using UserManagmentSystem.Repository.Repositories.Abstracts;

namespace UserManagmentSystem.Repository.Repositories.Concretes;


// Repository Pattern 
// S -> Single Responsibility 
// O -> Open Closed 
// L -> Liskov Substitution
// I -> Interface Segregation
// D - Dependency Inversion 
public sealed class RoleRepository(BaseDbContext context) : IRoleRepository
{

    // readonly vs const arasındaki fark nedir ? 

    public Role Add(Role role)
    {
        role.CreatedDate = DateTime.UtcNow;
        context.Roles.Add(role);
        context.SaveChanges();

        return role;

    }

    public Role Delete(Role role)
    {
        context.Roles.Remove(role);
        context.SaveChanges();
        return role;
    }

    public List<Role> GetAll()
    {
        return context.Roles.ToList();
    }

    public Role? GetById(int id)
    {
        return context.Roles.Find(id);
    }

    public Role Update(Role role)
    {
        role.UpdatedDate = DateTime.UtcNow;
        context.Roles.Update(role);
        context.SaveChanges();

        return role;
    }
}
