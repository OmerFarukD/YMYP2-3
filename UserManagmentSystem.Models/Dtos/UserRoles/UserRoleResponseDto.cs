namespace UserManagmentSystem.Models.Dtos.UserRoles;

public sealed record UserRoleResponseDto
{
    public long Id { get; init; }
    public Guid UserId { get; init; }
    public int RoleId { get; init; }
}