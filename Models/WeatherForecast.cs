namespace asp.net_core_8._0_web_api.Models;

public record WeatherForecast
{
    public DateOnly Date { get; init; }
    public int TemperatureC { get; init; }
    public string? Summary { get; init; }
    
    public int TemperatureF => 32 + (int)(TemperatureC / 0.5556);
}