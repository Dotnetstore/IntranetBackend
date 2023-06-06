using Domain.Organization;
using FluentAssertions;
using Moq;
using Organization.Abstractions;
using Organization.Application;
using Organization.Infrastructure;
using Organization.Queries.OwnCompanyGet;
using Organization.Tests.TestSettings;
using Shared.Organization;
using TestHelper.Helpers;

namespace Organization.Tests.Application;

internal sealed class OwnCompanyRepositoryTests
{
    private CancellationToken _cancellationToken;
    private IEnumerable<OwnCompanyDTO> _expected = null!;
    private Mock<OrganizationContext> _organizationContextMock = null!;
    private IOwnCompanyRepository _ownCompanyRepository = null!;
    private OwnCompany _data = null!;

    [SetUp]
    public void Setup()
    {
        _cancellationToken = GenericTestObjects.GetCancellationToken();
        _expected = OrganizationFakeData.CreateOwnCompanyFakeData().Select(q => q.ToDTO());
        _organizationContextMock = OrganizationTestObjects.GetOrganizationContextMockForAsync();
        _ownCompanyRepository = new OwnCompanyRepository(_organizationContextMock.Object);
        _data = OrganizationFakeData.CreateOwnCompanyFakeData()[0];
    }
    
    [Test]
    public async Task GetAsync_Should_ReturnAllObjects()
    {
        var query = new GetOwnCompanyQuery(null, null, null);

        var result = await _ownCompanyRepository.GetAsync(query, _cancellationToken);

        result.Should().BeEquivalentTo(_expected);
        _organizationContextMock.Verify(q => q.OwnCompanies, Times.Once);
    }

    [Test]
    public void Add_Should_AddObject()
    {
        _ownCompanyRepository.Add(_data);
        
        _organizationContextMock.Verify(q => q.OwnCompanies.Add(_data), Times.Once);
    }
}