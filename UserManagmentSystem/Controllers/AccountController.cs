using System.Security.Claims;
using Microsoft.AspNetCore.Mvc;
using UserManagmentSystem.Models;
using UserManagmentSystem.Models.Dtos.Users;
using UserManagmentSystem.Service.Abstracts;

namespace UserManagmentSystem.Controllers;

public class AccountController(IAuthService authService) : CustomBaseController
{
  
    [HttpPost]
    public async Task<IActionResult> Login(LoginViewModel viewModel)
    {

        if (!ModelState.IsValid)
        {
            return View();
        } 
        LoginRequestDto dto = new LoginRequestDto(viewModel.Username,viewModel.Password);
        await authService.LoginAsync(dto);
        return RedirectToAction("Index", "Home");
    }

    [HttpGet]
    public IActionResult Login()
    {
        return View();
    }


    [HttpGet]
    public IActionResult TestAuth()
    {
        if (HttpContext.User.Identity != null && HttpContext.User.Identity.IsAuthenticated)
        {
            var username = HttpContext.User.Identity.Name;
            var roles = HttpContext.User.Claims
                .Where(c => c.Type == ClaimTypes.Role)
                .Select(c => c.Value)
                .ToList();

            return Json(new
            {
                IsAuthenticated = true,
                Username=username,
                Roles = roles
            });
        }

        return Json(new { IsAuthenticated = false });
    }

    public async Task<IActionResult> LogOut()
    {
        await authService.LogOutAsync();
        return RedirectToAction("Login", "Account");
    }
    
}
// GET
//1-) Kullanıcı giriş yapar
// 2-) Sunucu Kimlik doğrulaması yaoar
// 3-) Tarayıcı Çerezi saklar 
// 4 -) Sunucu Çerezi Doğrular.
// 5-) Kullanıcı oturumuna devam eder.
// 6 -) Çerezin süresi dolduğunda oturum kapanır.
    
// Avantajlar : 
// Otomatik olarak tarayıcı tarafından yönetilir.
// Stateless(durumsuz) JWT yerine oturum bazlı doğrulama yapar
// Cors sorunları daha az olur
// HttpOnly flaglar ile korunabilir.

// Dezavantaj : 
// XSS, CSRF saldırılarına karşı dikkatli olunmalıdır.
