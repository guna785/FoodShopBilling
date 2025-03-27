using Asp.Versioning;
using FoodShopBilling.Api.Extensions;
using FoodShopBilling.Api.Filters;
using FoodShopBilling.Api.Managers.Preferences;
using FoodShopBilling.Api.Middlewares;
using Hangfire;
using Microsoft.Extensions.FileProviders;
using Microsoft.Extensions.Localization;
using FoodShopBilling.Application.Extensions;
using FoodShopBilling.Infrastructure.Extensions;
using Hangfire.MySql;
using System.Transactions;
using Newtonsoft.Json.Converters;
var builder = WebApplication.CreateBuilder(args);

builder.Host.UseSerilog();
//QuestPDF.Settings.License = LicenseType.Community;

// Add services to the container.
builder.Services.AddForwarding(builder.Configuration);
builder.Services.AddLocalization(options =>
{
    options.ResourcesPath = "Resources";
});
builder.Services.AddCurrentUserService();
builder.Services.AddSerialization();
builder.Services.AddServerOptions();
builder.Services.AddDatabase(builder.Configuration);
builder.Services.AddServerStorage(); //TODO - should implement ServerStorageProvider to work correctly!
builder.Services.AddScoped<ServerPreferenceManager>();
builder.Services.AddServerLocalization();
builder.Services.AddIdentity();
builder.Services.AddJwtAuthentication(builder.Services.GetApplicationSettings(builder.Configuration));
builder.Services.AddSignalR(options =>
{
    options.ClientTimeoutInterval = TimeSpan.FromSeconds(60);
    options.HandshakeTimeout = TimeSpan.FromSeconds(30);
});
builder.Services.AddApplicationLayer();
builder.Services.AddApplicationServices();
builder.Services.AddRepositories();
builder.Services.AddSharedInfrastructure(builder.Configuration);
#if DEBUG
builder.Services.RegisterSwagger();
#endif
builder.Services.InfrastructureMappings();
builder.Services.AddHangfire(x => x.UseStorage(new MySqlStorage(builder.Configuration.GetConnectionString("DefaultConnection"), new MySqlStorageOptions()
{
    TransactionIsolationLevel = IsolationLevel.ReadCommitted,
    QueuePollInterval = TimeSpan.FromSeconds(15),
    JobExpirationCheckInterval = TimeSpan.FromHours(1),
    CountersAggregateInterval = TimeSpan.FromMinutes(5),
    PrepareSchemaIfNecessary = true,
    DashboardJobListLimit = 50000,
    TransactionTimeout = TimeSpan.FromMinutes(1),
    TablesPrefix = "Hangfire"
})));
builder.Services.AddHangfireServer();
builder.Services.AddControllers().AddValidators().AddNewtonsoftJson(options =>
{
    options.SerializerSettings.Converters.Add(new StringEnumConverter());
    options.SerializerSettings.MaxDepth = int.MaxValue;
}); ;
builder.Services.AddRazorPages();
builder.Services.AddApiVersioning(config =>
{
    config.DefaultApiVersion = new ApiVersion(1, 0);
    config.AssumeDefaultVersionWhenUnspecified = true;
    config.ReportApiVersions = true;
});
builder.Services.AddLazyCache();
builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
#if DEBUG
builder.Services.AddSwaggerGen();
#endif
var app = builder.Build();
#if DEBUG
IStringLocalizer<Program> localizer;
using (var scope = app.Services.CreateScope())
{
    var services = scope.ServiceProvider;

    try
    {
        localizer = services.GetRequiredService<IStringLocalizer<Program>>();
    }
    catch (Exception ex)
    {
        var logger = scope.ServiceProvider.GetRequiredService<ILogger<Program>>();
        throw;
    }
}
#endif
// Configure the HTTP request pipeline.
app.UseForwarding(app.Configuration);
app.UseExceptionHandling(app.Environment);
//app.UseHttpsRedirection();
app.UseMiddleware<ErrorHandlerMiddleware>();
app.UseBlazorFrameworkFiles();
app.UseStaticFiles();
app.UseStaticFiles(new StaticFileOptions
{
    FileProvider = new PhysicalFileProvider(Path.Combine(Directory.GetCurrentDirectory(), @"Files")),
    RequestPath = new PathString("/Files")
});
app.UseRequestLocalizationByCulture();
app.UseRouting();
app.UseAuthentication();
app.UseAuthorization();
app.UseHangfireDashboard("/jobs", new DashboardOptions
{
    DashboardTitle = "Food Shopping Jobs",
    Authorization = new[] { new HangfireAuthorizationFilter() }
});
app.UseEndpoints();
#if DEBUG
app.ConfigureSwagger();
app.Initialize(app.Configuration);
#endif
app.MapControllers();

await app.RunAsync();