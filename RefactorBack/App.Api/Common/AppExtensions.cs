using App.Api.Controllers.V1;

namespace App.Api.Common;

public static class AppExtensions
{
    public static void AddSwaggerDevExtensions(this WebApplication app)
    {
        app.UseSwagger();

        app.UseSwaggerUI(c =>
        {
            c.SwaggerEndpoint("/swagger/v1/swagger.json", "White Horse v1");
            c.RoutePrefix = string.Empty;
        });
    }

    public static void AddAppSecurity(this WebApplication app)
    {
        app.UseAuthentication();
        app.UseAuthorization();
    }

    public static void AddAppInfrastructure(this WebApplication app)
    {
        app.MapAuthenticationEndpoints();
        app.MapUsersEndpoints();
        app.MapUserAddressEndpoints();
        app.MapPostsEndpoints();
    }
}
