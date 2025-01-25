namespace UserManagmentSystem.Models.Entities;

public sealed class User : Entity<Guid>
{

    public User()
    {
        FirstName = string.Empty;
        LastName = string.Empty;
        Email = string.Empty;
        City = string.Empty;
        PasswordHash = Array.Empty<byte>();
        PasswordSalt = Array.Empty<byte>();
        UserRoles = new List<UserRole>();
    }

    public string FirstName { get; set; }

    public string LastName { get; set; }

    public string Username { get; set; }

    public string Email { get; set; }

    public byte[] PasswordHash { get; set; }

    public byte[] PasswordSalt { get; set; }

    public bool Status { get; set; }

    public string City { get; set; }

    public List<UserRole> UserRoles { get; set; }
}
