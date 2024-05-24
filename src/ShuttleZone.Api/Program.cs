using Microsoft.AspNetCore.Identity;
using ShuttleZone.Api.DependencyInjection;
using ShuttleZone.Application.DependencyInjection;

var builder = WebApplication.CreateBuilder(args);
ApplicationEnvironment.SetEnvironment(builder.Environment.EnvironmentName);

// Add services to the container.
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddOdataControllers();
builder.Services.AddApplicationServices();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseRouting();
app.MapControllers();

app.Run();
