using Microsoft.AspNetCore.HttpOverrides;
using Microsoft.AspNetCore.ResponseCompression;
using Microsoft.EntityFrameworkCore.Diagnostics;
using Ogu.AspNetCore.Compressions;
using OpenSettings.Api;
using OpenSettings.AspNetCore.Extensions;
using OpenSettings.Configurations;
using OpenSettings.Extensions;
using OpenSettings.Models;

var builder = WebApplication.CreateBuilder(args);

const string slash = "/";
const string settingsSpaRelativePath = "/settings";

var configuration = builder.Configuration
    .AddEnvironmentVariables("OPENSETTINGS_") // OPENSETTINGS_Configuration__DbProviderName=InMemory - OPENSETTINGS_Configuration__ConnectionString=OpenSettings
    .Build();

var openSettingsConfiguration = configuration.GetSection("Configuration").Get<OpenSettingsConfiguration>();

openSettingsConfiguration.Provider.LicenseKey = builder.Configuration["Configuration:LicenseKey"];
openSettingsConfiguration.Selection = ServiceType.Provider;

var dbResolver = DbResolver.Resolve(configuration);

openSettingsConfiguration.Provider.Orm.ConfigureDbContext = optsBuilder =>
{
    dbResolver.UseDb(optsBuilder);
    optsBuilder.ConfigureWarnings(w => w.Ignore(RelationalEventId.PendingModelChangesWarning));
};

await builder.Host.UseOpenSettingsAsync(openSettingsConfiguration);

builder.Services.Configure<BrotliCompressionProviderOptions>(opts => opts.Level = openSettingsConfiguration.Provider.CompressionLevel);
builder.Services.Configure<ZstdCompressionProviderOptions>(opts => { });
builder.Services.Configure<GzipCompressionProviderOptions>(opts => opts.Level = openSettingsConfiguration.Provider.CompressionLevel);
builder.Services.Configure<DeflateCompressionProviderOptions>(opts => { });

builder.Services.AddResponseCompression(opts =>
{
    opts.Providers.Add<BrotliCompressionProvider>();
    opts.Providers.Add<ZstdCompressionProvider>();
    opts.Providers.Add<GzipCompressionProvider>();
    opts.Providers.Add<SnappyCompressionProvider>();
    opts.Providers.Add<DeflateCompressionProvider>();

    opts.MimeTypes = ResponseCompressionDefaults.MimeTypes;

    opts.EnableForHttps = true;
});

builder.Services
    .AddControllers()
    .AddOpenSettingsController(builder.Configuration); // Enables OpenSettings Controllers

builder.Services.Configure<ForwardedHeadersOptions>(options =>
{
    options.ForwardedHeaders = ForwardedHeaders.XForwardedFor | ForwardedHeaders.XForwardedProto;
});

var app = builder.Build();

app.UseForwardedHeaders();
app.UseRouting();
app.Use(async (context, next) =>
{
    await next();

    if (context.Request.Path == slash)
    {
        context.Response.Redirect(settingsSpaRelativePath);
    }
});
app.UseResponseCompression();
app.UseOpenSettings(); // Updates instance status when the application is starting or stopping.
app.UseAuthentication();
app.UseAuthorization();
app.MapControllers();

await app.RunAsync();