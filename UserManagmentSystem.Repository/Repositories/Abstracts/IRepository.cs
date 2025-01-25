using UserManagmentSystem.Models.Entities;

namespace UserManagmentSystem.Repository.Repositories.Abstracts;

public interface IRepository<TEntity,TId>
    
    // Generic Constrains - > Jenerik kısıtlama
    where TEntity: Entity<TId>
{
    TEntity Add(TEntity role);

    TEntity Update(TEntity role);

    TEntity? GetById(TId id);

    TEntity Delete(TEntity role);

    List<TEntity> GetAll();

}
