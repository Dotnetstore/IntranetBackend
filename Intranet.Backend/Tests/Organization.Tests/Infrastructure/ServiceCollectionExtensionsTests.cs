using Core.Abstractions;
using FluentAssertions;
using FluentAssertions.Microsoft.Extensions.DependencyInjection;
using Microsoft.AspNetCore.Builder;
using Organization.Abstractions;
using Organization.Application;
using Organization.Infrastructure;

namespace Organization.Tests.Infrastructure;

internal sealed class ServiceCollectionExtensionsTests
{
    [Test]
    public void AddOrganizationServices_Should_Have_Services()
    {
        var builder = WebApplication.CreateBuilder();
        builder = builder.AddOrganizationServices();

        builder.Services.Should().HaveService<IOwnCompanyRepository>().WithImplementation<OwnCompanyRepository>().AsScoped();
        builder.Services.Should().HaveService<IUnitOfWork>().AsScoped();
    }

    [Test]
    public void AddOrganizationServices_Should_Return_WebApplicationBuilder()
    {
        var builder = WebApplication.CreateBuilder();
        builder = builder.AddOrganizationServices();

        builder.Should().BeOfType<WebApplicationBuilder>();
    }
}