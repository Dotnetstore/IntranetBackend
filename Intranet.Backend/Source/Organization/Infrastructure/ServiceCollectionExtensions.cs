using Core.Abstractions;
using Microsoft.AspNetCore.Builder;
using Microsoft.Extensions.DependencyInjection;
using Organization.Abstractions;
using Organization.Application;

namespace Organization.Infrastructure;

public static class ServiceCollectionExtensions
{
    public static WebApplicationBuilder AddOrganizationServices(this WebApplicationBuilder webApplicationBuilder)
    {
        webApplicationBuilder.Services.AddDbContext<OrganizationContext>(ServiceLifetime.Scoped);
        
        webApplicationBuilder.Services.AddScoped<IOwnCompanyRepository, OwnCompanyRepository>();

        webApplicationBuilder.Services.AddScoped<IUnitOfWork>(
            q => q.GetRequiredService<OrganizationContext>());

        return webApplicationBuilder;
    }
}