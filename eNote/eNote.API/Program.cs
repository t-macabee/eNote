using eNote.API.Middleware;
using eNote.API.Security;
using eNote.Model;
using eNote.Services.Configurations;
using eNote.Services.Database;
using eNote.Services.Interfaces;
using eNote.Services.Services;
using Mapster;
using Microsoft.AspNetCore.Authentication;
using Microsoft.EntityFrameworkCore;
using Microsoft.OpenApi.Models;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddTransient<IMusicShopService, MusicShopService>();
builder.Services.AddTransient<IInstrumentService, InstrumentService>();
builder.Services.AddTransient<IVrstaInstrumentaService, VrstaInstrumentaService>();
builder.Services.AddTransient<IKorisniciService, KorisniciService>();
builder.Services.AddTransient<IKursService, KursService>();

builder.Services.AddControllers();

builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen(x =>
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

var connectionString = builder.Configuration.GetConnectionString("ENoteConnection");
builder.Services.AddDbContext<ENoteContext>(options => options.UseSqlServer(connectionString));

builder.Services.AddAuthentication("BasicAuthentication").AddScheme<AuthenticationSchemeOptions, BasicAuthenticationHandler>("BasicAuthentication", options =>
{
    options.TimeProvider = TimeProvider.System;
});

builder.Services.AddHttpContextAccessor();

builder.Services.AddMapster();
MapsterConfig.RegisterMappings();

var app = builder.Build();

app.UseMiddleware<ExceptionHandlerMiddleware>();

if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthentication();

app.UseAuthorization();

app.MapControllers();

app.Run();
