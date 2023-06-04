using Domain.Base;
using FluentAssertions;
using Moq;

namespace Domain.Tests.Base;

internal sealed class BaseModelTests
{
    private Mock<BaseModel> _baseModelMock = null!;

    [SetUp]
    public void Setup()
    {
        _baseModelMock = new Mock<BaseModel>();
    }

    [Test]
    public void BaseModel_Should_Be_Abstract()
    {
        typeof(BaseModel)
            .Should()
            .BeAbstract();
    }
    
    [Test]
    public void ID_Should_Be_Guid()
    {
        var id = Guid.NewGuid();
        _baseModelMock.Object.ID = id;
        
        _baseModelMock.Object.ID.Should().Be(id);
    }
    
    [Test]
    public void CreatedDate_Should_Be_DateTimeOffset()
    {
        var createdDate = DateTimeOffset.Now;
        _baseModelMock.Object.CreatedDate = createdDate;
        
        _baseModelMock.Object.CreatedDate.Should().Be(createdDate);
    }
    
    [Test]
    public void CreatedBy_Should_Be_Guid()
    {
        var createdBy = Guid.NewGuid();
        _baseModelMock.Object.CreatedBy = createdBy;
        
        _baseModelMock.Object.CreatedBy.Should().Be(createdBy);
    }
    
    [Test]
    public void LastUpdatedDate_Should_Be_NullableDateTimeOffset()
    {
        var lastUpdatedDate = DateTimeOffset.Now;
        _baseModelMock.Object.LastUpdatedDate = lastUpdatedDate;
        
        _baseModelMock.Object.LastUpdatedDate.Should().Be(lastUpdatedDate);
    }
    
    [Test]
    public void LastUpdatedBy_Should_Be_Guid()
    {
        var lastUpdatedBy = Guid.NewGuid();
        _baseModelMock.Object.LastUpdatedBy = lastUpdatedBy;
        
        _baseModelMock.Object.LastUpdatedBy.Should().Be(lastUpdatedBy);
    }
    
    [Test]
    public void DeletedDate_Should_Be_DateTimeOffset()
    {
        var deletedDate = DateTimeOffset.Now;
        _baseModelMock.Object.DeletedDate = deletedDate;
        
        _baseModelMock.Object.DeletedDate.Should().Be(deletedDate);
    }
    
    [Test]
    public void DeletedBy_Should_Be_NullableGuid()
    {
        var deletedBy = Guid.NewGuid();
        _baseModelMock.Object.DeletedBy = deletedBy;
        
        _baseModelMock.Object.DeletedBy.Should().Be(deletedBy);
    }
    
    [Test]
    public void IsDeleted_Should_Be_Boolean()
    {
        const bool isDeleted = true;
        _baseModelMock.Object.IsDeleted = isDeleted;

        _baseModelMock.Object.IsDeleted.Should().Be(isDeleted);
    }
    
    [Test]
    public void IsSystem_Should_Be_Boolean()
    {
        const bool isSystem = true;
        _baseModelMock.Object.IsSystem = isSystem;

        _baseModelMock.Object.IsSystem.Should().Be(isSystem);
    }
}