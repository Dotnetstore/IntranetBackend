using FluentAssertions;
using Shared.Base;
using Shared.Organization;

namespace Shared.Tests.Base;

internal sealed class CompanyDTOTests
{
    [Test]
    public void BaseModel_Should_Be_Abstract()
    {
        typeof(CompanyDTO)
            .Should()
            .BeAbstract();
    }
    
    [Test]
    public void Name_Should_Be_String()
    {
        const string name = "Dotnetstore";
        var dto = new OwnCompanyDTO {ID = Guid.NewGuid(), CreatedDate = DateTimeOffset.Now, Name = name, IsDeleted = false, IsSystem = false};
        
        dto.Name.Should().Be(name);
    }
    
    [Test]
    public void CreatedDate_Should_Be_DateTimeOffset()
    {
        const string vatNumber = "1234567890";
        var dto = new OwnCompanyDTO {ID = Guid.NewGuid(), CreatedDate = DateTimeOffset.Now, Name = "Dotnetstore", IsDeleted = false, IsSystem = false, VATNumber = vatNumber};
        
        dto.VATNumber.Should().Be(vatNumber);
    }
}