using Domain.Organization;
using FluentAssertions;

namespace Domain.Tests.Organization;

internal sealed class OwnCompanyTests
{
    [Test]
    public void OwnCompany_Should_Be_Sealed()
    {
        typeof(OwnCompany)
            .Should()
            .BeSealed();
    }
}