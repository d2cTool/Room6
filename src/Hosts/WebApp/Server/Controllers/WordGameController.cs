using Microsoft.AspNetCore.Mvc;
using WebApp.Shared;

namespace WebApp.Server.Controllers
{
    [ApiController]
    [Route("game")]
    public class WordGameController : ControllerBase
    {
        private readonly ILogger<WordGameController> _logger;

        public WordGameController(ILogger<WordGameController> logger)
        {
            _logger = logger;
        }

        //[HttpGet("rooms")]
        //public IEnumerable<WeatherForecast> Get()
        //{
            
        //}

        //[HttpPost("rooms")]
        //public IEnumerable<WeatherForecast> Add()
        //{
            
        //}
    }
}
