
using ShuttleZone.DAL.Common.Implementations;
using ShuttleZone.DAL.Common.Interfaces;
using ShuttleZone.DAL.Repositories.Court;
using ShuttleZone.Infrastructure.Data;
using ShuttleZone.Infrastructure.Data.Interfaces;
using ShuttleZone.Infrastructure.Helpers;
using MaintainCourtService = ShuttleZone.Grpc.Services.MaintainCourtService;

var builder = WebApplication.CreateBuilder(args);
DataAccessHelper.Initialize(builder.Configuration);
// Add services to the container.
builder.Services.AddGrpc();
builder.Services.AddScoped<IUnitOfWork, UnitOfWork>();
builder.Services.AddScoped<IApplicationDbContext, ApplicationDbContext>();
builder.Services.AddScoped<IReadOnlyApplicationDbContext, ApplicationDbContext>();
builder.Services.AddScoped<ICourtRepository, CourtRepository>();
var app = builder.Build();
app.MapGrpcService<MaintainCourtService>();
// Configure the HTTP request pipeline.
app.MapGet("/", () => "Communication with gRPC endpoints must be made through a gRPC client. To learn how to create a client, visit: https://go.microsoft.com/fwlink/?linkid=2086909");

app.Run();
