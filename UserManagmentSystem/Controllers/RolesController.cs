using Microsoft.AspNetCore.Mvc;
using System.Data;
using UserManagmentSystem.Models.Dtos.Roles;
using UserManagmentSystem.Repository.Contexts;
using UserManagmentSystem.Repository.Repositories.Concretes;
using UserManagmentSystem.Service.Abstracts;
using UserManagmentSystem.Service.Concretes;

namespace UserManagmentSystem.Controllers;


// Dependency Injection Yöntemleri : 
// Constructor Injection
// Property Injection
// Method Injection
public class RolesController : Controller  
{

    // Constructor Arg Injection 
    private readonly IRoleService _roleService;

    public RolesController(IRoleService roleService)
    {
        _roleService = roleService;
    }

    // Property Injection
    //public IRoleService RoleService { get; set; }


    // Method Injection
    //public IActionResult Index(IRoleService roleService)
    //{

    //    var responseDtos = roleService.GetAll();
    //    return View(responseDtos);

    //}


    public IActionResult Index()
    {

        var responseDtos = _roleService.GetAll();
        return View(responseDtos);

    }


    //[HttpGet]
    //public IActionResult Update(int id)
    //{


    //    var role = _context.Roles.Find(id);


    //    return View(role);
    //}

    //[HttpPost]
    //public IActionResult Update(Role role)
    //{
    //    role.UpdatedDate = DateTime.UtcNow;
    //    _context.Roles.Update(role);
    //    _context.SaveChanges();

    //    return RedirectToAction("Index","Roles");
    //}


    //[HttpPost]
    //public IActionResult Add(Role role)
    //{

    //    role.CreatedDate = DateTime.UtcNow;
    //    _context.Roles.Add(role);
    //    _context.SaveChanges();

    //    return RedirectToAction("Index","Roles");
    //}

    //[HttpGet]
    //public IActionResult Add()
    //{
    //    return View();
    //}


    //[HttpGet]
    //public IActionResult Delete(int id)
    //{
    //    var role = _context.Roles.Find(id);
    //    _context.Roles.Remove(role);
    //    _context.SaveChanges();

    //    return RedirectToAction("Index","Roles");
    //}
}
