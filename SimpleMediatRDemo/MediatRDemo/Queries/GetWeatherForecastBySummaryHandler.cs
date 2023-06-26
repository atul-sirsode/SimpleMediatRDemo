using MediatR;

namespace MediatRDemo.Queries
{
    public class GetWeatherForecastBySummaryHandler : IRequestHandler<GetWeatherForecastBySummary, WeatherForecast>
    {
        private static readonly string[] Summaries = {
            "Freezing", "Bracing", "Chilly", "Cool", "Mild", "Warm", "Balmy", "Hot", "Sweltering", "Scorching"
        };
        public async Task<WeatherForecast> Handle(GetWeatherForecastBySummary request, CancellationToken cancellationToken)
        {
            var first = Enumerable.Range(1, 5)
                .Select(index => new WeatherForecast
                {
                    Date = DateTime.Now.AddDays(index),
                    TemperatureC = Random.Shared.Next(-20, 55),
                    Summary = Summaries.FirstOrDefault(x => x == request.Summary)
                })
                .ToArray().FirstOrDefault();
            if (first is null)
                throw new Exception("No weather forecast found");
            return await Task.FromResult(first);
        }
    }
}
