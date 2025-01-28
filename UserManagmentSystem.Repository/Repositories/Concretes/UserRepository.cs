using System.Data;
using Microsoft.EntityFrameworkCore;
using UserManagmentSystem.Models.Dtos.Users;
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

    public int CountUserByEmail(string email)
    {
        return context.Users.Count(u => u.Email == email);
    }

    public int CountUserByUsername(string username)
    {
        return context.Users.Count(u => u.Username == username);
    }

    public User? GetByUsername(string username)
    {
        return context.Users.SingleOrDefault(u=>u.Username == username);
    }

    public User? GetByEmail(string email)
    {
        return context.Users.SingleOrDefault(u=> u.Email ==email);
    }

    public List<User> GetAllDetails()
    {
        return context.Users
            .Include(ur=> ur.UserRoles)
            .ThenInclude(r=>r.Role)
            .ToList();
    }

    public List<UserDetailResponseDto> GetAllDetails1()
    {
        throw new NotImplementedException();
    }

    public List<UserDetailResponseDto> GetAllDetails2()
    {
        throw new NotImplementedException();
    }

    public User? GetDetailsById(Guid id)
    {
        return context.Users
            .Include(x=>x.UserRoles)
            .ThenInclude(r=>r.Role)
            .FirstOrDefault(x=>x.Id==id);
    }

    public UserDetailResponseDto? GetDetailsById1(Guid id)
    {
        // todo: Sonraki derste çözülecek
        
       // var detail = context.Users
       //      .Where(x => x.Id == id)
       //      .Select(user =>
       //      {
       //          new UserDetailResponseDto()
       //          {
       //              Id = user.Id,
       //              FirstName = user.FirstName,
       //              LastName = user.LastName,
       //              Username = user.Username,
       //              City = user.City,
       //              Email = user.Email,
       //              Status = user.Status,
       //              Roles = (
       //                  from userRole in context.UserRoles
       //                  join role in context.Roles on userRole.RoleId equals role.Id
       //                  where userRole.UserId == user.Id
       //                  select role.Name).ToList()
       //          };
       //      });
       
       throw new NotImplementedException();
    }

    public UserDetailResponseDto? GetDetailsById2(Guid id)
    {
        throw new NotImplementedException();
    }
}
