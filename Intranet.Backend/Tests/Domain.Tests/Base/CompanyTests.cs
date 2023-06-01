using Domain.Base;
using FluentAssertions;
using Moq;

namespace Domain.Tests.Base;

internal sealed class CompanyTests
{
    private Mock<Company> _companyMock = null!;

    [SetUp]
    public void Setup()
    {
        _companyMock = new Mock<Company>();
    }

    [Test]
    public void BaseModel_Should_Be_Abstract()
    {
        typeof(BaseModel)
            .Should()
            .BeAbstract();
    }
    
    [Test]
    public void Name_Should_Be_String()
    {
        const string name = "Dotnetstore";
        _companyMock.Object.Name = name;
        
        _companyMock.Object.Name.Should().Be(name);
    }
    
    [Test]
    public void CreatedDate_Should_Be_DateTimeOffset()
    {
        const string vatNumber = "1234567890";
        _companyMock.Object.VATNumber = vatNumber;
        
        _companyMock.Object.VATNumber.Should().Be(vatNumber);
    }
}