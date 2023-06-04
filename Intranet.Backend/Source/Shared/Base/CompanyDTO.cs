namespace Shared.Base;

public abstract record CompanyDTO() : BaseModelDTO
{
    public required string Name { get; init; }

    public string? VATNumber { get; init; }
}