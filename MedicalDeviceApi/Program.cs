using System.Text.Json.Serialization;
using Cysharp.Serialization.Json;
using MedicalDevice.Database;
using MedicalDevice.Schema;
using MedicalDevice.Services;
using Microsoft.EntityFrameworkCore;
using Microsoft.OpenApi.Models;

var builder = WebApplication.CreateSlimBuilder(args);

// Add services to the container.
builder.Services
    .AddDbContext<DatabaseContext>(o => o.UseInMemoryDatabase(nameof(DatabaseContext)))
    .AddTransient<SessionService>();

// Add controllers to the container.
builder.Services
    .AddControllers()
    .AddJsonOptions(options =>
    {
        options.JsonSerializerOptions.Converters.Add(new UlidJsonConverter());
        options.JsonSerializerOptions.Converters.Add(new JsonStringEnumConverter());
    });

// Add a Cors policy for development
builder.Services.AddCors(options =>
{
    options.AddPolicy("DevelopmentCorsPolicy", corsPolicyBuilder
        => corsPolicyBuilder
        .AllowAnyOrigin()
        .AllowAnyMethod()
        .AllowAnyHeader());
});

// Register the Swagger generator
builder.Services.AddSwaggerGen(c =>
{
    c.MapType<Ulid>(() => new OpenApiSchema
    {
        Type = "string",
        Format = "ulid"
    });
    c.CustomOperationIds(apiDesc => apiDesc.ActionDescriptor.RouteValues["action"]);
    c.SchemaFilter<UlidSchemaFilter>();
    c.SwaggerDoc("v0", new OpenApiInfo { Title = "Medical Device", Version = "v0" });
});

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    // Use Cors
    app.UseCors("DevelopmentCorsPolicy");

    // Enable middleware to serve generated Swagger as a JSON endpoint.
    app.UseSwagger();

    // Enable middleware to serve swagger-ui (HTML, JS, CSS, etc.),
    // specifying the Swagger JSON endpoint.
    app.UseSwaggerUI(c =>
    {
        c.SwaggerEndpoint("/swagger/v0/swagger.json", "Medical Device MVP");
        c.RoutePrefix = string.Empty; // Set Swagger UI at the app's root
    });
}

app.MapControllers();

app.Run();