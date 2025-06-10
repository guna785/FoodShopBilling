using Asp.Versioning;
using Hangfire;
using Microsoft.Extensions.FileProviders;
using Microsoft.Extensions.Localization;
using FoodShopBilling.Application.Extensions;
using FoodShopBilling.Infrastructure.Extensions;
using Hangfire.MySql;
using System.Transactions;
using Newtonsoft.Json.Converters;
using FoodShopBilling.UI.Shared.Services;
using FoodShopBilling.UI.Web.Services;
using FoodShopBilling.UI.Web.Extensions;
using FoodShopBilling.UI.Web.Managers.Preferences;
using FoodShopBilling.UI.Web.Components;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddRazorComponents()
    .AddInteractiveServerComponents();

// Add device-specific services used by the FoodShopBilling.UI.Shared project
builder.Services.AddSingleton<IFormFactor, FormFactor>();
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

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Error", createScopeForErrors: true);
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseHsts();
}

app.UseHttpsRedirection();

app.UseStaticFiles();
app.UseAntiforgery();

app.MapRazorComponents<App>()
    .AddInteractiveServerRenderMode()
    .AddAdditionalAssemblies(typeof(FoodShopBilling.UI.Shared._Imports).Assembly);

await app.RunAsync();
