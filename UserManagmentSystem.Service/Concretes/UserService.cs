using AutoMapper;
using Microsoft.EntityFrameworkCore.ChangeTracking.Internal;
using UserManagmentSystem.Models.Dtos.Users;
using UserManagmentSystem.Models.Entities;
using UserManagmentSystem.Repository.Repositories.Abstracts;
using UserManagmentSystem.Service.Abstracts;
using UserManagmentSystem.Service.Exceptions.Types;
using UserManagmentSystem.Service.Helpers;

namespace UserManagmentSystem.Service.Concretes;

public sealed class UserService(IMapper mapper, IUserRepository userRepository) : IUserService
{
    
    // İş Kuralı , Validasyon kuralı
    
    //todo: Kullanıcı Emaili Benzersiz olmalıdır
    //todo: Kullanıcı Adı Benzersiz olmalıdır
    public void Add(UserAddRequestDto userAddRequestDto)
    {
        int countUserByEmail = userRepository.CountUserByEmail(userAddRequestDto.Email);
        int countUserByUsername = userRepository.CountUserByUsername(userAddRequestDto.Username);

        if (countUserByEmail>0)
        {
            throw new BusinessException("Girmiş olduğunuz email benzersiz olmalıdır.");
        }
        if (countUserByUsername>0)
        {
            throw new BusinessException("Girmiş olduğunuz kullanıcı adı benzersiz olmalıdır.");
        }
        HashingHelper.CreatePasswordHash(userAddRequestDto.Password, out byte[] passwordHash, out byte[] passwordSalt);

        User user = new User()
        {
            City = userAddRequestDto.City,
            Email = userAddRequestDto.Email,
            FirstName = userAddRequestDto.FirstName,
            LastName = userAddRequestDto.LastName,
            Username = userAddRequestDto.Username,
            PasswordHash = passwordHash,
            PasswordSalt = passwordSalt,
            Status = true
        };

        userRepository.Add(user);

    }

    
    // todo: İlgili kullanıcı adı var mı 
    // todo: Parola Doğru mu 
    public User Login(LoginRequestDto loginRequestDto)
    {
        User? user = userRepository.GetByUsername(loginRequestDto.Username);
        if (user is null)
        {
            throw new NotFoundException("İlgili kullanıcı Bulunamadı.");
        }

        bool passwordIsCorrect = HashingHelper.VerifyPasswordHash(
            loginRequestDto.Password, user.PasswordHash,user.PasswordSalt);

        if (passwordIsCorrect is false)
        {
            throw new BusinessException("Parola veya email hatalıdır.");
        }

        return user;
    }

    public UserDetailResponseDto? GetById(Guid id)
    {
        User? user = userRepository.GetDetailsById(id);
        if (user is null)
        {
            throw new NotFoundException("Kullanıcı bulunamadı");
        }

        UserDetailResponseDto dto = mapper.Map<UserDetailResponseDto>(user);
        return dto;

        // {1,"Admin"},{2,"User"}
        // ["Admin","User"]
    }

    public List<UserDetailResponseDto> GetAllDetails()
    {
        List<User> users = userRepository.GetAllDetails();
        List<UserDetailResponseDto> userDetailResponseDtos = mapper.Map<List<UserDetailResponseDto>>(users);
        return userDetailResponseDtos;

    }

    public User GetByIdForUpdate(Guid id)
    {
        User? user = userRepository.GetById(id);
        if (user is null)
        {
            throw new NotFoundException("Kullanıcı bulunamadı");
        }

        return user;
    }

    public List<UserResponseDto> GetAllUsers()
    {
        List<User> users = userRepository.GetAll();
        List<UserResponseDto> responseDtos = mapper.Map<List<UserResponseDto>>(users);

        return responseDtos;
    }

    public void Delete(Guid id)
    {
        User? user = userRepository.GetById(id);
        if (user is null)
        {
            throw new NotFoundException("Kullanıcı bulunamadı");
        }
        userRepository.Delete(user);
    }
}