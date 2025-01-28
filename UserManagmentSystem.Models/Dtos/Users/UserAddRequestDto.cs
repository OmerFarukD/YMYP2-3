using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UserManagmentSystem.Models.Dtos.Users;
public sealed record UserAddRequestDto(
    string FirstName,
    string LastName,
    string Username,
    string Email,
    string Password,
    string City
    );
    
    
public  sealed record UserUpdateRequestDto(
    Guid Id,
    string FirstName,
    string LastName,
    string Username,
    string Email,
    string City
);