using FluentAssertions;
using Organization.Queries.OwnCompanyGet;
using Organization.Tests.TestSettings;

namespace Organization.Tests.Queries.OwnCompanyGet;

internal sealed class GetOwnCompanyQueryTests
{
    [Test]
    public void GetOwnCompanyQuery_Should_Be_Sealed()
    {
        typeof(GetOwnCompanyQuery)
            .Should()
            .BeSealed();
    }
    
    [Test]
    public void GetOwnCompanyQuery_Should_HaveCorrectProperties()
    {
        var objectToTest = OrganizationFakeData.CreateOwnCompanyFakeData()[0];
        var getOwnCompanyQuery = new GetOwnCompanyQuery(objectToTest.Name, objectToTest.VATNumber, objectToTest.IsSystem);
    
        getOwnCompanyQuery.Name.Should().Be(objectToTest.Name);
        getOwnCompanyQuery.VATNumber.Should().Be(objectToTest.VATNumber);
        getOwnCompanyQuery.IsSystem.Should().Be(objectToTest.IsSystem);
    }
}