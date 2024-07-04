using eNote.Services.Configurations;
using eNote.Services.Database;
using eNote.Services.Interfaces;
using eNote.Services.Services;
using Mapster;
using Microsoft.EntityFrameworkCore;

namespace eNote.API.Extensions
{
    public static class ApplicationServiceExtensions
    {
        public static IServiceCollection AddApplicationServices(this IServiceCollection services, IConfiguration config)
        {            
            services.AddDbContext<eNoteContext>(options => options.UseSqlServer(config.GetConnectionString("DefaultConnection")));

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

