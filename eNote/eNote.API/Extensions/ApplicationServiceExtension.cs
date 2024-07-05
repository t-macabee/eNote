using eNote.API.Filters;
using eNote.API.Security;
using eNote.Services.Configurations;
using eNote.Services.Database;
using eNote.Services.Interfaces;
using eNote.Services.Services;
using Mapster;
using Microsoft.AspNetCore.Authentication;
using Microsoft.EntityFrameworkCore;
using Microsoft.OpenApi.Models;

namespace eNote.API.Extensions
{
    public static class ApplicationServiceExtension
    {
        public static IServiceCollection AddApplicationServices(this IServiceCollection services, IConfiguration config)
        {
            services.AddDbContext<eNoteContext>(options =>
                options.UseSqlServer(config.GetConnectionString("DefaultConnection")));

            services.AddAuthentication("BasicAuthentication")
                .AddScheme<AuthenticationSchemeOptions, BasicAuthenticationHandler>("BasicAuthentication", null);

            services.AddSwaggerGen(x =>
            {
                x.AddSecurityDefinition("basicAuth", new OpenApiSecurityScheme
                {
                    Type = SecuritySchemeType.Http,
                    Scheme = "basic"
                });

                x.AddSecurityRequirement(new OpenApiSecurityRequirement
                {
                    {
                        new OpenApiSecurityScheme
                        {
                            Reference = new OpenApiReference
                            {
                                Type = ReferenceType.SecurityScheme,
                                Id = "basicAuth"
                            }
                        },
                        new string[] { }
                    }
                });
            });

            services.AddControllers(x =>
            {
                x.Filters.Add<ExceptionHandler>();
            });

            services.AddTransient<IMusicShopService, MusicShopService>();
            services.AddTransient<IInstrumentService, InstrumentService>();
            services.AddTransient<IVrstaInstrumentaService, VrstaInstrumentaService>();
            services.AddTransient<IKorisniciService, KorisniciService>();

            services.AddMapster();
            MapsterConfig.RegisterMappings();

            return services;
        }
    }
}

