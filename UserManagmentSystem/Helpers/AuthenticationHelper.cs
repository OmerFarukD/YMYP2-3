using System.Security.Claims;

namespace UserManagmentSystem.Helpers;

public class AuthenticationHelper(IHttpContextAccessor contextAccessor)
{
    public bool IsAuthenticated()
    {
        return contextAccessor.HttpContext.User.Identity.IsAuthenticated;
    }

    public string GetUserName()
    {
        return  IsAuthenticated()
            ? contextAccessor.HttpContext.User.Identity.Name : "None";
    }


    public bool IsRoleContains(string role)
    {
         return contextAccessor.HttpContext.User.Claims
            .Where(c => c.Type == ClaimTypes.Role)
            .Select(c => c.Value)
            .ToList()
            .Contains(role);
    }
    
    public bool IsRoleNotContains(string role)
    {
        return !contextAccessor.HttpContext.User.Claims
            .Where(c => c.Type == ClaimTypes.Role)
            .Select(c => c.Value)
            .ToList()
            .Contains(role);
    }

    public List<string> GetUserRoles()
    {
        return contextAccessor.HttpContext.User.Claims
            .Where(c => c.Type == ClaimTypes.Role)
            .Select(c => c.Value)
            .ToList();
    }
}