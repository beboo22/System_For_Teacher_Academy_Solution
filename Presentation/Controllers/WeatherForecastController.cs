using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;

namespace System_For_Teacher_Academy.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class WeatherForecastController : ControllerBase
    {
        private static readonly string[] Summaries = new[]
        {
            "Freezing", "Bracing", "Chilly", "Cool", "Mild", "Warm", "Balmy", "Hot", "Sweltering", "Scorching"
        };

        private readonly ILogger<WeatherForecastController> _logger;

        public WeatherForecastController(ILogger<WeatherForecastController> logger)
        {
            _logger = logger;
        }

        //test
        [HttpGet(Name = "GetWeatherForecast")]
        public IActionResult Get()
        {
            return Ok("test");
        }
    }
}
