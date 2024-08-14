namespace CKB.Domain.Common.Models;

public abstract class AuditableEntity : Entity<Guid>
{
    public DateTime CreatedAt { get; protected set; }
    public DateTime UpdatedAt { get; protected set; }

    protected AuditableEntity(Guid id, DateTime createdAt, DateTime updatedAt)
        : base(id)
    {
        CreatedAt = createdAt;
        UpdatedAt = updatedAt;
    }

    protected AuditableEntity() { }
}
