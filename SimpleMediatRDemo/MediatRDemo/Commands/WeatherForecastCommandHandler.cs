using MediatR;

namespace MediatRDemo.Commands
{
    public class WeatherForecastCommandHandler : IRequestHandler<WeatherForecastCommand, WeatherForecast>
    {
        private static readonly string[] Summaries = new[]
        {
            "Freezing", "Bracing", "Chilly", "Cool", "Mild", "Warm", "Balmy", "Hot", "Sweltering", "Scorching"
        };
        public async Task<WeatherForecast> Handle(WeatherForecastCommand request, CancellationToken cancellationToken)
        {
            var first = Enumerable.Range(1, 5).Select(index => new WeatherForecast
            {
                Date = DateTime.Now.AddDays(index),
                TemperatureC = Random.Shared.Next(-20, 55),
                Summary = Summaries[Random.Shared.Next(Summaries.Length)]
            })
                .ToArray()
                .FirstOrDefault();
            if (first is null)
                throw new Exception("No weather forecast found");
            return await Task.FromResult(first);
        }
    }
}
