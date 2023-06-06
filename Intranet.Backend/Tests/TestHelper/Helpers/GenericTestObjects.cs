using MediatR;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore.Metadata.Conventions;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Options;
using Moq;
using Settings.Domain;

namespace TestHelper.Helpers;

public static class GenericTestObjects
{
    private const string SQLConnectionString = "Server=localhost;Database=DotnetstoreIntranet;Trusted_Connection=True;MultipleActiveResultSets=true;TrustServerCertificate=True;";
    private const string InMemoryConnectionString = "DotnetstoreIntranetInMemory";
    private const string SQLiteConnectionString = "Data Source=c:\\Dotnetstore\\DotnetstoreIntranet.db";
    
    public static IOptions<DatabaseOptions> GetDatabaseOptionsSQL()
    {
        var options = Options.Create(new DatabaseOptions
        {
            InMemoryConnectionstring = InMemoryConnectionString,
            SQLConnectionstring = SQLConnectionString,
            SQLiteConnectionstring = SQLiteConnectionString,
            UseSQL = true,
            UseInMemory = false,
            UseSQLite = false
        });

        return options;
    }
    
    public static IOptions<DatabaseOptions> GetDatabaseOptionsInMemory()
    {
        var options = Options.Create(new DatabaseOptions
        {
            InMemoryConnectionstring = InMemoryConnectionString,
            SQLConnectionstring = SQLConnectionString,
            SQLiteConnectionstring = SQLiteConnectionString,
            UseSQL = false,
            UseInMemory = true,
            UseSQLite = false
        });

        return options;
    }
    
    public static IOptions<DatabaseOptions> GetDatabaseOptionsSqLite()
    {
        var options = Options.Create(new DatabaseOptions
        {
            InMemoryConnectionstring = InMemoryConnectionString,
            SQLConnectionstring = SQLConnectionString,
            SQLiteConnectionstring = SQLiteConnectionString,
            UseSQL = false,
            UseInMemory = false,
            UseSQLite = true
        });

        return options;
    }
    
    public static DbContextOptions<T> GetDbContextOptions<T>() where T : DbContext
    {
        var options = GetDatabaseOptionsSQL();
        if (options.Value.UseSQL)
        {
            return new DbContextOptionsBuilder<T>()
                .UseSqlServer(options.Value.SQLConnectionstring)
                .Options;
        }
        
        if (options.Value.UseInMemory)
        {
            return new DbContextOptionsBuilder<T>()
                .UseInMemoryDatabase(options.Value.InMemoryConnectionstring)
                .Options;
        }
        
        if (options.Value.UseSQLite)
        {
            return new DbContextOptionsBuilder<T>()
                .UseInMemoryDatabase(options.Value.SQLiteConnectionstring)
                .Options;
        }

        return new DbContextOptions<T>();
    }

    public static Mock<IMediator> GetIMediatorMock()
    {
        return new Mock<IMediator>();
    }

    public static CancellationToken GetCancellationToken()
    {
        return new CancellationTokenSource().Token;
    }

    public static EntityTypeBuilder<TU> GetEntityConfigurationMetadata<T, TU>(
        T context,
        IEntityTypeConfiguration<TU> configuration) where T : DbContext where TU : class
    {
        var conventionSet = ConventionSet.CreateConventionSet(context);
        var modelBuilder = new ModelBuilder(conventionSet);
        var entityTypeBuilder = modelBuilder.Entity<TU>();
        configuration.Configure(entityTypeBuilder);

        return entityTypeBuilder;
    }
}