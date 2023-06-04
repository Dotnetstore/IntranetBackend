using FluentAssertions;
using Shared.Base;
using Shared.Organization;

namespace Shared.Tests.Base;

internal sealed class BaseModelDTOTests
{
    [Test]
    public void BaseModelDTO_Should_Be_Abstract()
    {
        typeof(BaseModelDTO)
            .Should()
            .BeAbstract();
    }
    
    [Test]
    public void ID_Should_Be_Guid()
    {
        var id = Guid.NewGuid();
        var dto = new OwnCompanyDTO {ID = id, CreatedDate = DateTimeOffset.Now, Name = "Dotnetstore", IsDeleted = false, IsSystem = false};
        
        dto.ID.Should().Be(id);
    }
    
    [Test]
    public void CreatedDate_Should_Be_DateTimeOffset()
    {
        var createdDate = DateTimeOffset.Now;
        var dto = new OwnCompanyDTO {ID = Guid.NewGuid(), CreatedDate = createdDate, Name = "Dotnetstore", IsDeleted = false, IsSystem = false};
        
        dto.CreatedDate.Should().Be(createdDate);
    }
    
    [Test]
    public void CreatedBy_Should_Be_Guid()
    {
        var createdBy = Guid.NewGuid();
        var dto = new OwnCompanyDTO {ID = Guid.NewGuid(), CreatedDate = DateTimeOffset.Now, Name = "Dotnetstore", IsDeleted = false, IsSystem = false, CreatedBy = createdBy};
        
        dto.CreatedBy.Should().Be(createdBy);
    }
    
    [Test]
    public void LastUpdatedDate_Should_Be_NullableDateTimeOffset()
    {
        var lastUpdatedDate = DateTimeOffset.Now;
        var dto = new OwnCompanyDTO {ID = Guid.NewGuid(), CreatedDate = DateTimeOffset.Now, Name = "Dotnetstore", IsDeleted = false, IsSystem = false, LastUpdatedDate = lastUpdatedDate};
        
        dto.LastUpdatedDate.Should().Be(lastUpdatedDate);
    }
    
    [Test]
    public void LastUpdatedBy_Should_Be_Guid()
    {
        var lastUpdatedBy = Guid.NewGuid();
        var dto = new OwnCompanyDTO {ID = Guid.NewGuid(), CreatedDate = DateTimeOffset.Now, Name = "Dotnetstore", IsDeleted = false, IsSystem = false, LastUpdatedBy = lastUpdatedBy};
        
        dto.LastUpdatedBy.Should().Be(lastUpdatedBy);
    }
    
    [Test]
    public void DeletedDate_Should_Be_DateTimeOffset()
    {
        var deletedDate = DateTimeOffset.Now;
        var dto = new OwnCompanyDTO {ID = Guid.NewGuid(), CreatedDate = DateTimeOffset.Now, Name = "Dotnetstore", IsDeleted = false, IsSystem = false, DeletedDate = deletedDate};
        
        dto.DeletedDate.Should().Be(deletedDate);
    }
    
    [Test]
    public void DeletedBy_Should_Be_NullableGuid()
    {
        var deletedBy = Guid.NewGuid();
        var dto = new OwnCompanyDTO {ID = Guid.NewGuid(), CreatedDate = DateTimeOffset.Now, Name = "Dotnetstore", IsDeleted = false, IsSystem = false, DeletedBy = deletedBy};
        
        dto.DeletedBy.Should().Be(deletedBy);
    }
    
    [Test]
    public void IsDeleted_Should_Be_Boolean()
    {
        const bool isDeleted = false;
        var dto = new OwnCompanyDTO {ID = Guid.NewGuid(), CreatedDate = DateTimeOffset.Now, Name = "Dotnetstore", IsDeleted = isDeleted, IsSystem = false};
        
        dto.IsDeleted.Should().Be(isDeleted);
    }
    
    [Test]
    public void IsSystem_Should_Be_Boolean()
    {
        const bool isSystem = false;
        var dto = new OwnCompanyDTO {ID = Guid.NewGuid(), CreatedDate = DateTimeOffset.Now, Name = "Dotnetstore", IsDeleted = false, IsSystem = isSystem};
        
        dto.IsSystem.Should().Be(isSystem);
    }
}