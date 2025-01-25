using UserManagmentSystem.Repository.Contexts;
using UserManagmentSystem.Repository.Repositories.Abstracts;
using UserManagmentSystem.Repository.Repositories.Concretes;
using UserManagmentSystem.Service.Abstracts;
using UserManagmentSystem.Service.Concretes;
using UserManagmentSystem.Service.Mappers.Roles;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

// AddTransient()
// Her istek için nesne oluþturur , Kýsa ömürlü nesneler için kullanýlýr.


// AddSingleton()
//Uygulama boyunca tek bir nesne oluþturur. Global davranýþ gerektiren nesneler için uygundur.

// AddScopped()
// Her istek için(HTTP isteði olabilir.) tek bir nesne oluþturur. Web uygulamalarýnda çokca kullanýlýr.

builder.Services.AddControllersWithViews();
builder.Services.AddDbContext<BaseDbContext>();
builder.Services.AddScoped<IRoleService,RoleService>();
builder.Services.AddScoped<IRoleRepository,RoleRepository>();
builder.Services.AddScoped<IRoleMapper,RoleManuelConverter>();


var app = builder.Build();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Home/Error");
    app.UseHsts();
}

app.UseHttpsRedirection();
app.UseStaticFiles();

app.UseRouting();

app.UseAuthorization();

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}");

app.Run();
