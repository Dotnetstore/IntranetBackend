using Core.Infrastructure;
using FluentAssertions;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Moq;
using Organization.Application;
using Organization.Presentation;
using Organization.Queries.OwnCompanyGet;
using Shared.Organization;
using TestHelper.FakeData;

namespace Organization.Tests.Presentation;

internal sealed class OwnCompanyControllerTests
{
    private Mock<IMediator> _mediatorMock;
    private OwnCompanyController _ownCompanyController;
    private CancellationToken _cancellationToken;

    [SetUp]
    public void Setup()
    {
        _cancellationToken = new CancellationTokenSource().Token;
        
        var mediatorMock = new Mock<IMediator>();
        _mediatorMock = mediatorMock;

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
        var mock = new Mock<IMediator>();
        var controller = new OwnCompanyController(mock.Object);

        controller.Mediator.Should().NotBeNull();
    }

    [Test]
    public async Task GetAsync()
    {
        var query = new GetOwnCompanyQuery(null, null, null);
        
        _mediatorMock.Setup(q => q.Send(query, _cancellationToken))
            .ReturnsAsync((GetOwnCompanyQuery getOwnCompanyQuery, CancellationToken cancellationToken) => 
                OrganizationFakeData.CreateOwnCompanyFakeData().AsQueryable()
                    .WhereNullable(getOwnCompanyQuery.Name, q => q.Name == getOwnCompanyQuery.Name)
                    .WhereNullable(getOwnCompanyQuery.VATNumber, q => q.VATNumber == getOwnCompanyQuery.VATNumber)
                    .WhereNullable(getOwnCompanyQuery.IsSystem, q => q.IsSystem == getOwnCompanyQuery.IsSystem)
                    .Select(q => q.ToDTO())
                    .ToList()
                );

        var result = await _ownCompanyController.GetAsync(null, null, null, _cancellationToken) as OkObjectResult;
        
        _mediatorMock.Verify(q => q.Send(query, _cancellationToken), Times.Once);

        var values = result?.Value as IEnumerable<OwnCompanyDTO>;

        values?.Count().Should().Be(2);
    }
}