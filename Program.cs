using asp.net_core_8._0_web_api.Middlewares;
using asp.net_core_8._0_web_api.Services;
var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

// Register services
builder.Services.AddScoped<IWeatherService, WeatherService>();
builder.Services.AddScoped<IDatabaseTestService, DatabaseTestService>();

var app = builder.Build();

app.UseSwagger();
app.UseSwaggerUI();


// Add middlewares
app.UseMiddleware<ExceptionHandlerMiddleware>();
app.UseMiddleware<RequestLoggingMiddleware>();

app.UseAuthorization();
app.MapControllers();

app.Run();
