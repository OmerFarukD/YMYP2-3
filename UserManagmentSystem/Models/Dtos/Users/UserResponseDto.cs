namespace UserManagmentSystem.Models.Dtos.Users;

public sealed record UserResponseDto(
    string FirstName,
    string LastName,
    string Username,
    string Email,
    string City,
    bool Status
    );
