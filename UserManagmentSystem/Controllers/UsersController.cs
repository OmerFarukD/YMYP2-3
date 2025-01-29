using Microsoft.AspNetCore.Mvc;
using UserManagmentSystem.Models;
using UserManagmentSystem.Models.Dtos.Users;
using UserManagmentSystem.Models.Entities;
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



    // Parola minimum 6 haneli olacak 
    // Parola içerisinde minimum 1 tane noktalama işareti olacak (.,!?)
    // Parola içerisinde minimum 1 tane küçük harf olacak
    // Parola içinde minimum 1 tane büyük harf olacak 
    // Herhangi birine uymazsa false cevabı gelecek
    // Hepsi uyarsa true dönecek.
    // 1 tane rakam olmak zorunda
  
    
    [HttpGet]
    public IActionResult Add()
    {
        return View();
    }

    [HttpPost]
    public IActionResult Add(UserAddViewModel addViewModel)
    {
        try
        {
            if (!ModelState.IsValid)
            {
                return View();
            }
            
            
            UserAddRequestDto userAddRequestDto = new(addViewModel.FirstName,
                addViewModel.LastName,
                addViewModel.Username,
                addViewModel.Email,
                addViewModel.Password,
                addViewModel.City
                ); 
            
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


    [HttpGet]
    public IActionResult Detail(Guid id)
    {
        try
        {
            UserDetailResponseDto? userResponseDto = userService.GetById(id);
            return View(userResponseDto);
        }
        catch (NotFoundException e)
        {
            ExceptionViewModel viewModel = new()
            {
                Controller = "Users",
                Action = "Index",
                Exception = e
            };
            return NotFoundError(viewModel);
        }

    }


    [HttpGet]
    public IActionResult Update(Guid id)
    {
        var user = userService.GetByIdForUpdate(id);
        UserUpdateViewModel vm = new(user.Id,user.FirstName,user.LastName,user.Username,user.Email
        ,user.City);
        return View(vm);
    }


    [HttpPost]
    public IActionResult Update(UserUpdateViewModel vm)
    {
        
        // user service içerisinde update fonksiyonu yaz.
        return RedirectToAction("Index","Users");
    }
    
    
    [HttpGet]
    public IActionResult Delete(Guid id)
    {
        try
        {
            userService.Delete(id);
            return RedirectToAction("Index", "Users");
        }
        catch (NotFoundException e)
        {
            return NotFoundError(new ExceptionViewModel(){Action = "Users",Controller="Index",Exception =e});
        }
    }

    [HttpPost]
    public IActionResult Login(LoginViewModel viewModel)
    {
        try
        {
            LoginRequestDto dto = new LoginRequestDto(viewModel.Username, viewModel.Password);
            userService.Login(dto);
            return RedirectToAction("Index", "Users");
        }
        catch (Exception exception) {

            if (exception is NotFoundException notFoundException)
            {
                return NotFoundError(new ExceptionViewModel()
                    { Action = "Login", Controller = "Users", Exception = notFoundException });
            }

            if (exception is BusinessException businessException)
            {
                return BusinessError(new ExceptionViewModel()
                    { Action = "Login", Controller = "Users", Exception = businessException });
            }
            
            return GlobalError(new ExceptionViewModel()
                { Action = "Login", Controller = "Users", Exception = exception });
        }
        
    }
}
