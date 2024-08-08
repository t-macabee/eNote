using eNote.Services.Configurations;
using eNote.Services.Database;
using eNote.Services.Interfaces;
using eNote.Services.Services;
using Mapster;
using Microsoft.EntityFrameworkCore;
using System.Text.Json.Serialization;

namespace eNote.API.Extensions
{
    public static class ApplicationServiceExtensions
    {
        public static IServiceCollection AddApplicationServices(this IServiceCollection services, IConfiguration configuration)
        {           
            services.AddDbContext<ENoteContext>(opt =>
            {
                opt.UseSqlServer(configuration.GetConnectionString("ENoteConnection"));
            });

            services.AddControllers().AddJsonOptions(options =>
            {
                options.JsonSerializerOptions.DefaultIgnoreCondition = JsonIgnoreCondition.WhenWritingNull;
            });

            services.AddEndpointsApiExplorer();

            services.AddScoped<IAuthService, AuthService>();
            services.AddScoped<IInstrumentService, InstrumentService>();
            services.AddScoped<IVrstaInstrumentaService, VrstaInstrumentaService>();
            services.AddScoped<IKursService, KursService>();
            services.AddScoped<IMusicShopService, MusicShopService>();
            services.AddScoped<IKorisniciService, KorisniciService>();

            services.AddMapster();
            MapsterConfig.RegisterMappings();
                   
            return services;
        }
    }
}




