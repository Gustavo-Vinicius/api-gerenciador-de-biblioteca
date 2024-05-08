using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Threading.Tasks;
using Microsoft.OpenApi.Models;

namespace gerenciador_de_biblioteca.API.Configuration
{
    public static class SwaggerConfiguration
    {
        public static void AddSwaggerConfiguration(this IServiceCollection services)
        {
            services.AddSwaggerGen(c =>
            {
                var filePath = Path.Combine(AppContext.BaseDirectory, "gerenciador-de-biblioteca.API.xml");
                c.IncludeXmlComments(filePath);
                
                var currentAssembly = Assembly.GetExecutingAssembly();
                var xmlDocs = currentAssembly
                    .GetReferencedAssemblies()
                    .Union(new AssemblyName[] { currentAssembly.GetName() })
                    .Select(a =>
                        Path.Combine(
                            Path.GetDirectoryName(currentAssembly.Location),
                            $"{a.Name}.xml"
                        )
                    )
                    .Where(f => System.IO.File.Exists(f))
                    .ToArray();

                Array.ForEach(xmlDocs, (d) => c.IncludeXmlComments(d));

                c.SwaggerDoc("v1",
                    new OpenApiInfo
                    {
                        Title = "Gerenciador de Biblioteca - V1",
                        Version = "v1"
                    }
                 );

                c.AddSecurityDefinition("Bearer", new OpenApiSecurityScheme
                {
                    Name = "Token",
                    Type = SecuritySchemeType.ApiKey,
                    Scheme = "Bearer",
                    BearerFormat = "JWT",
                    In = ParameterLocation.Header,
                    Description = "JWT Authorization header usando o esquema Bearer"
                });

                c.AddSecurityRequirement(new OpenApiSecurityRequirement
                {
        {
            new OpenApiSecurityScheme
            {
                Reference = new OpenApiReference
                {
                    Type = ReferenceType.SecurityScheme,
                    Id = "Bearer"
                }
            },
            new string [] {}
        }
                });
                c.IncludeXmlComments(filePath);
            });

        }

    }
}