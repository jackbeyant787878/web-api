using asp.net_core_8._0_web_api.DTOs;
using asp.net_core_8._0_web_api.Models;

namespace asp.net_core_8._0_web_api.Services;

public class WeatherService : IWeatherService
{
    private static readonly string[] Summaries = new[]
    {
        "Freezing", "Bracing", "Chilly", "Cool", "Mild", "Warm", "Balmy", "Hot", "Sweltering", "Scorching"
    };

    public async Task<IEnumerable<WeatherForecastDto>> GetWeatherForecastsAsync()
    {
        var forecasts = Enumerable.Range(1, 5).Select(index =>
            new WeatherForecast
            {
                Date = DateOnly.FromDateTime(DateTime.Now.AddDays(index)),
                TemperatureC = Random.Shared.Next(-20, 55),
                Summary = Summaries[Random.Shared.Next(Summaries.Length)]
            })
            .ToList();

        return forecasts.Select(f => new WeatherForecastDto
        {
            Date = f.Date,
            TemperatureC = f.TemperatureC,
            Summary = f.Summary,
            TemperatureF = f.TemperatureF
        });
    }

    public async Task<WeatherForecastDto> GetWeatherForecastByDateAsync(DateOnly date)
    {
        var forecast = new WeatherForecast
        {
            Date = date,
            TemperatureC = Random.Shared.Next(-20, 55),
            Summary = Summaries[Random.Shared.Next(Summaries.Length)]
        };

        return new WeatherForecastDto
        {
            Date = forecast.Date,
            TemperatureC = forecast.TemperatureC,
            Summary = forecast.Summary,
            TemperatureF = forecast.TemperatureF
        };
    }
}