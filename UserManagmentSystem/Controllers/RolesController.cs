using Microsoft.AspNetCore.Mvc;
using System.Data;
using UserManagmentSystem.Models;
using UserManagmentSystem.Models.Dtos.Roles;
using UserManagmentSystem.Repository.Contexts;
using UserManagmentSystem.Repository.Repositories.Concretes;
using UserManagmentSystem.Service.Abstracts;
using UserManagmentSystem.Service.Concretes;
using UserManagmentSystem.Service.Exceptions.Types;

namespace UserManagmentSystem.Controllers;


// Dependency Injection Yöntemleri : 
// Constructor Injection
// Property Injection
// Method Injection
public class RolesController : CustomBaseController  
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


    [HttpGet]
    public IActionResult Update(int id)
    {
        var role = _roleService.GetByIdForUpdate(id);

        RoleUpdateViewModel viewModel = new()
        {
            Id = role.Id,
            Name = role.Name
        };

        return View(viewModel);
    }

    [HttpPost]
    public IActionResult Update(RoleUpdateViewModel viewModel)
    {
        RoleUpdateRequestDto roleUpdateRequestDto = new RoleUpdateRequestDto(viewModel.Id, viewModel.Name);

        _roleService.Update(roleUpdateRequestDto);
        return RedirectToAction("Index", "Roles");
    }


    [HttpPost]
    public IActionResult Add(RoleAddRequestDto role)
    {

        try
        {
            _roleService.Add(role);
            return RedirectToAction("Index", "Roles");
        }
        catch (BusinessException e)
        {
            ExceptionViewModel viewModel = new()
            {
                Exception = e,
                Controller = "Roles",
                Action = "Index"
            };
            
            return BusinessError(viewModel);
        }
        
   
    }

    
   

    [HttpGet]
    public IActionResult Add()
    {
        return View();
    }


    [HttpGet]
    public IActionResult Delete(int id)
    {
        try
        {
            _roleService.Delete(id);
            return RedirectToAction("Index", "Roles");
        }
        catch (NotFoundException e)
        {
            ExceptionViewModel vm = new()
            {
                Exception = e, Controller = "Roles", Action = "Index"
            };
            
            return NotFoundError(vm);
        }

    }
}
