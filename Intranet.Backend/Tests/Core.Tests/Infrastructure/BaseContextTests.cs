using Core.Infrastructure;
using FluentAssertions;

namespace Core.Tests.Infrastructure;

internal sealed class BaseContextTests
{
    [Test]
    public void BaseContext_Should_Be_Abstract()
    {
        typeof(BaseContext)
            .Should()
            .BeAbstract();
    }
}