namespace Domain.Base;

public abstract class BaseModel
{
    public Guid ID { get; set; }

    public required DateTimeOffset CreatedDate { get; set; }

    public Guid? CreatedBy { get; set; }

    public DateTimeOffset? LastUpdatedDate { get; set; }

    public Guid? LastUpdatedBy { get; set; }

    public DateTimeOffset? DeletedDate { get; set; }

    public Guid? DeletedBy { get; set; }

    public required bool IsDeleted { get; set; }
    
    public required bool IsSystem { get; set; }
}