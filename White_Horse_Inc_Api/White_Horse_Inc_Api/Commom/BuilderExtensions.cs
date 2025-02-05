using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.Tokens;
using System.Text;
using White_Horse_Inc_Api.Data;
using White_Horse_Inc_Api.Data.RepositoryMethods;
using White_Horse_Inc_Api.Implementations.Interfaces;
using White_Horse_Inc_Api.Implementations.Repositories;
using White_Horse_Inc_Core;
using White_Horse_Inc_Core.Interfaces;
using White_Horse_Inc_Core.Models;

namespace White_Horse_Inc_Api.Commom
{
    public static class BuilderExtension
    {
        public static void AddConfiguration(this WebApplicationBuilder builder)
        {
            //pega a connection string default
            Configuration.ConnectionString = builder.Configuration.GetConnectionString("DefaultConnection") ?? string.Empty;
            Configuration.FrontEndUrl = builder.Configuration.GetConnectionString("FrontEndUrl") ?? string.Empty;
            Configuration.BackEndUrl = builder.Configuration.GetConnectionString("BackEndUrl") ?? string.Empty;
            Configuration.JwtKey = builder.Configuration.GetConnectionString("JwtKey") ?? string.Empty;
        }

        public static void AddDocumentation(this WebApplicationBuilder builder)
        {
            //essa config do "n.FullName" serve para que o nosso swagger não se confunda
            //quando estiver lidando com entidades ou classes que estejam sendo recebidas
            //por parametro e que tem o mesmo nome

            builder.Services.AddControllers();
            builder.Services.AddEndpointsApiExplorer();
            builder.Services.AddInfrastructure();
        }

        public static void AddCrossOrigin(this WebApplicationBuilder builder)
        {
            builder.Services.AddCors(
                x => x.AddPolicy(
                    Configuration.CorsPolicyName,
                    policy => policy.WithOrigins([Configuration.FrontEndUrl, Configuration.BackEndUrl])// identificamos as urls permitidas
                    .AllowAnyHeader() // por meio delas aceitamos todo tipo de cabeçalho
                    .AllowAnyMethod() // por elas aceitamos todos os tipos de metodos http
                    .AllowCredentials() // por elas aceitamos metodos de credencial e autenticação
                )
            );
        }

        public static void AddDataBaseContext(this WebApplicationBuilder builder)
        {
            //cria o dbContext
            builder.Services.AddDbContext<AppDbContext>(x => x.UseSqlServer(Configuration.ConnectionString));
        }

        public static void AddEndpointInfrastructure(this WebApplicationBuilder builder)
        {
            var jwtKey = builder.Configuration["JwtKey"] ?? throw new InvalidOperationException("Chave JWT não configurada.");
            var appKey = Encoding.ASCII.GetBytes(jwtKey);

            // Configuração de autenticação com JWT
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


            builder.Services.AddAuthorization(options =>
            {
                options.AddPolicy("Swagger",
                    policy => policy.RequireAssertion(context =>
                        context.Resource?.ToString()?.Contains("/swagger") == true ||
                        context.Resource?.ToString()?.Contains("/swagger/v1/swagger.json") == true
                    )
                );
            });

            builder.Services.AddScoped<ICompanyRoleRepository, CompanyRoleRepository>();

        }
    }
}


