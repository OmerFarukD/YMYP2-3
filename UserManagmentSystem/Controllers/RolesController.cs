using Microsoft.AspNetCore.Mvc;
using System.Data;
using UserManagmentSystem.Models.Dtos.Roles;
using UserManagmentSystem.Models.Entity;
using UserManagmentSystem.Repository.Contexts;

namespace UserManagmentSystem.Controllers;

public class RolesController : Controller  
{

    private readonly BaseDbContext _context;
    public RolesController()
    {
        _context = new BaseDbContext();
    }

    public IActionResult Index()
    {
        // select * from Roles
        List<Role> roles = _context.Roles.ToList();

        List<RoleResponseDto> responseDtos = new();
        foreach (var item in roles)
        {
            RoleResponseDto dto = new(Name:item.Name, Id:item.Id, CreatedDate:item.CreatedDate,UpdatedDate:item.UpdatedDate);
            responseDtos.Add(dto);
        }
        return View(responseDtos);

    }


    [HttpGet]
    public IActionResult Update(int id)
    {
      

        var role = _context.Roles.Find(id);
        

        return View(role);
    }

    [HttpPost]
    public IActionResult Update(Role role)
    {
        role.UpdatedDate = DateTime.UtcNow;
        _context.Roles.Update(role);
        _context.SaveChanges();

        return RedirectToAction("Index","Roles");
    }


    [HttpPost]
    public IActionResult Add(Role role)
    {

        role.CreatedDate = DateTime.UtcNow;
        _context.Roles.Add(role);
        _context.SaveChanges();

        return RedirectToAction("Index","Roles");
    }

    [HttpGet]
    public IActionResult Add()
    {
        return View();
    }


    [HttpGet]
    public IActionResult Delete(int id)
    {
        var role = _context.Roles.Find(id);
        _context.Roles.Remove(role);
        _context.SaveChanges();

        return RedirectToAction("Index","Roles");
    }
}
