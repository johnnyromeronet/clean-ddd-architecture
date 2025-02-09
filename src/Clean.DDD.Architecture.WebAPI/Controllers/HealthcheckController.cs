using Clean.DDD.Architecture.Domain.Contracts.Services;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace Clean.DDD.Architecture.WebAPI.Controllers
{
    [ApiController]
    [Route("healthcheck")]
    public class HealthcheckController(IHealthcheckService healthcheckService) : ControllerBase
    {
        private readonly IHealthcheckService _healthcheckService = healthcheckService;

        [Produces("application/json")]
        [HttpGet]
        [AllowAnonymous]
        [Route("app")]
        public IActionResult GetAppStatus()
        {
            return Ok(DateTime.UtcNow.ToString("dd/MM/yyyy HH:mm:ss.fff"));
        }

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
