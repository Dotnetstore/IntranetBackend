using FluentAssertions;
using Microsoft.AspNetCore.Builder;
using WebAPI.Application;

namespace WebAPI.Tests.Application;

public class StartupServiceTests
{
    private WebApplicationBuilder _webApplicationBuilder;
    private WebApplication _webApplication;
    
    [SetUp]
    public void Setup()
    {
        _webApplicationBuilder = WebApplication.CreateBuilder();
        _webApplication = _webApplicationBuilder.Build();
    }
    
    [Test]
    public void AddWebAPIServices_Should_Be_Static()
    {
        typeof(StartupService)
            .Should()
            .BeStatic();
    }

    [Test]
    public void AddSwagger_Should_Be_WebApplication()
    {
        var result = _webApplication.AddSwagger();
        
        result.Should().BeOfType<WebApplication>();
    }

    [Test]
    public void RegisterWebApplicationServices_Should_Be_WebApplication()
    {
        var webApplicationBuilder = WebApplication.CreateBuilder();
        webApplicationBuilder.AddServices();
        var webApplication = webApplicationBuilder.Build();
        var result = webApplication.AddSwagger();
        result = result.RegisterWebApplicationServices();

        result.Should().BeOfType<WebApplication>();
    }
}