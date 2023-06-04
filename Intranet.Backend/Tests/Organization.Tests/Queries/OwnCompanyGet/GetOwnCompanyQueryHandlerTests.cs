using Core.Infrastructure;
using Domain.Organization;
using MediatR;
using Moq;
using Organization.Abstractions;
using Organization.Application;
using Organization.Queries.OwnCompanyGet;
using Shared.Organization;
using TestHelper.FakeData;

namespace Organization.Tests.Queries.OwnCompanyGet;

internal sealed class GetOwnCompanyQueryHandlerTests
{
    private CancellationToken _cancellationToken;
    private Mock<IOwnCompanyRepository> _ownCompanyRepositoryMock = null!;
    private IList<OwnCompany> _ownCompanies = null!;
    private IRequestHandler<GetOwnCompanyQuery, IEnumerable<OwnCompanyDTO>> _handler = null!;

    [Test]
    public async Task Handle_Should_RunIOwnCompanyRepository()
    {
        var objectToTest = OrganizationFakeData.CreateOwnCompanyFakeData()[0];
        var query = new GetOwnCompanyQuery(objectToTest.Name, objectToTest.VATNumber, objectToTest.IsSystem);

        await _handler.Handle(query, _cancellationToken);
        
        _ownCompanyRepositoryMock.Verify(q => q.GetAsync(query, _cancellationToken), Times.Once);
    }

    [SetUp]
    public void Setup()
    {
        _cancellationToken = new CancellationTokenSource().Token;
        _ownCompanies = OrganizationFakeData.CreateOwnCompanyFakeData();

        _ownCompanyRepositoryMock = new Mock<IOwnCompanyRepository>();

        _ownCompanyRepositoryMock.Setup(q => q.GetAsync(
                It.IsAny<GetOwnCompanyQuery>(), It.IsAny<CancellationToken>()))
            .ReturnsAsync((GetOwnCompanyQuery getOwnCompanyQuery, CancellationToken cancellationToken) =>
                _ownCompanies.AsQueryable()
                    .WhereNullable(getOwnCompanyQuery.Name, q => q.Name == getOwnCompanyQuery.Name)
                    .WhereNullable(getOwnCompanyQuery.VATNumber, q => q.Name == getOwnCompanyQuery.VATNumber)
                    .WhereNullable(getOwnCompanyQuery.IsSystem, q => q.IsSystem == getOwnCompanyQuery.IsSystem)
                    .Select(q => q.ToDTO())
                    .ToList());

        _handler = new GetOwnCompanyQueryHandler(_ownCompanyRepositoryMock.Object);
    }
}