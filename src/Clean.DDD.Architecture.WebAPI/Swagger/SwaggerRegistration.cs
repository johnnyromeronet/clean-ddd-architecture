using System.Diagnostics.CodeAnalysis;
using System.Reflection;
using Clean.DDD.Architecture.Infrastructure.Registration;
using MicroElements.Swashbuckle.FluentValidation.AspNetCore;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.OpenApi.Models;
using Swashbuckle.AspNetCore.Filters;

namespace Clean.DDD.Architecture.WebAPI.Swagger
{
    [ExcludeFromCodeCoverage]
    public static class SwaggerRegistration
    {
        public static IServiceCollection AddSwaggerServices(this IServiceCollection services)
        {
            var enabled = Convert.ToBoolean(ConfigManager.SwaggerEnabled);
            if (enabled)
            {
                services.AddEndpointsApiExplorer();
                services.AddSwaggerGen(opts =>
                {
                    opts.SwaggerDoc("v1", new()
                    {
                        Version = "v1",
                        Title = ConfigManager.WebAPIName,
                        Description = @"
## API Consumption Guide

The following section provides a detailed description of how to consume each of the endpoints that make up the **Clean.DDD.Architecture** API.  
All requests must include the following headers:

- **Authorization**
    - Basic *{base64(user:password)}*. Only for `POST /token`
    - Bearer *{jwt_token}*

- **x-timezone** *{timezone}*. For example: `Europe/Madrid`
"
                    });

                    opts.EnableAnnotations();
                    opts.AddSecurityDefinition("Bearer", new()
                    {
                        Description = "JWT authorization header using the Bearer scheme. Example: \"Autorization: Bearer {jwt_token}\"",
                        Name = "Authorization",
                        In = ParameterLocation.Header,
                        Type = SecuritySchemeType.ApiKey,
                        Scheme = JwtBearerDefaults.AuthenticationScheme
                    });

                    opts.AddSecurityDefinition("Basic", new()
                    {
                        Description = "Basic authentication using a username and password. Example: \"Authorization: Basic {base64(user:password)}\"",
                        Name = "Authorization",
                        In = ParameterLocation.Header,
                        Type = SecuritySchemeType.Http,
                        Scheme = "Basic"
                    });

                    opts.AddSecurityRequirement(new()
                    {
                        {
                            new OpenApiSecurityScheme
                            {
                                Reference = new()
                                {
                                    Id = JwtBearerDefaults.AuthenticationScheme,
                                    Type = ReferenceType.SecurityScheme
                                }
                            },
                            Array.Empty<string>()
                        },
                        {
                            new OpenApiSecurityScheme
                            {
                                Reference = new OpenApiReference
                                {
                                    Id = "Basic",
                                    Type = ReferenceType.SecurityScheme
                                }
                            },
                            Array.Empty<string>()
                        }
                    });

                    opts.TagActionsBy(endpoint =>
                    {
                        return [endpoint.RelativePath!.Split('/')[0]];
                    });

                    var xmlFile = $"{Assembly.GetExecutingAssembly().GetName().Name}.xml";
                    opts.IncludeXmlComments(Path.Combine(AppContext.BaseDirectory, xmlFile));
                    opts.ExampleFilters();
                });

                services.AddSwaggerExamplesFromAssemblies(Assembly.GetExecutingAssembly());
                services.AddFluentValidationRulesToSwagger();
            }

            return services;
        }
    }
}
