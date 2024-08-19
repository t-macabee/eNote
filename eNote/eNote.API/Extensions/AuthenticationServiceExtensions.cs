using eNote.API.Authentication;
using Microsoft.AspNetCore.Authentication;
using Microsoft.OpenApi.Models;

namespace eNote.API.Extensions
{
    public static class AuthenticationServiceExtensions
    {
        public static IServiceCollection AddAuthenticationServices(this IServiceCollection services, IConfiguration configuration)
        {
            services.AddSwaggerGen(x =>
            {
                x.AddSecurityDefinition("basicAuth", new OpenApiSecurityScheme()
                {
                    Type = SecuritySchemeType.Http,
                    Scheme = "basic",
                    In = ParameterLocation.Header,
                    Name = "Authorization",
                    Description = "Basic Authentication header using the Basic scheme."
                });
                x.AddSecurityRequirement(new OpenApiSecurityRequirement
                {
                    {
                        new OpenApiSecurityScheme
                        {
                            Reference = new OpenApiReference { Type = ReferenceType.SecurityScheme, Id = "basicAuth" }
                        }, new List<string>()
                    }
                });
            });

            services.AddAuthentication("BasicAuthentication").AddScheme<AuthenticationSchemeOptions, BasicAuthenticationHandler>("BasicAuthentication", options =>
            {
                options.TimeProvider = TimeProvider.System;
            });

            return services;
        }
    }
}
