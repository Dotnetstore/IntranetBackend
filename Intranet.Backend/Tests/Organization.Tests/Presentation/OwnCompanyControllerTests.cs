using Core.Infrastructure;
using Domain.Organization;
using FluentAssertions;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using Moq;
using Organization.Application;
using Organization.Presentation;
using Organization.Queries.OwnCompanyGet;
using Organization.Tests.TestSettings;
using Shared.Organization;
using TestHelper.Helpers;

namespace Organization.Tests.Presentation;

internal sealed class OwnCompanyControllerTests
{
    private List<OwnCompany> _fakeData = null!;
    private Mock<IMediator> _mediatorMock = null!;
    private OwnCompanyController _ownCompanyController = null!;
    private CancellationToken _cancellationToken;
    
    [SetUp]
    public void Setup()
    {
        _cancellationToken = GenericTestObjects.GetCancellationToken();
        _mediatorMock = GenericTestObjects.GetIMediatorMock();
        _fakeData = OrganizationFakeData.CreateOwnCompanyFakeData();
        _ownCompanyController = new OwnCompanyController(_mediatorMock.Object);
    }
    
    [Test]
    public void OwnCompanyController_Should_Be_Sealed()
    {
        typeof(OwnCompanyController)
            .Should()
            .BeSealed();
    }
    
    [Test]
    public void OwnCompanyController_Should_Have_IMediator()
    {
        _ownCompanyController.Mediator.Should().NotBeNull();
    }
    
    [Test]
    public async Task GetAsync_Should_ReturnFakeList()
    {
        var query = new GetOwnCompanyQuery(null, null, null);
        
        _mediatorMock.Setup(q => q.Send(query, _cancellationToken))
            .ReturnsAsync((GetOwnCompanyQuery getOwnCompanyQuery, CancellationToken cancellationToken) => 
                _fakeData.AsQueryable()
                    .WhereNullable(getOwnCompanyQuery.Name, q => q.Name == getOwnCompanyQuery.Name)
                    .WhereNullable(getOwnCompanyQuery.VATNumber, q => q.VATNumber == getOwnCompanyQuery.VATNumber)
                    .WhereNullable(getOwnCompanyQuery.IsSystem, q => q.IsSystem == getOwnCompanyQuery.IsSystem)
                    .Select(q => q.ToDTO())
                    .ToList()
            );
    
        var result = await _ownCompanyController.GetAsync(null, null, null, _cancellationToken) as OkObjectResult;
        
        _mediatorMock.Verify(q => q.Send(query, _cancellationToken), Times.Once);
    
        var values = result?.Value as IEnumerable<OwnCompanyDTO>;
    
        values.Should().BeEquivalentTo(_fakeData.Select(q => q.ToDTO()));
    }
    
    [Test]
    public async Task GetAsync_Should_ReturnFakeListFilterOnName()
    {
        _mediatorMock.Setup(q => q.Send(It.IsAny<GetOwnCompanyQuery>(), It.IsAny<CancellationToken>()))
            .ReturnsAsync((GetOwnCompanyQuery getOwnCompanyQuery, CancellationToken cancellationToken) => 
                _fakeData.AsQueryable()
                    .WhereNullable(getOwnCompanyQuery.Name, q => q.Name == getOwnCompanyQuery.Name)
                    .WhereNullable(getOwnCompanyQuery.VATNumber, q => q.VATNumber == getOwnCompanyQuery.VATNumber)
                    .WhereNullable(getOwnCompanyQuery.IsSystem, q => q.IsSystem == getOwnCompanyQuery.IsSystem)
                    .Select(q => q.ToDTO())
                    .ToList()
            );
    
        var result = await _ownCompanyController.GetAsync("Consid", null, null, _cancellationToken) as OkObjectResult;
        
        var value = (result?.Value as IEnumerable<OwnCompanyDTO>).Single();

        value.Name.Should().Be("Consid");
    }
    
    [Test]
    public async Task GetAsync_Should_ReturnFakeListFilterOnVatNumber()
    {
        _mediatorMock.Setup(q => q.Send(It.IsAny<GetOwnCompanyQuery>(), It.IsAny<CancellationToken>()))
            .ReturnsAsync((GetOwnCompanyQuery getOwnCompanyQuery, CancellationToken cancellationToken) => 
                _fakeData.AsQueryable()
                    .WhereNullable(getOwnCompanyQuery.Name, q => q.Name == getOwnCompanyQuery.Name)
                    .WhereNullable(getOwnCompanyQuery.VATNumber, q => q.VATNumber == getOwnCompanyQuery.VATNumber)
                    .WhereNullable(getOwnCompanyQuery.IsSystem, q => q.IsSystem == getOwnCompanyQuery.IsSystem)
                    .Select(q => q.ToDTO())
                    .ToList()
            );
    
        var result = await _ownCompanyController.GetAsync(null, "SE556599430701", null, _cancellationToken) as OkObjectResult;
        
        var value = (result?.Value as IEnumerable<OwnCompanyDTO>).Single();

        value.Name.Should().Be("Consid");
    }
    
    [Test]
    public async Task GetAsync_Should_ReturnFakeListFilterOnIsSystem()
    {
        _mediatorMock.Setup(q => q.Send(It.IsAny<GetOwnCompanyQuery>(), It.IsAny<CancellationToken>()))
            .ReturnsAsync((GetOwnCompanyQuery getOwnCompanyQuery, CancellationToken cancellationToken) => 
                _fakeData.AsQueryable()
                    .WhereNullable(getOwnCompanyQuery.Name, q => q.Name == getOwnCompanyQuery.Name)
                    .WhereNullable(getOwnCompanyQuery.VATNumber, q => q.VATNumber == getOwnCompanyQuery.VATNumber)
                    .WhereNullable(getOwnCompanyQuery.IsSystem, q => q.IsSystem == getOwnCompanyQuery.IsSystem)
                    .Select(q => q.ToDTO())
                    .ToList()
            );
    
        var result = await _ownCompanyController.GetAsync(null, null, true, _cancellationToken) as OkObjectResult;
        
        var value = (result?.Value as IEnumerable<OwnCompanyDTO>).Single();
    
        value.Name.Should().Be("Consid");
    }
}