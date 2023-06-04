using FluentAssertions;

namespace Organization.Tests;

internal sealed class AssemblyReferenceTests
{
    [Test]
    public void AssemblyReference_Should_Be_Static()
    {
        typeof(AssemblyReference)
            .Should()
            .BeStatic();
    }
}