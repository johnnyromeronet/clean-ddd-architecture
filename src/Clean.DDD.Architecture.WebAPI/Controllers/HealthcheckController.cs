using System.Diagnostics.CodeAnalysis;
using Clean.DDD.Architecture.Domain.Contracts.Services;
using Clean.DDD.Architecture.WebAPI.Swagger.Examples;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Swashbuckle.AspNetCore.Filters;

namespace Clean.DDD.Architecture.WebAPI.Controllers
{
    [ApiController]
    [Route("healthcheck")]
    [ExcludeFromCodeCoverage]
    public class HealthcheckController(IHealthcheckService healthcheckService) : ControllerBase
    {
        private readonly IHealthcheckService _healthcheckService = healthcheckService;

        /// <summary>
        /// Gets the application's current system date.
        /// </summary>
        /// <returns>Current date in the format dd/MM/yyyy HH:mm:ss.fff</returns>
        /// <include file='swagger-tags.xml' path='swagger/tag[@name="health-check"]'/>
        [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(string))]
        [ProducesResponseType(StatusCodes.Status500InternalServerError, Type = typeof(string))]
        [ProducesResponseType(StatusCodes.Status503ServiceUnavailable, Type = typeof(string))]
        [SwaggerResponseExample(StatusCodes.Status200OK, typeof(HealthcheckModelExample))]
        [Produces("application/json")]
        [HttpGet]
        [AllowAnonymous]
        [Route("app")]
        public IActionResult GetAppStatus()
        {
            return Ok(DateTime.UtcNow.ToString("dd/MM/yyyy HH:mm:ss.fff"));
        }

        /// <summary>
        /// Gets the database's current system date.
        /// </summary>
        /// <returns>Current date in the format dd/MM/yyyy HH:mm:ss.fff</returns>
        /// <include file='swagger-tags.xml' path='swagger/tag[@name="health-check"]'/>
        [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(string))]
        [ProducesResponseType(StatusCodes.Status500InternalServerError, Type = typeof(string))]
        [ProducesResponseType(StatusCodes.Status503ServiceUnavailable, Type = typeof(string))]
        [SwaggerResponseExample(StatusCodes.Status200OK, typeof(HealthcheckModelExample))]
        [Produces("application/json")]
        [HttpGet]
        [AllowAnonymous]
        [Route("database")]
        public async Task<IActionResult> GetDatabaseStatus()
        {
            return Ok(await _healthcheckService.GetDatabaseStatus());
        }
    }
}
