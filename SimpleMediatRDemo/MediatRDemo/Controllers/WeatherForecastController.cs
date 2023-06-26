using MediatR;
using MediatRDemo.Commands;
using MediatRDemo.Notifications;
using MediatRDemo.Queries;
using Microsoft.AspNetCore.Mvc;

namespace MediatRDemo.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class WeatherForecastController : ControllerBase
    {
        private readonly IMediator _mediator;
        private readonly ILogger<WeatherForecastController> _logger;
        
        public WeatherForecastController(ILogger<WeatherForecastController> logger, IMediator mediator)
        {
            _logger = logger;
            _mediator = mediator;
        }

        [HttpGet(Name = "GetWeatherForecast")]
        public async Task<IActionResult> Get()
        {
            var result = await _mediator.Send(new WeatherForecastCommand());
            _logger.LogInformation("Weather forecast retrieved successfully");

            await _mediator.Publish(new Email
            {
                To = "mediatrdemo@demo.com",
                From = "dummy@gmail.com",
                Body = "Weather forecast new send to mediatr successfully"
            });

            return Ok(result);
           
        }
        [HttpGet("GetWeatherForecastBySummary/{summary}")]
        public async Task<IActionResult> Get(string summary)
        {
            var result = await _mediator.Send(new GetWeatherForecastBySummary{Summary = summary});
            _logger.LogInformation("Weather forecast retrieved successfully");

            await _mediator.Publish(new Email
            {
                To = "mediatrdemo@demo.com",
                From = "dummy@gmail.com",
                Body = "Weather forecast new send to mediatr successfully"
            });

            return Ok(result);

        }
    }
}