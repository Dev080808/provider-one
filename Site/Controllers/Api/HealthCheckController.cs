using Asp.Versioning;

using Microsoft.AspNetCore.Mvc;

using ProviderOne.ApplicationServices.Interfaces;

using Swashbuckle.AspNetCore.Annotations;

using SystemAggregator.Site.Exceptions;

namespace ProviderOne.Site.Controllers.Api
{
    [ApiController]
    [ApiVersion("1.0")]
    [Route("api/v{version:apiVersion}")]
    [SwaggerTag("HealthCheck API")]
    public class HealthCheckController : ControllerBase
    {
        private readonly IHealthCheckService _healthCheckService;

        public HealthCheckController(IHealthCheckService healthCheckService)
        {
            _healthCheckService = healthCheckService;
        }

        [HttpGet]
        [Route("ping")]
        public IActionResult Ping()
        {
            var isAvailable = _healthCheckService.Ping();

            if (!isAvailable)
            {
                return ExceptionGenerator.GetServiceUnavailableResult();
            }

            return Ok();
        }
    }
}
