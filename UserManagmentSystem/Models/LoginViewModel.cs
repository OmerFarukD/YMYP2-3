
using System.ComponentModel.DataAnnotations;
using UserManagmentSystem.Attributes.Validations;

namespace UserManagmentSystem.Models;

public sealed record LoginViewModel(
    
    [Required]
    [MinLength(4)]
    [Display(Name = "Kullanıcı Adı")]
    string Username,
    
    [PasswordRule(Min = 6)]
    string Password
    );
