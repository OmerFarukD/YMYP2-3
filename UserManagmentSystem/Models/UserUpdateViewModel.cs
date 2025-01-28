using System.ComponentModel.DataAnnotations;

namespace UserManagmentSystem.Models;

public sealed record UserUpdateViewModel(
    
    Guid Id,
    
    [Required(ErrorMessage = "Zorunlu alandır.")]
    [Display(Name = "Firstname")]
    string FirstName,
    
    [Required(ErrorMessage = "Zorunlu alandır.")]
    [Display(Name = "Lastname")]
    string LastName,
    
    [Required(ErrorMessage = "Zorunlu alandır.")]
    [Display(Name = "Username")]
    string Username,
    
    [EmailAddress(ErrorMessage = "Email Formatında değil.")]
    [Required(ErrorMessage = "Zorunlu alandır.")]
    [Display(Name = "Email")]
    string Email,
    
    [Required(ErrorMessage = "Zorunlu alandır.")]
    [Display(Name = "Şehir")]
    string City
);