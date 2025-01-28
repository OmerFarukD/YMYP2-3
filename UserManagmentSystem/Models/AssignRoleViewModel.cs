using Microsoft.AspNetCore.Mvc.Rendering;

namespace UserManagmentSystem.Models;

public class AssignRoleViewModel
{
    public Guid UserId { get; set; }
    public string Email { get; set; }

    public int RoleId { get; set; }
    public string RoleName { get; set; }

    public List<SelectListItem> Users { get; set; }
    public List<SelectListItem> Roles { get; set; }
}