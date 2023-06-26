using MediatR;

namespace MediatRDemo.Queries
{
    public class GetWeatherForecastBySummary : IRequest<WeatherForecast>
    {
        public string Summary { get; set; }
    }
}
