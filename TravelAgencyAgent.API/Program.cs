using Microsoft.OpenApi;
using TravelAgencyAgent.API.Extensions;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen(c =>
{
    c.SwaggerDoc("v1", new OpenApiInfo
    {
        Title = "TravelAgency API",
        Version = "v1"
    });
});
builder.Services.AddServiceExtensions();

var app = builder.Build();

if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI(c =>
    {
        c.SwaggerEndpoint("/swagger/v1/swagger.json", "TravelAgency API v1");
    });
}

app.UseHttpsRedirection();

app.MapControllers();

app.Run();
