using Asp.Versioning;
using Blazored.SessionStorage;
using DataTables.AspNet.AspNetCore;
using FoodShopBilling.Application.Extensions;
using FoodShopBilling.Infrastructure.Extensions;
using FoodShopBilling.UI.Shared.Services;
using FoodShopBilling.UI.Web.Components;
using FoodShopBilling.UI.Web.Extensions;
using FoodShopBilling.UI.Web.Filters;
using FoodShopBilling.UI.Web.Managers.Preferences;
using FoodShopBilling.UI.Web.Middlewares;
using FoodShopBilling.UI.Web.Services;
using Hangfire;
using Hangfire.MySql;
using Microsoft.AspNetCore.Authorization;
using Microsoft.Extensions.FileProviders;
using Microsoft.Extensions.Localization;
using Microsoft.FluentUI.AspNetCore.Components;
using Newtonsoft.Json.Converters;
using System.Transactions;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddRazorComponents()
    .AddInteractiveServerComponents();
builder.Services.AddFluentUIComponents(options =>
{
    options.ValidateClassNames = false;
});

builder.Services.AddBlazoredSessionStorage();
// Add device-specific services used by the FoodShopBilling.UI.Shared project
builder.Services.AddSingleton<IFormFactor, FormFactor>();
builder.Host.UseSerilog();
// Add services to the container.
builder.Services.AddForwarding(builder.Configuration);
builder.Services.AddLocalization(options =>
{
    options.ResourcesPath = "Resources";
});

builder.Services.AddDatabase(builder.Configuration);
builder.Services.AddCurrentUserService();
builder.Services.AddSerialization();
builder.Services.AddServerStorage(); //TODO - should implement ServerStorageProvider to work correctly!
builder.Services.AddScoped<ServerPreferenceManager>();
builder.Services.AddServerLocalization();
builder.Services.AddIdentity();
builder.Services.AddJwtAuthentication(builder.Services.GetApplicationSettings(builder.Configuration));
//builder.Services.AddCokieAuthentication();
builder.Services.AddSignalR();
builder.Services.AddApplicationLayer();
builder.Services.AddApplicationServices();
builder.Services.AddRepositories();

builder.Services.AddSharedInfrastructure(builder.Configuration);
builder.Services.RegisterSwagger();
builder.Services.InfrastructureMappings();
builder.Services.AddControllers().AddValidators();
builder.Services.AddRazorPages();
builder.Services.AddApiVersioning(config =>
{
    config.DefaultApiVersion = new ApiVersion(1, 0);
    config.AssumeDefaultVersionWhenUnspecified = true;
    config.ReportApiVersions = true;
});
builder.Services.RegisterDataTables();
builder.AddClientServices();
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
// Add services to the container.
builder.Services.AddControllersWithViews().AddNewtonsoftJson(options =>
{
    options.SerializerSettings.Converters.Add(new StringEnumConverter());
});

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
IStringLocalizer<Program> localizer;
using (var scope = app.Services.CreateScope())
{
    var services = scope.ServiceProvider;

    try
    {
        //var context = services.GetRequiredService<ApplicationDbContext>();

        //if (context.Database.IsSqlServer())
        //{
        //    context.Database.Migrate();
        //}
        localizer = services.GetRequiredService<IStringLocalizer<Program>>();

    }
    catch (Exception ex)
    {
        var logger = scope.ServiceProvider.GetRequiredService<ILogger<Program>>();

        logger.LogError(ex, "An error occurred while migrating or seeding the database.");

        throw;
    }
}


// Configure the HTTP request pipeline.
app.UseForwarding(app.Configuration);
app.UseExceptionHandling(app.Environment);
app.UseHttpsRedirection();
app.UseMiddleware<ErrorHandlerMiddleware>();
app.UseStaticFiles();
app.UseStaticFiles(new StaticFileOptions
{
    FileProvider = new PhysicalFileProvider(Path.Combine(Directory.GetCurrentDirectory(), @"Files")),
    RequestPath = new PathString("/Files")
});
app.UseRequestLocalizationByCulture();
app.UseRouting();
app.UseAuthentication();

IAuthorizationService authservice = (IAuthorizationService)app.Services.GetRequiredService(typeof(IAuthorizationService));
app.UseHangfireDashboard("/jobs", new DashboardOptions
{
    AppPath = null,
    DarkModeEnabled = false,
    FaviconPath = "/logoupdated.png",
    DashboardTitle = localizer["Smart Billing App"],
    //TimeZoneResolver = new DefaultTimeZoneResolver(),
    Authorization = new[] { new HangfireAuthorizationFilter() }
});
app.Initialize(app.Configuration);
app.MapControllers();


// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Home/Error");
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseHsts();
}
else
{
    app.UseDeveloperExceptionPage();
}
app.UseHttpsRedirection();
app.UseStaticFiles();

app.UseRouting();
app.UseAuthorization();
app.ConfigureSwagger();
app.UseAntiforgery();

await app.RunAsync();
