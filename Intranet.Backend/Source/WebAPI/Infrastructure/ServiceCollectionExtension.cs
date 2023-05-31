namespace WebAPI.Infrastructure;

internal static class ServiceCollectionExtension
{
    internal static WebApplicationBuilder AddWebAPIServices(this WebApplicationBuilder webApplicationBuilder)
    {
        webApplicationBuilder.Services.AddControllers();
        webApplicationBuilder.Services.AddEndpointsApiExplorer();
        webApplicationBuilder.Services.AddSwaggerGen();

        return webApplicationBuilder;
    }
}