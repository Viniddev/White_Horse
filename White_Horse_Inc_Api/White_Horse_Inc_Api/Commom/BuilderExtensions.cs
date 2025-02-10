using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.Tokens;
using System.Text;
using White_Horse_Inc_Api.Data;
using White_Horse_Inc_Api.Implementations.Repository.Interfaces;
using White_Horse_Inc_Api.Implementations.Repository.Repositories;
using White_Horse_Inc_Api.Implementations.Services;
using White_Horse_Inc_Core;

namespace White_Horse_Inc_Api.Commom
{
    public static class BuilderExtension
    {
        public static void AddConfiguration(this WebApplicationBuilder builder)
        {
            //pega a connection string default
            Configuration.ConnectionString = builder.Configuration.GetConnectionString("DefaultConnection") ?? string.Empty;
            Configuration.FrontEndUrl = builder.Configuration["FrontEndUrl"]?? string.Empty;
            Configuration.BackEndUrl = builder.Configuration["BackEndUrl"] ?? string.Empty;
            Configuration.JwtKey = builder.Configuration["JwtKey"] ?? string.Empty;
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
            builder.Services.AddDbContext<AppDbContext>(x => 
                        x.UseSqlServer(Configuration.ConnectionString)
                        .UseLazyLoadingProxies());
        }

        public static void AddEndpointInfrastructure(this WebApplicationBuilder builder)
        {
            var appKey = Encoding.ASCII.GetBytes(Configuration.JwtKey);

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
        }

        public static void AddMethodsInfrastructure(this WebApplicationBuilder builder) 
        {
            builder.Services.AddTransient<ICompanyRoleRepository, CompanyRoleRepository>();
            builder.Services.AddTransient<IUserAddressRepository, UserAddressRepository>();
            builder.Services.AddTransient<IUserInformationsRepository, UserInformationsRepository>();

            builder.Services.AddScoped<IAuthenticationService, AuthenticationService>();
        }
    }
}


