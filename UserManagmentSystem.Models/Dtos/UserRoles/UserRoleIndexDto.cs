namespace UserManagmentSystem.Models.Dtos.UserRoles;

public class UserRoleIndexDto
{
    public Guid Id { get; set; }
    public string Username { get; set; }
    public string Email { get; set; }
    public List<string> Role { get; set; }
}