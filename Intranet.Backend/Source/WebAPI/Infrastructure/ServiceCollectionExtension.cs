using System.Reflection;
using Organization.Infrastructure;
using Settings.Domain;

namespace WebAPI.Infrastructure;

internal static class ServiceCollectionExtension
{
    internal static readonly Assembly[] Assemblies = {
        typeof(Organization.AssemblyReference).Assembly
    };
    
    internal static WebApplicationBuilder AddWebAPIServices(this WebApplicationBuilder webApplicationBuilder)
    {
        var configuration = webApplicationBuilder.Configuration;
        
        webApplicationBuilder.Services
            .AddOptions<DatabaseOptions>()
            .Bind(configuration.GetRequiredSection(DatabaseOptions.SectionName))
            .ValidateDataAnnotations()
            .ValidateOnStart();
        
        webApplicationBuilder.AddOrganizationServices();
        
        webApplicationBuilder.Services.AddMediatR(q =>
        {
            q.RegisterServicesFromAssemblies(Assemblies);
        });
        
        webApplicationBuilder.Services.AddControllers();
        webApplicationBuilder.Services.AddEndpointsApiExplorer();
        webApplicationBuilder.Services.AddSwaggerGen();

        return webApplicationBuilder;
    }
}