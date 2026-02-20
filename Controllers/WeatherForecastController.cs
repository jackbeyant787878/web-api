using asp.net_core_8._0_web_api.DTOs;
using asp.net_core_8._0_web_api.Services;
using Microsoft.AspNetCore.Mvc;

namespace asp.net_core_8._0_web_api.Controllers;

[ApiController]
[Route("[controller]")]
public class WeatherForecastController : ControllerBase
{
    private readonly IWeatherService _weatherService;
    private readonly ILogger<WeatherForecastController> _logger;

    public WeatherForecastController(IWeatherService weatherService, ILogger<WeatherForecastController> logger)
    {
        _weatherService = weatherService;
        _logger = logger;
    }

    [HttpGet]
    public async Task<ActionResult<IEnumerable<WeatherForecastDto>>> Get()
    {
        _logger.LogInformation("Getting weather forecasts");
        var forecasts = await _weatherService.GetWeatherForecastsAsync();
        return Ok(forecasts);
    }

    [HttpGet("{date}")]
    public async Task<ActionResult<WeatherForecastDto>> GetByDate(DateOnly date)
    {
        _logger.LogInformation($"Getting weather forecast for date: {date}");
        var forecast = await _weatherService.GetWeatherForecastByDateAsync(date);
        return Ok(forecast);
    }
}