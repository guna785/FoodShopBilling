using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Components.Authorization;
using Microsoft.AspNetCore.Components.WebAssembly.Hosting;
using Microsoft.AspNetCore.Http.Features;
using FoodShopBilling.Shared.Constants.Permission;
using FoodShopBilling.UI.Shared.Authentication;
using FoodShopBilling.UI.Shared.Managers.Preferences;
using FoodShopBilling.UI.Shared.Managers;
using FoodShopBilling.UI.Shared.Storage;
using System.Globalization;
using System.Reflection;
using Toolbelt.Blazor.Extensions.DependencyInjection;
using FoodShopBilling.UI.Web.Services;

namespace FoodShopBilling.UI.Web.Extensions
{
    public static class ClientServiceExtentions
    {
        private const string ClientName = "SmartBilling.API";

       
        public static WebApplicationBuilder AddClientServices(this WebApplicationBuilder builder)
        {
            builder
                .Services
                .AddLocalization(options =>
                {
                    options.ResourcesPath = "Resources";
                })
                .AddAuthorizationCore(options =>
                {
                    RegisterPermissionClaims(options);
                })
            //.AddBlazoredLocalStorage()
                
                .AddScoped<IClientSessionSecureStorage, ClientSessionSecureStorage>()
                .Configure<FormOptions>(o =>
                {
                    o.ValueLengthLimit = int.MaxValue;
                    o.MultipartBodyLengthLimit = int.MaxValue;
                    o.MultipartBoundaryLengthLimit = int.MaxValue;
                    o.MultipartHeadersCountLimit = int.MaxValue;
                    o.MultipartHeadersLengthLimit = int.MaxValue;
                    o.BufferBodyLengthLimit = int.MaxValue;
                    o.BufferBody = true;
                    o.ValueCountLimit = int.MaxValue;
                })
                .AddAutoMapper(AppDomain.CurrentDomain.GetAssemblies())
                .AddScoped<ClientPreferenceManager>()
                .AddScoped<BillingAppServerStateProvider>()
                .AddScoped<AuthenticationStateProvider, BillingAppServerStateProvider>()
                .AddAuthorizationCore()
                .AddManagers()
                // .AddExtendedAttributeManagers()
                .AddTransient<AuthenticationHeaderHandler>()
               .AddScoped(sp => sp
                    .GetRequiredService<IHttpClientFactory>()
                    .CreateClient(ClientName).EnableIntercept(sp))
                .AddHttpClient(ClientName, client =>
                {
                    client.DefaultRequestHeaders.AcceptLanguage.Clear();
                    client.DefaultRequestHeaders.AcceptLanguage.ParseAdd(CultureInfo.DefaultThreadCurrentCulture?.TwoLetterISOLanguageName);
                    client.BaseAddress = new Uri(builder.Configuration["BaseAddress"]!);
                });
            //builder.Services.AddMudServicesWithExtensions();
            builder.Services.AddHttpClientInterceptor();
            return builder;
        }

        public static IServiceCollection AddManagers(this IServiceCollection services)
        {
            var managers = typeof(IManager);

            var types = managers
                .Assembly
                .GetExportedTypes()
                .Where(t => t.IsClass && !t.IsAbstract)
                .Select(t => new
                {
                    Service = t.GetInterface($"I{t.Name}"),
                    Implementation = t
                })
                .Where(t => t.Service != null);

            foreach (var type in types)
            {
                if (managers.IsAssignableFrom(type.Service))
                {
                    services.AddTransient(type.Service, type.Implementation);
                }
            }

            return services;
        }

        //public static IServiceCollection AddExtendedAttributeManagers(this IServiceCollection services)
        //{
        //    //TODO - add managers with reflection!

        //    return services
        //        .AddTransient(typeof(IExtendedAttributeManager<int, int, Document, DocumentExtendedAttribute>), typeof(ExtendedAttributeManager<int, int, Document, DocumentExtendedAttribute>));
        //}

        private static void RegisterPermissionClaims(AuthorizationOptions options)
        {
            foreach (var prop in typeof(Permissions).GetNestedTypes().SelectMany(c => c.GetFields(BindingFlags.Public | BindingFlags.Static | BindingFlags.FlattenHierarchy)))
            {
                var propertyValue = prop.GetValue(null);
                if (propertyValue is not null)
                {
                    options.AddPolicy(propertyValue.ToString(), policy => policy.RequireClaim(ApplicationClaimTypes.Permission, propertyValue.ToString()));
                }
            }
        }
    }
}
