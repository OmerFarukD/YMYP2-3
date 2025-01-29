using Microsoft.AspNetCore.Mvc;
using UserManagmentSystem.Models.Dtos.Users;

namespace UserManagmentSystem.Views.Shared.ViewComponents;

public class UsersTableViewComponent : ViewComponent
{
    public IViewComponentResult Invoke(List<UserResponseDto> users)
    {
        return View(users);
    }
}