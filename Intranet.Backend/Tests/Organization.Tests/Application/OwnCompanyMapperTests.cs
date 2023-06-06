using FluentAssertions;
using Organization.Application;
using Organization.Tests.TestSettings;
using Shared.Organization;

namespace Organization.Tests.Application;

internal sealed class OwnCompanyMapperTests
{
    [Test]
    public void OwnCompanyMapper_Should_Be_Static()
    {
        typeof(OwnCompanyMapper)
            .Should()
            .BeStatic();
    }
    
    [Test]
    public void ToDTO_Should_ReturnCorrectMapping()
    {
        var objectToTest = OrganizationFakeData.CreateOwnCompanyFakeData()[0];
    
        var result = objectToTest.ToDTO();
    
        result.Should().BeOfType<OwnCompanyDTO>();
    
        result.CreatedBy.Should().Be(objectToTest.CreatedBy);
        result.CreatedDate.Should().Be(objectToTest.CreatedDate);
        result.DeletedBy.Should().Be(objectToTest.DeletedBy);
        result.DeletedDate.Should().Be(objectToTest.DeletedDate);
        result.ID.Should().Be(objectToTest.ID);
        result.IsDeleted.Should().Be(objectToTest.IsDeleted);
        result.IsSystem.Should().Be(objectToTest.IsSystem);
        result.LastUpdatedBy.Should().Be(objectToTest.LastUpdatedBy);
        result.LastUpdatedDate.Should().Be(objectToTest.LastUpdatedDate);
        result.Name.Should().Be(objectToTest.Name);
        result.VATNumber.Should().Be(objectToTest.VATNumber);
    }
}