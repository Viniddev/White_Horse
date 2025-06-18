using App.Api.Common;
using App.Domain;

var builder = WebApplication.CreateBuilder(args);

builder.AddConfiguration();

builder.AddIntegration();

builder.AddDocumentation();

builder.AddCrossOrigin();

builder.AddEndpointInfrastructure();

//--------------------------------------------------------------//

var app = builder.Build();

app.AddAppSecurity();

if (app.Environment.IsDevelopment())
    app.AddSwaggerDevExtensions();

app.UseCors(Configuration.CorsPolicyName);

app.AddAppInfrastructure();

app.Run();

