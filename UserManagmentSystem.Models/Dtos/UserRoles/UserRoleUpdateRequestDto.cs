namespace UserManagmentSystem.Models.Dtos.UserRoles;

public sealed record UserRoleUpdateRequestDto(long Id,Guid UserId,int RoleId);