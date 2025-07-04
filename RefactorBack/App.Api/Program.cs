using App.Api.Common;
using App.Domain;

//---------------------------Builder----------------------------//

var builder = WebApplication.CreateBuilder(args);

builder.AddConfiguration();

builder.AddIntegration();

builder.AddDocumentation();

builder.AddCrossOrigin();

builder.AddEndpointInfrastructure();

//----------------------------App-------------------------------//

var app = builder.Build();

app.AddAppSecurity();

if (app.Environment.IsDevelopment())
    app.AddSwaggerDevExtensions();

app.UseCors(Configuration.CorsPolicyName);

app.AddAppInfrastructure();

app.Run();

