namespace Shared.Base;

public abstract record BaseModelDTO()
{
    public Guid ID { get; init; }

    public required DateTimeOffset CreatedDate { get; init; }

    public Guid? CreatedBy { get; init; }

    public DateTimeOffset? LastUpdatedDate { get; init; }

    public Guid? LastUpdatedBy { get; init; }

    public DateTimeOffset? DeletedDate { get; init; }

    public Guid? DeletedBy { get; init; }

    public required bool IsDeleted { get; init; }
    
    public required bool IsSystem { get; init; }
}