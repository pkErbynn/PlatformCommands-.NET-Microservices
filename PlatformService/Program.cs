using Microsoft.EntityFrameworkCore;
using PlatformService.Data;
using PlatformService.Repository;
using PlatformService.SyncDataServices.Http;
using Microsoft.Extensions.Configuration;
using PlatformService.AsyncDataServices;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

//builder.Services.AddDbContext<AppDbContext>(options => 
//    options.UseInMemoryDatabase("InMem"));
builder.Services.AddAutoMapper(AppDomain.CurrentDomain.GetAssemblies());
builder.Services.AddHttpClient<ICommandDataClient, HttpCommandDataClient>();
builder.Services.AddScoped<IPlatformRepo, PlatformRepo>();
builder.Services.AddSingleton<IMessageBusClient, MessageBusClient>();

Console.WriteLine($"--> CommandService Endpoint {builder.Configuration["CommandService"]}");

if (builder.Environment.IsDevelopment())
{
    Console.WriteLine("--> Using InMem DB");
    builder.Services.AddDbContext<AppDbContext>(options =>
        options.UseInMemoryDatabase("InMem"));
}
else
{
    if (builder.Environment.IsProduction())
    {
        Console.WriteLine("--> Using SqlServer Db");
        builder.Services.AddDbContext<AppDbContext>(opt =>
            opt.UseSqlServer(builder.Configuration.GetConnectionString("PlatformsConn")));  // GetConnectionString() matches "ConnectionStrings" key
    }
}

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

//app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

PrepDb.PrepPopulation(app);

app.Run();
