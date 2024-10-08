using AmnPardazJabari.Application.Contracts.TodoLists;
using AmnPardazJabari.Application.TodoLists;
using AmnPardazJabari.BackgroundServices;
using AmnPardazJabari.DI;
using AmnPardazJabari.Domain.CustomMapping;
using AmnPardazJabari.Infrastructure;
using Autofac;
using Autofac.Extensions.DependencyInjection;
using Microsoft.OpenApi.Models;
using Swashbuckle.AspNetCore.SwaggerGen;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddScoped<ITodoListHostedService, TodoListHostedService>();
builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddHttpClient();
builder.Services.AddSwaggerGen();
builder.Services.AddHttpContextAccessor();
builder.Services.InitializeAutoMapper();
builder.Services.AddOptions<SwaggerGenOptions>().Configure(swagger =>
{
    // var swaggerDocOptions = new SwaggerDocumentOptions();
    // configuration.GetSection(nameof(SwaggerDocumentOptions)).Bind(swaggerDocOptions);
    swagger.AddSecurityDefinition("Bearer", new OpenApiSecurityScheme
    {
        Description = "JWT Authorization header using the Bearer scheme.",
        Name = "Authorization",
        In = ParameterLocation.Header,
        Type = SecuritySchemeType.ApiKey,
        Scheme = "Bearer"
    });

    swagger.AddSecurityRequirement(new OpenApiSecurityRequirement
    {
        {
            new OpenApiSecurityScheme
            {
                Reference = new OpenApiReference
                {
                    Type = ReferenceType.SecurityScheme,
                    Id = "Bearer"
                },
                Scheme = "oauth2",
                Name = "Bearer",
                In = ParameterLocation.Header
            },
            new List<string>()
        }
    });
});
builder.Services.AddInfrastructure();
builder.Host.UseServiceProviderFactory(new AutofacServiceProviderFactory());

builder.Host.ConfigureContainer<ContainerBuilder>(
    containerBuilder => containerBuilder.RegisterModule(new AutofacModule()));

builder.Services.AddHostedService<NotifyTodoListHostedService>();
var app = builder.Build();
app.InitializeDatabase();
// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseAuthorization();

app.MapControllers();

app.Run();
