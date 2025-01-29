using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using UserManagmentSystem.Models;
using UserManagmentSystem.Service.Abstracts;

namespace UserManagmentSystem.Views.Shared.ViewComponents;

public class AssignRoleToUserViewComponent(IUserService userService, IRoleService roleService) : ViewComponent
{
    public IViewComponentResult Invoke()
    {
        var usersData = userService.GetAllUsers();
        var rolesData = roleService.GetAll();

        AssignRoleViewModel viewModel = new()
        {
            Users = usersData.Select(u=> new SelectListItem()
            {
                Value = u.Id.ToString(),
                Text = u.Email
            }).ToList(),
            Roles = rolesData.Select(r=>new SelectListItem()
            {
                Value = r.Id.ToString(),
                Text = r.Name
            }).ToList()
        };

        return View(viewModel);
    }
}