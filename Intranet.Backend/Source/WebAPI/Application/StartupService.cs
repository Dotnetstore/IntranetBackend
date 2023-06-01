using WebAPI.Infrastructure;

namespace WebAPI.Application;

internal static class StartupService
{
    internal static void AddServices(this WebApplicationBuilder webApplicationBuilder)
    {
        webApplicationBuilder.AddWebAPIServices();
    }

    internal static WebApplication AddSwagger(this WebApplication webApplication)
    {
        if (webApplication.Environment.IsDevelopment())
        {
            webApplication.UseSwagger();
            webApplication.UseSwaggerUI();
        }

        return webApplication;
    }

    internal static WebApplication RegisterWebApplicationServices(this WebApplication webApplication)
    {
        webApplication.UseHttpsRedirection();
        webApplication.UseAuthorization();
        webApplication.MapControllers();

        return webApplication;
    }

    internal static async Task StartWebAPIAsync(this WebApplication webApplication)
    {
        await webApplication.RunAsync();
    }
}