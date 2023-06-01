using Application.Interfaces;
using Application.Services;
using Infrastructure.Configuration;
using Infrastructure.Data.DbContexts;
using Infrastructure.Data.Interfaces;
using Infrastructure.Data.Repositories;
using Infrastructure.Services;
using Infrastructure.Services.Interfaces;

AppSettingsService appSettingsService = new AppSettingsService();
CORSSettings corsSettings = appSettingsService.GetCORSSettings();

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services.AddScoped<IAppSettingsService, AppSettingsService>();
builder.Services.AddScoped<LogisticsContext>();
builder.Services.AddScoped<IWarehouseRepository, WarehouseRepository>();
builder.Services.AddScoped<IWarehouseService, WarehouseService>();
builder.Services.AddScoped<IPortRepository, PortRepository>();
builder.Services.AddScoped<IPortService, PortService>();
builder.Services.AddScoped<IProductTypeRepository, ProductTypeRepository>();
builder.Services.AddScoped<IProductTypeService, ProductTypeService>();
builder.Services.AddScoped<IClientRepository, ClientRepository>();
builder.Services.AddScoped<IClientService, ClientService>();
builder.Services.AddScoped<ILandLogisticRepository, LandLogisticRepository>();
builder.Services.AddScoped<ILandLogisticService, LandLogisticService>();

builder.Services.AddCors(opt =>
{
    opt.AddPolicy(name: "CorsPolicy", builder =>
    {
        builder.WithOrigins(corsSettings.Origins)
            .AllowAnyHeader()
            .AllowAnyMethod()
            .AllowCredentials();
    });
});

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseCors("CorsPolicy");

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
