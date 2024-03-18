using Microsoft.EntityFrameworkCore;

using ProviderOne.ApplicationServices.Implementation;
using ProviderOne.ApplicationServices.Interfaces;
using ProviderOne.DataAccess.InMemory;
using ProviderOne.DataAccess.InMemory.Repositories;
using ProviderOne.DataAccess.Interfaces;
using ProviderOne.UseCases.Services;

using SystemAggregator.Clients.ProviderOne;
using SystemAggregator.Services;

namespace ProviderOne.Site.Extensions
{
    public static class HostBuilderExtensions
    {
        public static void AddDataAccessInMemory(this IHostBuilder builder)
        {
            builder.ConfigureServices((context, services) =>
            {
                var connectionString = context.Configuration.GetConnectionString("ProviderOneDb");

                services.AddDbContext<ProviderOneDbContext>(
                    options => options.UseInMemoryDatabase(connectionString));

                services.AddTransient<IRouteRepository, RouteRepository>();
            });
        }

        public static void AddDomainServices(this IHostBuilder builder)
        {
            builder.ConfigureServices(services =>
            {
            });
        }

        public static void AddApplicationServices(this IHostBuilder builder)
        {
            builder.ConfigureServices(services =>
            {
                services.AddTransient<IHealthCheckService, HealthCheckService>();
            });
        }

        public static void AddUseCases(this IHostBuilder builder)
        {
            builder.AddProviderOneClient();

            builder.ConfigureServices((context, services) =>
            {
                services.AddTransient(GetSearchService);
                services.AddTransient<ISearchService, RouteSearchService>();
            });
        }

        private static Func<string, ISearchService?> GetSearchService(IServiceProvider services)
        {
            return searchCode => services.GetServices<ISearchService>().FirstOrDefault(x => x.SearchCode == searchCode);
        }
    }
}
