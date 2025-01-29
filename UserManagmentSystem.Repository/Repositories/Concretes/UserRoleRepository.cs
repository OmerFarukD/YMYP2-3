using System.Runtime.InteropServices.JavaScript;
using Microsoft.EntityFrameworkCore;
using UserManagmentSystem.Models.Entities;
using UserManagmentSystem.Repository.Contexts;
using UserManagmentSystem.Repository.Repositories.Abstracts;

namespace UserManagmentSystem.Repository.Repositories.Concretes;

public sealed class UserRoleRepository(BaseDbContext context) : IUserRoleRepository
{
    public UserRole Add(UserRole role)
    {
        role.CreatedDate = DateTime.UtcNow;
        context.UserRoles.Add(role);
        context.SaveChanges();

        return role;
    }

    public UserRole Delete(UserRole role)
    {
        context.UserRoles.Remove(role);
        context.SaveChanges();
        return role;
    }

    public List<UserRole> GetAll()
    {
        return context.UserRoles.ToList();
    }

    public bool ExistsUserRole(Guid userId, int roleId)
    {
        return context.UserRoles.Any(ur=> ur.RoleId==roleId && ur.UserId==userId);
    }

    public List<string> GetAllRolesByUserId(Guid userId)
    {
        // Select Name from Roles where UserId = userId
        return context.UserRoles
            .Where(ur => ur.UserId == userId)
            .Include(x=>x.Role)
            .Select(x => x.Role.Name)
            .ToList();
    }

    public UserRole? GetById(long id)
    {
        return context.UserRoles.Find(id);
    }

    public UserRole Update(UserRole role)
    {
        role.UpdatedDate = DateTime.UtcNow;
        context.UserRoles.Update(role);
        context.SaveChanges();
        return role;
    }
}
