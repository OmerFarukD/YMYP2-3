using Microsoft.EntityFrameworkCore;
using UserManagmentSystem.Models.Entity;

namespace UserManagmentSystem.Repository.Contexts;

public class BaseDbContext : DbContext
{



    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
        optionsBuilder.UseSqlServer(@"server=(localdb)\MSSQLLocalDB; Database=İstanbul_egitim_academy_db; Trusted_Connection=true");
    }

    public DbSet<User> Users { get; set; }
    public DbSet<UserRole> UserRoles { get; set; }
    public DbSet<Role> Roles { get; set; }

}
