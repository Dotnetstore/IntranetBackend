using Core.Infrastructure;
using Domain.Organization;
using FluentAssertions;
using MediatR;
using Moq;
using Organization.Abstractions;
using Organization.Application;
using Organization.Queries.OwnCompanyGet;
using Organization.Tests.TestSettings;
using Shared.Organization;
using TestHelper.Helpers;

namespace Organization.Tests.Queries.OwnCompanyGet;

internal sealed class GetOwnCompanyQueryHandlerTests
{
    private CancellationToken _cancellationToken;
    private Mock<IOwnCompanyRepository> _ownCompanyRepositoryMock = null!;
    private IList<OwnCompany> _ownCompanies = null!;
    private IRequestHandler<GetOwnCompanyQuery, IEnumerable<OwnCompanyDTO>> _handler = null!;
    private OwnCompany _objectToTest = null!;
    
    [Test]
    public async Task Handle_Should_RunIOwnCompanyRepository()
    {
        var query = new GetOwnCompanyQuery(_objectToTest.Name, _objectToTest.VATNumber, _objectToTest.IsSystem);
    
        await _handler.Handle(query, _cancellationToken);
        
        _ownCompanyRepositoryMock.Verify(q => q.GetAsync(query, _cancellationToken), Times.Once);
    }
    
    [Test]
    public void Handle_Should_ThrowAnExceptionInvalidName()
    {
        var query = new GetOwnCompanyQuery("a".PadLeft(101, 'a'), null, null);
    
        Func<Task> act = async () => await _handler.Handle(query, _cancellationToken);
        
        act.Should().ThrowAsync<GetOwnCompanyQueryInvalidException>();
    }
    
    [Test]
    public void Handle_Should_ThrowAnExceptionInvalidVATNumber()
    {
        var query = new GetOwnCompanyQuery("a".PadLeft(31, 'a'), null, null);
    
        Func<Task> act = async () => await _handler.Handle(query, _cancellationToken);
        
        act.Should().ThrowAsync<GetOwnCompanyQueryInvalidException>();
    }
    
    [SetUp]
    public void Setup()
    {
        _ownCompanies = OrganizationFakeData.CreateOwnCompanyFakeData();
        _objectToTest = _ownCompanies[0];
        _cancellationToken = GenericTestObjects.GetCancellationToken();
    
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