using WebAPI.Application;

var builder = WebApplication.CreateBuilder(args);

builder.AddServices();

var app = builder.Build();

await app
    .AddSwagger()
    .RegisterWebApplicationServices()
    .StartWebAPIAsync();