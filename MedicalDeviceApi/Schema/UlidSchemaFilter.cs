using Microsoft.OpenApi.Any;
using Microsoft.OpenApi.Models;
using Swashbuckle.AspNetCore.SwaggerGen;
using System;

namespace MedicalDevice.Schema
{
    public class UlidSchemaFilter : ISchemaFilter
    {
        public void Apply(OpenApiSchema schema, SchemaFilterContext context)
        {
            if (context.Type == typeof(Ulid))
            {
                schema.Type = "string";
                schema.Format = "Ulid";
                schema.Example = new OpenApiString(Ulid.Empty.ToString());
            }
        }
    }
}