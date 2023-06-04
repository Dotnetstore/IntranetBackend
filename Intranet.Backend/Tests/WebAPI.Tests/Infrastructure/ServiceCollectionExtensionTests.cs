using FluentAssertions;
using Microsoft.AspNetCore.Builder;
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

    [Test]
    public void Assemblies_Should_Contain1Assemblies()
    {
        var assemblies = ServiceCollectionExtension.Assemblies;

        assemblies.Length.Should().Be(1);
    }

    [Test]
    public void AddWebAPIServices_Should_Return_WebApplicationBuilder()
    {
        var builder = WebApplication.CreateBuilder();
        var result = builder.AddWebAPIServices();

        result.Should().BeOfType<WebApplicationBuilder>();
    }
}