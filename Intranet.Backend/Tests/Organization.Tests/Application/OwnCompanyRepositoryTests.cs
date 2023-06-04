using Core.Infrastructure;
using Domain.Organization;
using Microsoft.EntityFrameworkCore;
using MockQueryable.Moq;
using Moq;
using Organization.Abstractions;
using Organization.Application;
using Organization.Infrastructure;
using Organization.Queries.OwnCompanyGet;
using TestHelper.FakeData;

namespace Organization.Tests.Application;

internal sealed class OwnCompanyRepositoryTests
{
    private CancellationToken _cancellationToken;
    private Mock<OrganizationContext> _organizationContextMock = null!;
    private Mock<IOwnCompanyRepository> _ownCompanyRepositoryMock = null!;

    [SetUp]
    public void Setup()
    {
        var mockOwnCompanyEntities = OrganizationFakeData.CreateOwnCompanyFakeData().BuildMock().BuildMockDbSet();
        _cancellationToken = new CancellationTokenSource().Token;
        _organizationContextMock = new Mock<OrganizationContext>();

        _organizationContextMock.Setup<DbSet<OwnCompany>>(q => q.OwnCompanies)
            .Returns(mockOwnCompanyEntities.Object);

        _ownCompanyRepositoryMock = new Mock<IOwnCompanyRepository>();
        
        _ownCompanyRepositoryMock.Setup(q => q.GetAsync(It.IsAny<GetOwnCompanyQuery>(), It.IsAny<CancellationToken>()))
            .ReturnsAsync((GetOwnCompanyQuery getOwnCompanyQuery, CancellationToken cancellationToken) =>
                mockOwnCompanyEntities.Object
                    .WhereNullable(getOwnCompanyQuery.Name, q => q.Name == getOwnCompanyQuery.Name)
                    .WhereNullable(getOwnCompanyQuery.VATNumber, q => q.VATNumber == getOwnCompanyQuery.VATNumber)
                    .WhereNullable(getOwnCompanyQuery.IsSystem, q => q.IsSystem == getOwnCompanyQuery.IsSystem)
                    .Select(q => q.ToDTO())
                    .ToList());
    }

    [Test]
    public async Task Get_Should_Run_WithCorrectData()
    {
        var query = new GetOwnCompanyQuery(null, null, null);

        await _ownCompanyRepositoryMock.Object.GetAsync(query, _cancellationToken);
        
        _ownCompanyRepositoryMock.Verify(q => q.GetAsync(query, _cancellationToken), Times.Once);
    }
}