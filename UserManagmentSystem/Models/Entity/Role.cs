namespace UserManagmentSystem.Models.Entity;

public sealed class Role : Entity<int>
{


    public Role()
    {
        Name = string.Empty;
        UserRoles = new List<UserRole>();
    }

    public string Name { get; set; }

    public List<UserRole> UserRoles { get; set; }




}




