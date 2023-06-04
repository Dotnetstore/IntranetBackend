using Domain.Organization;
using FluentAssertions;
using Organization.Queries.OwnCompanyGet;
using TestHelper.FakeData;

namespace Organization.Tests.Queries.OwnCompanyGet;

public class GetOwnCompanyQueryValidatorTests
{
    private GetOwnCompanyQueryValidator _validator = null!;
    private OwnCompany _fakeObjectToTest = null!;
    
    [SetUp]
    public void Setup()
    {
        _validator = new GetOwnCompanyQueryValidator();
        _fakeObjectToTest = OrganizationFakeData.CreateOwnCompanyFakeData()[0];
    }

    [Test]
    public void CreateCompanyCommandValidator_Should_BeSealed()
    {
        typeof(GetOwnCompanyQueryValidator)
            .Should()
            .BeSealed();
    }

    [Test]
    public void Name_Should_Have_MaximumLength100()
    {
        _fakeObjectToTest.Name = "a".PadLeft(101, 's');
        
        var query = new GetOwnCompanyQuery(_fakeObjectToTest.Name, null, null);
        
        _validator.Validate(query).IsValid.Should().BeFalse();
        _validator.Validate(query).Errors.Should().NotBeEmpty();
    }

    [Test]
    public void VATNumber_Should_Have_MaximumLength30()
    {
        _fakeObjectToTest.VATNumber = "a".PadLeft(31, 's');
        
        var query = new GetOwnCompanyQuery(null, _fakeObjectToTest.VATNumber, null);
        
        _validator.Validate(query).IsValid.Should().BeFalse();
        _validator.Validate(query).Errors.Should().NotBeEmpty();
    }
}