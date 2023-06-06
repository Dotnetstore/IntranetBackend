using Domain.Organization;
using FluentAssertions;
using FluentAssertions.Execution;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Organization.Infrastructure;
using TestHelper.Helpers;

namespace Organization.Tests.Infrastructure;

internal sealed class OwnCompanyConfigurationTests
{
    private EntityTypeBuilder<OwnCompany> _builder = null!;
    
    [SetUp]
    public void Setup()
    {
        var configuration = new OwnCompanyConfiguration();
        var options = GenericTestObjects.GetDbContextOptions<OrganizationContext>();
        var databaseOptions = GenericTestObjects.GetDatabaseOptionsSQL();
        
        _builder = GenericTestObjects.GetEntityConfigurationMetadata(
            new OrganizationContext(
                options,
                databaseOptions),
            configuration);
    }
    
    [Test]
    public void ID_Should_Be_Required()
    {
        var idProperty = _builder.Metadata.FindDeclaredProperty(nameof(OwnCompany.ID));
    
        idProperty?.IsNullable.Should().BeFalse();
    }
    
    [Test]
    public void Name_Should_Be_RequiredAndHaveMaxLength100()
    {
        var nameProperty = _builder.Metadata.FindDeclaredProperty(nameof(OwnCompany.Name));
    
        using (new AssertionScope())
        {
            nameProperty?.IsNullable.Should().BeFalse();
            nameProperty?.GetMaxLength().Should().Be(100);
            nameProperty?.IsUnicode().Should().BeTrue();
            nameProperty?.GetColumnType().Should().Be("nvarchar");
        }
    }
    
    [Test]
    public void CreatedDate_Should_Be_Required()
    {
        var createdDateProperty = _builder.Metadata.FindDeclaredProperty(nameof(OwnCompany.CreatedDate));
    
        createdDateProperty?.IsNullable.Should().BeFalse();
    }
    
    [Test]
    public void VATNumber_Should_Be_NullableAndHaveMaxLength30()
    {
        var vatNumberProperty = _builder.Metadata.FindDeclaredProperty(nameof(OwnCompany.VATNumber));
    
        using (new AssertionScope())
        {
            vatNumberProperty?.IsNullable.Should().BeTrue();
            vatNumberProperty?.GetMaxLength().Should().Be(30);
            vatNumberProperty?.IsUnicode().Should().BeFalse();
            vatNumberProperty?.GetColumnType().Should().Be("varchar");
        }
    }
}