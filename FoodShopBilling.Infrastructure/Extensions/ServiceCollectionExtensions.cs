using FoodShopBilling.Infrastructure.Repositories;
using FoodShopBilling.Infrastructure.Services.Storage;
using FoodShopBilling.Infrastructure.Services.Storage.Provider;
using Microsoft.Extensions.DependencyInjection;
using FoodShopBilling.Application.Interfaces.Repositories;
using FoodShopBilling.Application.Interfaces.Services.Storage;
using FoodShopBilling.Application.Interfaces.Services.Storage.Provider;
using System.Reflection;
using FoodShopBilling.Utilities.Serialization.Options;
using FoodShopBilling.Utilities.Interfaces.Serialization.Serializers;
using FoodShopBilling.Utilities.Serialization.Serializers;
using FoodShopBilling.Utilities.Serialization.JsonConverters;

namespace FoodShopBilling.Infrastructure.Extensions
{
    public static class ServiceCollectionExtensions
    {
        public static void InfrastructureMappings(this IServiceCollection services)
        {
            _ = services.AddAutoMapper(Assembly.GetExecutingAssembly());
        }

        public static IServiceCollection AddRepositories(this IServiceCollection services)
        {
            return services
            .AddTransient(typeof(IRepositoryAsync<,>), typeof(RepositoryAsync<,>))
            .AddTransient(typeof(IDapperRepository), typeof(DapperRepository))
                .AddTransient(typeof(IUnitOfWork<>), typeof(UnitOfWork<>));
        }


        public static IServiceCollection AddServerStorage(this IServiceCollection services)
        {
            return AddServerStorage(services, null!);
        }

        public static IServiceCollection AddServerStorage(this IServiceCollection services, Action<SystemTextJsonOptions> configure)
        {
            return services
                .AddScoped<IJsonSerializer, SystemTextJsonSerializer>()
                .AddScoped<IStorageProvider, ServerStorageProvider>()
                .AddScoped<IServerStorageService, ServerStorageService>()
                .AddScoped<ISyncServerStorageService, ServerStorageService>()
                .Configure<SystemTextJsonOptions>(configureOptions =>
                {
                    configure?.Invoke(configureOptions);
                    if (!configureOptions.JsonSerializerOptions.Converters.Any(c => c.GetType() == typeof(TimespanJsonConverter)))
                    {
                        configureOptions.JsonSerializerOptions.Converters.Add(new TimespanJsonConverter());
                    }
                });
        }
    }
}
