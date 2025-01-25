using UserManagmentSystem.Models.Dtos.Roles;
using UserManagmentSystem.Repository.Repositories.Abstracts;
using UserManagmentSystem.Repository.Repositories.Concretes;
using UserManagmentSystem.Repository.Contexts;
using UserManagmentSystem.Service.Abstracts;
using UserManagmentSystem.Models.Entities;
using UserManagmentSystem.Service.Mappers.Roles;

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

        Role role = _roleMapper.CovertToEntity(dto);

        _roleRepository.Add(role);
    }

    public void Delete(int id)
    {
        Role? role = _roleRepository.GetById(id);
        //todo: Eğer ilgili rol bulunamazsa Exception Handling mekanizması
        _roleRepository.Delete(role!);

    }

    public List<RoleResponseDto> GetAll()
    {
        List<Role> roles = _roleRepository.GetAll();

        List<RoleResponseDto> responses = _roleMapper.ConvertToResponseList(roles);
        return responses;


    }

    public RoleResponseDto? GetById(int id)
    {
        Role? role = _roleRepository.GetById(id);
        //todo: Eğer ilgili rol bulunamazsa Exception Handling mekanizması
        RoleResponseDto dto = _roleMapper.ConvertToResponse(role!);

        return dto;

    }

    public void Update(RoleUpdateRequestDto dto)
    {
        Role role = _roleMapper.CovertToEntity(dto);

        _roleRepository.Update(role);
    }
}
