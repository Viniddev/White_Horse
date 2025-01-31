namespace White_Horse_Inc_Api.Commom.Api
{
    public static class AppExtensions
    {
        public static void AddSwaggerDevExtensions(this WebApplication app)
        {
            //adiciona extensões pro swagger em ambiente de dev
            app.UseSwagger();
            app.UseSwaggerUI();
        }

        public static void AddAppSecurity(this WebApplication app)
        {
            //necessariamente passar nessa ordem para que o app compreenda
            //authenticação e os perfis necessarios 
            app.UseAuthentication();
            app.UseAuthorization();
        }

        public static void AddAppInfrastructure(this WebApplication app)
        {
            //mapeamento para endpoints e identificação do versionamento do app

            app.MapControllers();

            app.MapGet("/", () => "Hello World!");
        }
    }
}
