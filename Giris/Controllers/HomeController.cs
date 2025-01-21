using Giris.Models;
using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;

namespace Giris.Controllers;

public class HomeController : Controller
{
    private readonly ILogger<HomeController> _logger;

    public HomeController(ILogger<HomeController> logger)
    {
        _logger = logger;
    }


    //http://localhost:5045/Home/Index
    public IActionResult Index()
    {
        return View();
    }

    //http://localhost:5045/Home/Privacy
    public IActionResult Privacy()
    {
        return View();
    }

    [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
    public IActionResult Error()
    {
        return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
    }

    //http://localhost:5045/Home/Deneme
    public IActionResult Deneme()
    {

        User user = new()
        {
            Name = "John",
            Surname = "Doe",
            Age = 29,
            Email ="johndoe@gmail.com"
        };

        return View(user);
    }


    public IActionResult Users()
    {
        var users = new List<User>()
        {
            new User(){Name="Deneme1",Surname="Deneme_Soyad1",Age=18,Email="deneme@gmail.com"},
            new User(){Name="Deneme2",Surname="Deneme_Soyad2",Age=35,Email="deneme@gmail.com"},
            new User(){Name="Deneme3",Surname="Deneme_Soyad3",Age=45,Email="deneme@gmail.com"},
            new User(){Name="Deneme4",Surname="Deneme_Soyad4",Age=29,Email="deneme@gmail.com"},
            new User(){Name="Deneme5",Surname="Deneme_Soyad5",Age=17,Email="deneme@gmail.com"},
            new User(){Name="Mauro Emanuel",Surname="Icardi",Age=30,Email="mauro@gmail.com"}
        };


        return View(users);
    }
}
