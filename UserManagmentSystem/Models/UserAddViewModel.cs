

using System.ComponentModel.DataAnnotations;
using UserManagmentSystem.Attributes.Validations;

namespace UserManagmentSystem.Models;

public sealed record UserAddViewModel(
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
    
    // [RegularExpression(pattern:"(?=.*[a-z])(?=.*[A-Z])(?=.*[!@#$%^&*(),.?\":{}|<>])[A-Za-z!@#$%^&*(),.?\":{}|<>]{6,}",
    //     ErrorMessage = "1 Büyük harf, 1 küçük harf, 6 haneli , 1 noktalama işareti olmak zorundadır."
    //     )]
    
    
    [PasswordRule(Min = 15)]
    string Password,
    
    [Required(ErrorMessage = "Zorunlu alandır.")]
    [Display(Name = "Şehir")]
    string City
);