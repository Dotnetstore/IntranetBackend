using Microsoft.Data.Sqlite;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore.Metadata.Conventions;
using Microsoft.Extensions.Options;
using Settings.Domain;

namespace TestHelper.FakeData;

public static class SettingsFakeData
{
    public static DbContextOptions<T> GetDbContextOptions<T>(IOptions<DatabaseOptions> options) where T : DbContext
    {
        return new DbContextOptionsBuilder<T>()
            .UseSqlServer(options.Value.SQLConnectionstring)
            .Options;
    }

    public static IOptions<DatabaseOptions> GetDatabaseOptions()
    {
        return Options.Create(new DatabaseOptions
        {
            InMemoryConnectionstring = "DotnetstoreIntranetInMemoryTest",
            SQLConnectionstring = "Server=localhost;Database=DotnetstoreIntranetTest;Trusted_Connection=True;MultipleActiveResultSets=true;TrustServerCertificate=True;",
            SQLiteConnectionstring = "Data Source=c:\\Dotnetstore\\DotnetstoreIntranetTest.db",
            UseInMemory = false,
            UseSQL = true,
            UseSQLite = false
        });
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