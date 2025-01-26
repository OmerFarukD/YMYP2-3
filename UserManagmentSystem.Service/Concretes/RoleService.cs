using UserManagmentSystem.Models.Dtos.Roles;
using UserManagmentSystem.Repository.Repositories.Abstracts;
using UserManagmentSystem.Repository.Repositories.Concretes;
using UserManagmentSystem.Repository.Contexts;
using UserManagmentSystem.Service.Abstracts;
using UserManagmentSystem.Models.Entities;
using UserManagmentSystem.Service.Mappers.Roles;
using UserManagmentSystem.Service.Exceptions.Types;

namespace UserManagmentSystem.Service.Concretes;

public sealed class RoleService : IRoleService
{

    private readonly IRoleRepository _roleRepository;
    private readonly IRoleMapper _roleMapper;

    public RoleService(IRoleRepository roleRepository, IRoleMapper roleMapper)
    {
        _roleRepository = roleRepository;
        _roleMapper = roleMapper;
    }

    public void Add(RoleAddRequestDto dto)
    {

        //1.Yöntem
        bool isPresent = _roleRepository.ExistsByRoleName(dto.Name);
        if (isPresent)
        {
            throw new BusinessException("Rol adı benzersiz olmalıdır.");
        }


        //2. Yöntem
        //int count = _roleRepository.CountByRoleName(dto.Name);
        //if (count > 0)
        //{
        //    throw new BusinessException("Rol adı benzersiz olmalıdır.");
        //}

        // İş kuralı Rol adı benzersiz olmalıdır.


        Role role = _roleMapper.CovertToEntity(dto);

        _roleRepository.Add(role);
    }

    public void Delete(int id)
    {
        Role? role = _roleRepository.GetById(id);
        if (role is null)
        {
            throw new NotFoundException("İlgili Rol bulunamadı.");
        }
        //todo: Eğer ilgili rol bulunamazsa Exception Handling mekanizması

        _roleRepository.Delete(role!);

    }

    public List<RoleResponseDto> GetAll()
    {
        List<Role> roles = _roleRepository.GetAll();

        List<RoleResponseDto> responses = _roleMapper.ConvertToResponseList(roles);
        return responses;


    }

    public Role GetByIdForUpdate(int id)
    {
        Role? role = _roleRepository.GetById(id);
        if (role is null)
        {
            throw new NotFoundException("İlgili Rol bulunamadı.");
        }

        return role;
    }

    public RoleResponseDto? GetById(int id)
    {
        Role? role = _roleRepository.GetById(id);

        if(role is null)
        {
            throw new NotFoundException("İlgili Rol bulunamadı.");
        }
        RoleResponseDto dto = _roleMapper.ConvertToResponse(role!);

        return dto;

    }

    public void Update(RoleUpdateRequestDto dto)
    {
        Role role = _roleMapper.CovertToEntity(dto);

        _roleRepository.Update(role);
    }
}
