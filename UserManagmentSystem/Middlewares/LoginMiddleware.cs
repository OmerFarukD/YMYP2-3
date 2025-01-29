namespace UserManagmentSystem.Middlewares;

public class LoginMiddleware
{
    private readonly RequestDelegate _next;

    public LoginMiddleware(RequestDelegate next)
    {
        _next = next;
    }

    public async Task InvokeAsync(HttpContext context)
    {
        if (!context.User.Identity.IsAuthenticated && !context.Request.Path.StartsWithSegments("/Account"))
        {
            context.Response.Redirect("/Account/Login");
            return;
        }

        await _next(context);
    }
    
}