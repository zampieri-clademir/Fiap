using Microsoft.OpenApi.Models;

using TechChallenge_1.API.Filters.Swaggers;

using System.Diagnostics.CodeAnalysis;
using System.Reflection;

namespace TechChallenge_1.API.Extensions
{
    [ExcludeFromCodeCoverage]
    public static class SwaggerExtensions
    {
        public static void AddSwagger(this IServiceCollection services)
        {
            // Registra o Swagger para documentar a API
            services.AddSwaggerGen(c =>
            {
                c.SwaggerDoc("v1", new OpenApiInfo
                {
                    Version = "v1",
                    Title = "API TechChallenge 1",
                    Description = "API TechChallenge 1"
                });

                c.AddSecurityDefinition("Bearer", new OpenApiSecurityScheme
                {
                    Description = "JWT Authorization header using the Bearer scheme. Example: \"Authorization: Bearer {token}\"",
                    Name = "Authorization",
                    In = ParameterLocation.Header,
                    Type = SecuritySchemeType.ApiKey,
                    Scheme = "Bearer"
                });

                c.AddSecurityRequirement(new OpenApiSecurityRequirement()
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
                            In = ParameterLocation.Header,
                        },
                        new List<string>()
                    }
                });

                // Adiciona os comentários da API no Swagger JSON da UI.
                var xmlFile = $"{Assembly.GetExecutingAssembly().GetName().Name}.xml";
                var xmlPath = Path.Combine(AppContext.BaseDirectory, xmlFile);
                c.IncludeXmlComments(xmlPath);

                c.CustomSchemaIds(x => x.Name);

                c.SchemaFilter<SwaggerSkipPropertyFilter>();
            });
        }

        public static void ConfigSwagger(this IApplicationBuilder app)
        {
            // Habilita o Middleware do Swagger.
            app.UseSwagger();

            //Configura o Swagger JSON endpoint.
            app.UseSwaggerUI(c =>
            {
                c.SwaggerEndpoint($"/swagger/v1/swagger.json", "API Tech Challenge 1");
                c.DefaultModelsExpandDepth(-1);
                c.RoutePrefix = string.Empty;
            });
        }
    }

}
