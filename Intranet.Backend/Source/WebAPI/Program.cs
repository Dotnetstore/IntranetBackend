using WebAPI.Application;

var builder = WebApplication.CreateBuilder(args);

builder.AddServices();

var app = builder.Build();

app
    .AddSwagger()
    .RegisterWebApplicationServices();
    
await app.StartWebAPI();