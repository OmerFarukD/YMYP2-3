namespace UserManagmentSystem.Models.Dtos.Users;

public sealed record UserAddRequestDto(
    string FirstName, 
    string LastName,
    string Username,
    string Email,
    string Password,
    string City
    );
