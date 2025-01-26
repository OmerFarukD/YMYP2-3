namespace UserManagmentSystem.Models;

public class ExceptionViewModel
{
    public Exception Exception { get; set; }
    public string Controller { get; set; }
    public string Action { get; set; }
}