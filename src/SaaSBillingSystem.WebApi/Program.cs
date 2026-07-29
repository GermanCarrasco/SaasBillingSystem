using SaaSBillingSystem.WebApi.DependencyInjection;
using SaaSBillingSystem.WebApi.Extensions;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
// Learn more about configuring OpenAPI at https://aka.ms/aspnet/openapi
builder.Services.AddOpenApi();

builder.Services.AddPresentation(builder.Configuration);

var app = builder.Build();

app.UseSwaggerBasicAuthentication();

app.UseExceptionMiddleware();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    
    app.UseSwaggerUI(options =>
    {
        options.SwaggerEndpoint("/swagger/v1/swagger.json", "SaaS Billing API v1");
        options.RoutePrefix = "swagger";
        options.DocumentTitle = "SaaS Billing API";
    });

}


app.UseAuthorization();

app.MapControllers();

app.Run();


