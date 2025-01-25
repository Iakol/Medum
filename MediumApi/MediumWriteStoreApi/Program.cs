using MediumWriteStoreApi.Middleware;
using MediumWriteStoreApi.Service.AzureService;
using MediumWriteStoreApi.Service.LinkService;
using MediumWriteStoreApi.Service.RabitMQProducerService;
using MediumWriteStoreApi.Service.WebSocetServise;
using MediumWriteStoreApi.Service.WebSocketDictionaryService;
using StackExchange.Redis;
using System.Net.WebSockets;


var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

// Add services to the container.

builder.Services.AddControllers();

builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen(options =>
{
    options.SwaggerDoc("v1", new Microsoft.OpenApi.Models.OpenApiInfo
    {
        Title = "My API",
        Version = "v1",
        Description = "API Documentation"
    });
});
builder.Services.AddSingleton<IConnectionMultiplexer>(sp => ConnectionMultiplexer.Connect(builder.Configuration.GetConnectionString("Redis")));
builder.Services.AddSingleton<IRabitMQProducer, RabitMQProducer>();
builder.Services.AddSingleton<WebSocketMessageHandler>();
builder.Services.AddSingleton<IWebSocketDictionaryService, WebSocketDictionaryService>();

builder.Services.AddScoped<ILinkService, LinkService>();
builder.Services.AddScoped<IAzureService, AzureService>();






// Learn more about configuring OpenAPI at https://aka.ms/aspnet/openapi
builder.Services.AddOpenApi();

builder.Services.AddCors(options =>
{
    options.AddPolicy("AllowAll", policy =>
    {
        policy.AllowAnyOrigin()
              .AllowAnyHeader()
              .AllowAnyMethod();
    });
});

var app = builder.Build();

app.UseWebSockets(new WebSocketOptions 
{
    KeepAliveInterval = TimeSpan.FromMinutes(2),
    KeepAliveTimeout = TimeSpan.FromSeconds(30),
});

app.UseMiddleware<WebSocketMiddleware>();


// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.MapOpenApi();
}

app.UseHttpsRedirection();
app.UseCors("AllowAll");


if (app.Environment.IsDevelopment() || app.Environment.IsProduction())
{
    app.UseSwagger();
    app.UseSwaggerUI(options =>
    {
        options.SwaggerEndpoint("/swagger/v1/swagger.json", "My API v1");
        options.RoutePrefix = string.Empty;
    });
}

app.UseAuthorization();

app.MapControllers();

app.Run();
