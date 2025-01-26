using Microsoft.AspNetCore.Mvc;
using UserManagmentSystem.Models;
using UserManagmentSystem.Models.Dtos.Users;
using UserManagmentSystem.Repository.Contexts;
using UserManagmentSystem.Service.Abstracts;
using UserManagmentSystem.Service.Exceptions.Types;

namespace UserManagmentSystem.Controllers;

public class UsersController(IUserService userService) : CustomBaseController
{
    [HttpGet]
    public IActionResult Index()
    {
        List<UserResponseDto> responseDtos = userService.GetAllUsers();
        return View(responseDtos);
    }


    [HttpGet]
    public IActionResult Add()
    {
        return View();
    }

    [HttpPost]
    public IActionResult Add(UserAddRequestDto userAddRequestDto)
    {
        try
        {
            userService.Add(userAddRequestDto);
        }
        catch (BusinessException e)
        {
            ExceptionViewModel viewModel = new ExceptionViewModel()
            {
                Controller = "Users",
                Action = "Add",
                Exception = e
            };
            
            return BusinessError(viewModel);
        }

        return RedirectToAction("Index","Users");
    }


    //[HttpGet]
    //public IActionResult Detail(Guid id)
    //{
    //    var user = _context.Users.Find(id);
    //    UserResponseDto userResponseDto = new(user.Id,user.FirstName, user.LastName, user.Username, user.Email, user.City, user.Status);
    //    return View(userResponseDto);
    //}


    //[HttpGet]
    //public IActionResult Update(Guid id)
    //{
    //    var user = _context.Users.Find(id);
    //    return View(user);
    //}


    //[HttpPost]
    //public IActionResult Update(User user)
    //{
    //    _context.Users.Update(user);
    //    _context.SaveChanges();
    //    return RedirectToAction("Index","Users");
    //}

    //[HttpGet]
    //public IActionResult Delete(Guid id)
    //{
    //    var user = _context.Users.Find(id);
    //    _context.Users.Remove(user);
    //    _context.SaveChanges();
    //    return RedirectToAction("Index", "Users");
    //}
}
