using FluentAssertions;
using WebAPI.Infrastructure;

namespace WebAPI.Tests.Infrastructure;

internal sealed class ServiceCollectionExtensionTests
{
    [Test]
    public void AddWebAPIServices_Should_Be_Static()
    {
        typeof(ServiceCollectionExtension)
            .Should()
            .BeStatic();
    }
}