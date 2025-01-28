namespace UserManagmentSystem.Models.Dtos.Users;

public sealed record UserDetailResponseDto
{
    public Guid Id { get; init; }
    public string FirstName { get; init; }
    public string LastName { get; init; }
    public string Username { get; init; }
    public string Email { get; init; }
    public string City { get; init; }
    public bool Status { get; init; }
    public List<string> Roles { get; init; }

    public UserDetailResponseDto()
    {
        
    }
    
    public UserDetailResponseDto(Guid ıd, string firstName, string lastName, string username, string email, string city, bool status, List<string> roles)
    {
        Id = ıd;
        FirstName = firstName;
        LastName = lastName;
        Username = username;
        Email = email;
        City = city;
        Status = status;
        Roles = roles;
    }
}


