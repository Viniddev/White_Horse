using App.Domain;
using App.Application;
using App.Infrastructure.Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.Tokens;
using System.Text;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using App.Infrastructure;

namespace App.Api.Common;

public static class BuilderExtensions
{
    public static void AddConfiguration(this WebApplicationBuilder builder)
    {
        //pega a connection string default
        Configuration.ConnectionString = builder.Configuration.GetConnectionString("DefaultConnection") ?? string.Empty;
        Configuration.FrontEndUrl = builder.Configuration["FrontEndUrl"] ?? string.Empty;
        Configuration.BackEndUrl = builder.Configuration["BackEndUrl"] ?? string.Empty;
        Configuration.JwtKey = builder.Configuration["JwtKey"] ?? string.Empty;
    }

    public static void AddIntegration(this WebApplicationBuilder builder)
    {
        builder.Services.AddInfrastructure();
        builder.Services.AddApplication();

        builder.Services.AddDbContext<AppDbContext>(x =>
        {
            x.UseLazyLoadingProxies().UseSqlServer(
                builder.Configuration.GetConnectionString("DefaultConnection"),
                x => x.MigrationsAssembly("App.Infrastructure")
            );
        });
    }

    public static void AddDocumentation(this WebApplicationBuilder builder)
    {
        builder.Services.AddControllers();
        builder.Services.AddEndpointsApiExplorer();
        builder.Services.AddInfrastructureSwagger();
    }

    public static void AddCrossOrigin(this WebApplicationBuilder builder)
    {
        builder.Services.AddCors(
            x => x.AddPolicy(
                Configuration.CorsPolicyName,
                policy => policy.WithOrigins([Configuration.FrontEndUrl, Configuration.BackEndUrl])
                .AllowAnyHeader() 
                .AllowAnyMethod() 
                .AllowCredentials()
            )
        );
    }

    public static void AddEndpointInfrastructure(this WebApplicationBuilder builder)
    {
        var appKey = Encoding.ASCII.GetBytes(Configuration.JwtKey);

        builder.Services.AddAuthentication(options =>
        {
            options.DefaultScheme = JwtBearerDefaults.AuthenticationScheme;
            options.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;
        })
        .AddJwtBearer(options =>
        {
            options.RequireHttpsMetadata = false;
            options.SaveToken = true;
            options.TokenValidationParameters = new TokenValidationParameters
            {
                ValidateIssuerSigningKey = true,
                IssuerSigningKey = new SymmetricSecurityKey(appKey),
                ValidateIssuer = true,
                ValidateAudience = true,
                ValidIssuer = builder.Configuration["Jwt:Issuer"],
                ValidAudience = builder.Configuration["Jwt:Audience"]
            };
        });
    }
}
