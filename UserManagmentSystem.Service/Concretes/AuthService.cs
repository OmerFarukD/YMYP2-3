using System.Security.Claims;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Http;
using UserManagmentSystem.Models.Dtos.Users;
using UserManagmentSystem.Service.Abstracts;

namespace UserManagmentSystem.Service.Concretes;

public sealed class AuthService(IUserService userService
    ,IUserRoleService userRoleService
    ,IHttpContextAccessor contextAccessor) : IAuthService
{
    public async Task LoginAsync(LoginRequestDto loginRequestDto)
    {
        var user = userService.Login(loginRequestDto);

        List<Claim> claims = new List<Claim>()
        {
            new Claim(ClaimTypes.Name,user.Username),
            new Claim(ClaimTypes.Email,user.Email)
        };


        var roles = userRoleService.GetAllByUserId(user.Id);
        
        claims.AddRange(roles.Select(role => new Claim(ClaimTypes.Role,role)));

        ClaimsIdentity claimsIdentity = new(claims, CookieAuthenticationDefaults.AuthenticationScheme);

        ClaimsPrincipal principal = new ClaimsPrincipal(claimsIdentity);
        // Oturum aç
        await contextAccessor.HttpContext.SignInAsync(CookieAuthenticationDefaults.AuthenticationScheme,principal);

    }

    public async Task LogOutAsync()
    {
        await contextAccessor.HttpContext.SignOutAsync(CookieAuthenticationDefaults.AuthenticationScheme);
    }
}