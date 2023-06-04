using System.ComponentModel.DataAnnotations;

namespace Settings.Domain;

public sealed class DatabaseOptions
{
    public const string SectionName = "Database";

    [Required]
    [MinLength(10)]
    [MaxLength(255)]
    [DataType(DataType.Text)]
    public required string SQLConnectionstring { get; init; }

    [Required]
    [MinLength(5)]
    [MaxLength(255)]
    [DataType(DataType.Text)]
    public required string SQLiteConnectionstring { get; init; }

    [Required]
    [MinLength(5)]
    [MaxLength(50)]
    [DataType(DataType.Text)]
    public required string InMemoryConnectionstring { get; init; }

    [Required]
    public required bool UseSQL { get; init; }

    [Required]
    public required bool UseSQLite { get; init; }

    [Required]
    public required bool UseInMemory { get; init; }
}