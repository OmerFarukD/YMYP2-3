using System.Data;
using UserManagmentSystem.Models.Entities;
using UserManagmentSystem.Repository.Contexts;
using UserManagmentSystem.Repository.Repositories.Abstracts;

namespace UserManagmentSystem.Repository.Repositories.Concretes;

public sealed class UserRepository(BaseDbContext context) : IUserRepository
{
    public User Add(User user)
    {
        user.CreatedDate = DateTime.UtcNow;
        context.Users.Add(user);
        context.SaveChanges();

        return user;
    }

    public User Delete(User user)
    {
   
        context.Users.Remove(user);
        context.SaveChanges();

        return user;
    }

    public List<User> GetAll()
    {
        return context.Users.ToList();
    }

    public User? GetById(Guid id)
    {
        return context.Users.Find(id);
    }

    public User Update(User user)
    {
        user.UpdatedDate = DateTime.UtcNow;
        context.Users.Update(user);
        context.SaveChanges();

        return user;
    }
}
