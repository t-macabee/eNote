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
        public static IServiceCollection AddApplicationServices(this IServiceCollection services, IConfiguration configuration)
        {           
            services.AddDbContext<ENoteContext>(opt =>
            {
                opt.UseSqlServer(configuration.GetConnectionString("ENoteConnection"));
            });

            services.AddControllers();
            services.AddEndpointsApiExplorer();

            services.AddScoped<IAuthService, AuthService>();
            services.AddScoped<IInstrumentService, InstrumentService>();
            services.AddScoped<IKursService, KursService>();
            services.AddScoped<IKorisniciService, KorisniciService>();
            services.AddScoped<IMusicShopService, MusicShopService>();
            services.AddScoped<IUpisService, UpisService>();
            services.AddScoped<IPredavanjeService, PredavanjeService>();
            services.AddScoped<IObavijestService, ObavijestService>();

            services.AddMapster();
            MapsterConfig.RegisterMappings();
                   
            return services;
        }
    }
}




