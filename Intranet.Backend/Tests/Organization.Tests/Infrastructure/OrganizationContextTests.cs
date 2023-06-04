using Domain.Organization;
using FluentAssertions;
using Microsoft.EntityFrameworkCore;
using MockQueryable.Moq;
using Moq;
using Organization.Abstractions;
using Organization.Application;
using Organization.Infrastructure;
using Organization.Queries.OwnCompanyGet;
using TestHelper.FakeData;

namespace Organization.Tests.Infrastructure;

internal sealed class OrganizationContextTests
{
    private CancellationToken _cancellationToken;
    private Mock<OrganizationContext> _organizationContextMock = null!;
    private IOwnCompanyRepository _ownCompanyRepository = null!;
    private OrganizationContext _context = null!;

    [SetUp]
    public void Setup()
    {
        var mockOwnCompanyEntities = OrganizationFakeData.CreateOwnCompanyFakeData().BuildMock().BuildMockDbSet();
        _cancellationToken = new CancellationTokenSource().Token;
        _organizationContextMock = new Mock<OrganizationContext>();

        _organizationContextMock.Setup<DbSet<OwnCompany>>(q => q.OwnCompanies)
            .Returns(mockOwnCompanyEntities.Object);

        _ownCompanyRepository = new OwnCompanyRepository(_organizationContextMock.Object);
        
        var databaseOptions = SettingsFakeData.GetDatabaseOptions();
        var options = SettingsFakeData.GetDbContextOptions<OrganizationContext>(databaseOptions);
        
        _context = new OrganizationContext(
            options, 
            databaseOptions);
    }

    [TestCase(null, null, null, 2)]
    [TestCase("Consid", null, null, 1)]
    [TestCase("Donken", null, null, 0)]
    [TestCase(null, null, true, 1)]
    [TestCase(null, null, false, 1)]
    [TestCase(null, "SE556056625801", null, 1)]
    [TestCase(null, "SE556056625800", null, 0)]
    public async Task Get_Should_ReturnExpectedResult(string? name, string? vatNumber, bool? isSystem, int expectedResult)
    {
        var query = new GetOwnCompanyQuery(name, vatNumber, isSystem);

        var result = await _ownCompanyRepository.GetAsync(query, _cancellationToken);

        _organizationContextMock.Verify(q => q.OwnCompanies, Times.Once);
        result.Count().Should().Be(expectedResult);
    }

    [Test]
    public void OrganizationContext_Should_Not_Be_StaticOrSealed()
    {
        typeof(OrganizationContext)
            .Should()
            .NotBeStatic()
            .And
            .NotBeSealed();
    }

    [Test]
    public void OrganizationContext_Should_Have_OwnCompanies()
    {
        var result = _organizationContextMock.Object.OwnCompanies.ToList();

        result.Count.Should().Be(2);
    }

    [Test]
    public void OnModelCreating_Should_Not_Fail()
    {
        var ownCompanyDbSet = _context.OwnCompanies;
        
        try
        {
            _context.Database.GetConnectionString().Should().Be("Server=localhost;Database=DotnetstoreIntranetTest;Trusted_Connection=True;MultipleActiveResultSets=true;TrustServerCertificate=True;");
            ownCompanyDbSet.Should().NotBeNull();
            Assert.That(() => _context.Model, Throws.Nothing);
        }
        catch (Exception ex)
        {
            Assert.Fail(ex.Message);
        }
    }
}