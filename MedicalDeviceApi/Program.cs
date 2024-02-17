using MedicalDevice.Domain;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Options;
using Microsoft.OpenApi.Models;
using System.Text.Json.Serialization;

var builder = WebApplication.CreateSlimBuilder(args);

// Add services to the container.
builder.Services
    .AddDbContext<DomainContext>(o => o.UseInMemoryDatabase(nameof(DomainContext)));

// Add controllers to the container.
builder.Services
    .AddControllers();

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