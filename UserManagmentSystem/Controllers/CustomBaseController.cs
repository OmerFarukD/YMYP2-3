using Microsoft.AspNetCore.Mvc;
using UserManagmentSystem.Models;
using UserManagmentSystem.Service.Exceptions.Types;

namespace UserManagmentSystem.Controllers;

public class CustomBaseController : Controller
{
    public IActionResult BusinessError(ExceptionViewModel viewModel)
    {
        return PartialView("Partials/Errors/_BusinesErrorPartial",viewModel);
    }

    public IActionResult NotFoundError(ExceptionViewModel viewModel)
    {
        return PartialView("Partials/Errors/_NotFoundErrorPartial",viewModel);
    }


    public IActionResult GlobalError(ExceptionViewModel viewModel)
    {
        return PartialView("Partials/Errors/_GlobalErrorPartial",viewModel);
    }
    
}