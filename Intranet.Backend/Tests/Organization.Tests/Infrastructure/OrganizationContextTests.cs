using FluentAssertions;
using Microsoft.EntityFrameworkCore;
using Moq;
using Organization.Infrastructure;
using Organization.Tests.TestSettings;
using TestHelper.Helpers;

namespace Organization.Tests.Infrastructure;

internal sealed class OrganizationContextTests
{
    [Test]
    public void OwnCompanies_Should_Return2Objects()
    {
        var contextMock = OrganizationTestObjects.GetOrganizationContextMock();

        var result = contextMock.Object.OwnCompanies;

        result.Should().BeEquivalentTo(OrganizationFakeData.CreateOwnCompanyFakeData());
        contextMock.Verify(q => q.OwnCompanies, Times.Once);
    }

    [Test]
    public void ModelBuilder_Should_Not_ThrowException()
    {
        var context = OrganizationTestObjects.GetOrganizationContextMock().Object;
        
        Assert.That(() => context.Model, Throws.Nothing);
    }

    [Test]
    public void Constructor_Should_Set_CorrectValuesSQL()
    {
        var options = GenericTestObjects.GetDbContextOptions<OrganizationContext>();
        var databaseOptions = GenericTestObjects.GetDatabaseOptionsSQL();
        
        var context = new OrganizationContext(
            options,
            databaseOptions);

        context.Database.GetConnectionString().Should().Be(databaseOptions.Value.SQLConnectionstring);
    }
    
    [Test]
    public void OrganizationContext_Should_Not_Be_StaticOrSealed()
    {
        typeof(OrganizationContext)
            .Should()
            .NotBeStatic()
            .And
            .NotBeSealed();
    }
}