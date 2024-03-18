using ProviderOne.ApplicationServices.Interfaces;

namespace ProviderOne.ApplicationServices.Implementation
{
    public class HealthCheckService : IHealthCheckService
    {
        private readonly int MaxAccessibilityThreshold = 5;

        public bool Ping()
        {
            Random random = new Random();
            int value = random.Next(10);

            return value < MaxAccessibilityThreshold;
        }
    }
}
