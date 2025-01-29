using Microsoft.AspNetCore.Mvc;
using UserManagmentSystem.Service.Abstracts;

namespace UserManagmentSystem.Views.Shared.ViewComponents;

public class RoleTableViewComponent(IRoleService roleService) : ViewComponent
{
    public IViewComponentResult Invoke()
    {
        var response = roleService.GetAll();

        return View(response);

    }
}