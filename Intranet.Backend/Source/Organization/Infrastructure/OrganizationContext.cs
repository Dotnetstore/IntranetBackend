using Core.Infrastructure;
using Domain.Organization;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Options;
using Settings.Domain;

namespace Organization.Infrastructure;

internal class OrganizationContext : BaseContext
{
    public OrganizationContext() : base(
        new DbContextOptionsBuilder<OrganizationContext>().Options, 
        Options.Create(new DatabaseOptions
        {
            SQLConnectionstring = "", 
            InMemoryConnectionstring = "", 
            SQLiteConnectionstring = "", 
            UseSQL = true,
            UseInMemory = false,
            UseSQLite = false
        }))
    {
    }
    
    public OrganizationContext(
        DbContextOptions options,
        IOptions<DatabaseOptions> databaseOptions) : base(options, databaseOptions)
    {
    }

    public virtual DbSet<OwnCompany> OwnCompanies => Set<OwnCompany>();
    
    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.ApplyConfigurationsFromAssembly(typeof(AssemblyReference).Assembly);
    }
}