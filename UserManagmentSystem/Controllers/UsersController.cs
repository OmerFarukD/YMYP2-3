using Microsoft.AspNetCore.Mvc;
using UserManagmentSystem.Helpers;
using UserManagmentSystem.Models.Dtos.Users;
using UserManagmentSystem.Models.Entity;
using UserManagmentSystem.Repository.Contexts;

namespace UserManagmentSystem.Controllers;

public class UsersController : Controller
{
    private readonly BaseDbContext _context;
    public UsersController()
    {
        _context = new BaseDbContext();
    }

    [HttpGet]
    public IActionResult Index()
    {
        var users = _context.Users.ToList();
        List<UserResponseDto> responseDtos = new();

        foreach (var item in users)
        {
            UserResponseDto userResponseDto = new UserResponseDto
                (item.FirstName, item.LastName, item.Username, item.Email, item.City, item.Status);

            responseDtos.Add(userResponseDto);
        }

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
        HashingHelper.CreatePasswordHash(userAddRequestDto.Password, out byte[] passwordHash, out byte[] passwordSalt);

        User user = new User()
        {
            City = userAddRequestDto.City,
            CreatedDate = DateTime.UtcNow,
            Email = userAddRequestDto.Email,
            FirstName = userAddRequestDto.FirstName,
            LastName = userAddRequestDto.LastName,
            Username = userAddRequestDto.Username,
            PasswordHash = passwordHash,
            PasswordSalt = passwordSalt,
            Status = true
        };

        _context.Users.Add(user);
        _context.SaveChanges();

        return RedirectToAction("Index","Users");
    }

}
