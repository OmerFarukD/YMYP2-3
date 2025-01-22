namespace UserManagmentSystem.Models.Entity;

public abstract class Entity<TId>
{
    protected Entity()
    {
        
    }

    protected Entity(TId id)
    {
        Id = id;
    }

    public TId Id { get; set; }

    public DateTime CreatedDate { get; set; }

    public DateTime UpdatedDate { get; set; }
}
