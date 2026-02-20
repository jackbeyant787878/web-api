using asp.net_core_8._0_web_api.DTOs;
using asp.net_core_8._0_web_api.Models;

namespace asp.net_core_8._0_web_api.Services;

public interface IWeatherService
{
    Task<IEnumerable<WeatherForecastDto>> GetWeatherForecastsAsync();
    Task<WeatherForecastDto> GetWeatherForecastByDateAsync(DateOnly date);
}