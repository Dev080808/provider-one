using ProviderOne.Site.Extensions;

using SystemAggregator.Site;

namespace ProviderOne.Site
{
    public class Program
    {
        public static void Main(string[] args)
        {
            ApiWebApplication.Run(ConfigureBuilder, ConfigureApplication, addApiVersioning: true);
        }

        private static void ConfigureBuilder(WebApplicationBuilder builder)
        {
            //  Entities
            builder.Host.AddDomainServices();

            // Infrastructure.Implementation
            builder.Host.AddDataAccessInMemory();

            // Application Services
            builder.Host.AddApplicationServices();

            // Use cases
            builder.Host.AddUseCases();

            // Controllers
            builder.Services.AddControllers();
        }

        private static void ConfigureApplication(WebApplication app)
        {
            app.UseHttpsRedirection();
        }
    }
}