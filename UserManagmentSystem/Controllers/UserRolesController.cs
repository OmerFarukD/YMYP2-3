using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using UserManagmentSystem.Models;
using UserManagmentSystem.Models.Dtos.UserRoles;
using UserManagmentSystem.Service.Abstracts;
using UserManagmentSystem.Service.Exceptions.Types;

namespace UserManagmentSystem.Controllers;

public class UserRolesController(
    IUserRoleService service
    ) : CustomBaseController
{
    // GET
    public IActionResult Index()
    {
        var response = service.GetRolesAndUsers();
        return View(response);
    }

    [HttpGet]
    public IActionResult Delete(long id)
    {
        try
        {
            service.Delete(id);
            return RedirectToAction("Index","UserRoles");
        }
        catch (NotFoundException e)
        {
            return NotFoundError(new ExceptionViewModel{Controller = "UserRoles",Action = "Index",Exception = e});
        }
        
    }


    [HttpGet]
    public IActionResult Update(long id)
    {
        try
        {
            var result = service.GetByIdForUpdate(id);
            return View(new UserRoleUpdateViewModel(result.Id,result.UserId,result.RoleId));
        }
        catch (NotFoundException e)
        {
            return NotFoundError(new ExceptionViewModel(){Controller = "UserRoles",Action = "Index",Exception = e});
        }
    }

    [HttpPost]
    public IActionResult Update(UserRoleUpdateViewModel viewModel)
    {
        UserRoleUpdateRequestDto dto = new(viewModel.Id,viewModel.UserId,viewModel.RoleId);
        service.Update(dto);
        return RedirectToAction("Index", "UserRoles");
    }

    [HttpPost]
    public IActionResult Add(AssignRoleViewModel  viewModel)
    {
        try
        {
            UserRoleAddRequestDto dto = new UserRoleAddRequestDto(
                viewModel.UserId,
                viewModel.RoleId
                );
            service.Add(dto);
            return RedirectToAction("Index", "UserRoles");
        }
        catch (BusinessException e)
        {
            return BusinessError(new ExceptionViewModel()
                { Controller = "UserRoles", Action = "Index", Exception = e });
        }
    }

    [HttpGet]
    public IActionResult Add()
    {
       
        return View();
    }
}