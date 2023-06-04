using FluentAssertions;
using Shared.Organization;

namespace Shared.Tests.Organization;

public class OwnCompanyDTOTests
{
    [Test]
    public void OwnCompanyDTO_Should_Be_Sealed()
    {
        typeof(OwnCompanyDTO)
            .Should()
            .BeSealed();
    }
}