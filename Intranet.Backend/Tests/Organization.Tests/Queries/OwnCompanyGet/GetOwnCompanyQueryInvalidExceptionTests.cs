using FluentAssertions;
using MediatR;
using Moq;
using Organization.Abstractions;
using Organization.Queries.OwnCompanyGet;
using Shared.Organization;

namespace Organization.Tests.Queries.OwnCompanyGet;

public class GetOwnCompanyQueryInvalidExceptionTests
{
    private CancellationToken _cancellationToken;
    private IRequestHandler<GetOwnCompanyQuery, IEnumerable<OwnCompanyDTO>> _handler = null!;

    [SetUp]
    public void Setup()
    {
        _cancellationToken = new CancellationTokenSource().Token;
        var repository = new Mock<IOwnCompanyRepository>();
        _handler = new GetOwnCompanyQueryHandler(repository.Object);
    }
    
    [Test]
    public void GetOwnCompanyQueryInvalidException_Should_BeSealed()
    {
        typeof(GetOwnCompanyQueryInvalidException)
            .Should()
            .BeSealed();
    }

    [Test]
    public async Task GetOwnCompanyQueryInvalidException_Should_BeThrownForName()
    {
        var name = "a".PadLeft(101, 'a');
        var query = new GetOwnCompanyQuery(name, null, null);

        var result = async () => { await _handler.Handle(query, _cancellationToken); };

        await result.Should().ThrowAsync<GetOwnCompanyQueryInvalidException>();
    }

    [Test]
    public async Task GetOwnCompanyQueryInvalidException_Should_BeThrownForVATNumber()
    {
        var vatNumber = "a".PadLeft(31, 'a');
        var query = new GetOwnCompanyQuery(null, vatNumber, null);

        var result = async () => { await _handler.Handle(query, _cancellationToken); };

        await result.Should().ThrowAsync<GetOwnCompanyQueryInvalidException>();
    }
}