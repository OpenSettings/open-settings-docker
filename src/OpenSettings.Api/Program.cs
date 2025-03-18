using Microsoft.EntityFrameworkCore;
using OpenSettings.AspNetCore;
using OpenSettings.Configurations;
using OpenSettings.Extensions;
using OpenSettings.Models;

var builder = WebApplication.CreateBuilder(args);

var openSettingsProviderConfiguration = new OpenSettingsConfiguration(ServiceType.Provider)
{
    Client = new ClientInfo(
        new Guid("adbdf741-bb4d-4673-b2a8-23e677fcf454"), // The unique identifier for the client. 
        new Guid("4294a5e3-0839-4358-a03d-1ac52585ae5f")) // The secret key for the client.
};

var migrationsAssembly = typeof(Program).Assembly.GetName().Name;

openSettingsProviderConfiguration.Provider.Orm.ConfigureDbContext = optsBuilder =>
{
    // Configure your database provider here. (e.g. UseSqlServer, UseNpgsql, UseInMemoryDatabase)
    //optsBuilder.UseInMemoryDatabase("OpenSettings");
    optsBuilder.UseSqlServer(
        "Data Source=(localdb)\\MSSQLLocalDB;Initial Catalog=OpenSettings;Integrated Security=True;MultipleActiveResultSets=True",
        opts => opts.MigrationsAssembly(migrationsAssembly));
};

await builder.Host.UseOpenSettingsAsync(openSettingsProviderConfiguration);

builder.Services
    .AddControllers()
    .AddOpenSettingsController(builder.Configuration); // Enables OpenSettings Controllers

var app = builder.Build();

app.UseRouting();
app.UseOpenSettings(); // Updates instance status when the application is starting or stopping.
app.UseOpenSettingsSpa();
app.MapControllers();

await app.RunAsync();