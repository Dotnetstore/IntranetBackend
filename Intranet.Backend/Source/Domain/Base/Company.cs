namespace Domain.Base;

public abstract class Company : BaseModel
{
    public required string Name { get; set; }

    public string? VATNumber { get; set; }
}