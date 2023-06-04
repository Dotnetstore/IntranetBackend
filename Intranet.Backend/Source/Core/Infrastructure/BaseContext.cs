using Core.Abstractions;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Options;
using Settings.Domain;

namespace Core.Infrastructure;

public abstract class BaseContext : DbContext, IUnitOfWork
{
    private readonly IOptions<DatabaseOptions> _databaseOptions;

    protected BaseContext(
        DbContextOptions options,
        IOptions<DatabaseOptions> databaseOptions) : base(options)
    {
        _databaseOptions = databaseOptions;
    }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
        if (_databaseOptions.Value.UseSQL)
        {
            optionsBuilder.UseSqlServer(_databaseOptions.Value.SQLConnectionstring);
            return;
        }

        if (_databaseOptions.Value.UseSQLite)
        {
            optionsBuilder.UseSqlite(_databaseOptions.Value.SQLiteConnectionstring);
            return;
        }

        if (_databaseOptions.Value.UseInMemory)
        {
            optionsBuilder.UseInMemoryDatabase(_databaseOptions.Value.InMemoryConnectionstring);
        }
    }
    
    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.ApplyConfigurationsFromAssembly(typeof(AssemblyReference).Assembly);
    }
}