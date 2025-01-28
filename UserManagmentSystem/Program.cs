using System.Reflection;
using UserManagmentSystem.Repository.Contexts;
using UserManagmentSystem.Repository.Repositories.Abstracts;
using UserManagmentSystem.Repository.Repositories.Concretes;
using UserManagmentSystem.Service.Abstracts;
using UserManagmentSystem.Service.Concretes;
using UserManagmentSystem.Service.Mappers.Profiles;
using UserManagmentSystem.Service.Mappers.Roles;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

// AddTransient()
// Her istek i�in nesne olu�turur , K�sa �m�rl� nesneler i�in kullan�l�r.


// AddSingleton()
//Uygulama boyunca tek bir nesne olu�turur. Global davran�� gerektiren nesneler i�in uygundur.

// AddScopped()
// Her istek i�in(HTTP iste�i olabilir.) tek bir nesne olu�turur. Web uygulamalar�nda �okca kullan�l�r.

builder.Services.AddControllersWithViews();
builder.Services.AddDbContext<BaseDbContext>();
builder.Services.AddScoped<IRoleService,RoleService>();
builder.Services.AddScoped<IRoleRepository,RoleRepository>();
builder.Services.AddScoped<IUserService, UserService>();
builder.Services.AddScoped<IUserRepository, UserRepository>();
builder.Services.AddScoped<IUserRoleService,UserRoleService>();
builder.Services.AddScoped<IUserRoleRepository, UserRoleRepository>();
builder.Services.AddScoped<IRoleMapper,RoleAutoMapperConverter>();
builder.Services.AddAutoMapper(typeof(MappingProfiles));


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
