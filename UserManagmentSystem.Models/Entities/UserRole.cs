namespace UserManagmentSystem.Models.Entities;

public sealed class UserRole : Entity<long>
{
    public UserRole()
    {
        Role = new Role();
        User = new User();
        UserId = new Guid();
    }

    public Guid UserId { get; set; }

    public int RoleId { get; set; }




    public Role Role { get; set; }
    public User User { get; set; }
}