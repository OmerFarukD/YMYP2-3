using Microsoft.AspNetCore.Mvc;
using UserManagmentSystem.Helpers;
using UserManagmentSystem.Models.Dtos.Users;
using UserManagmentSystem.Repository.Contexts;

namespace UserManagmentSystem.Controllers;

public class UsersController : Controller
{
    //private readonly BaseDbContext _context;
    //public UsersController()
    //{
    //    _context = new BaseDbContext();
    //}

    //[HttpGet]
    //public IActionResult Index()
    //{
    //    var users = _context.Users.ToList();
    //    List<UserResponseDto> responseDtos = new();

    //    foreach (var item in users)
    //    {
    //        UserResponseDto userResponseDto = new UserResponseDto
    //            (item.Id,item.FirstName, item.LastName, item.Username, item.Email, item.City, item.Status);

    //        responseDtos.Add(userResponseDto);
    //    }

    //    return View(responseDtos);
    //}


    //[HttpGet]
    //public IActionResult Add()
    //{
    //    return View();
    //}

    //[HttpPost]
    //public IActionResult Add(UserAddRequestDto userAddRequestDto)
    //{
    //    HashingHelper.CreatePasswordHash(userAddRequestDto.Password, out byte[] passwordHash, out byte[] passwordSalt);

    //    User user = new User()
    //    {
    //        City = userAddRequestDto.City,
    //        CreatedDate = DateTime.UtcNow,
    //        Email = userAddRequestDto.Email,
    //        FirstName = userAddRequestDto.FirstName,
    //        LastName = userAddRequestDto.LastName,
    //        Username = userAddRequestDto.Username,
    //        PasswordHash = passwordHash,
    //        PasswordSalt = passwordSalt,
    //        Status = true
    //    };

    //    _context.Users.Add(user);
    //    _context.SaveChanges();

    //    return RedirectToAction("Index","Users");
    //}


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
