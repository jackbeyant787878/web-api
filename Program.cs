using asp.net_core_8._0_web_api.Configurations;
using asp.net_core_8._0_web_api.Middlewares;
using asp.net_core_8._0_web_api.Services;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();


// Configure MySQL database
//builder.Services.AddDbContext<AppDbContext>(options =>
//    options.UseMySQL(builder.Configuration.GetConnectionString("DefaultConnection")));

// Register services
builder.Services.AddScoped<IWeatherService, WeatherService>();
//builder.Services.AddScoped<IUserService, UserService>();
builder.Services.AddScoped<IDatabaseTestService, DatabaseTestService>();


var app = builder.Build();

// Configure the HTTP request pipeline.
//if (app.Environment.IsDevelopment())
//{
//    app.UseSwagger();
//    app.UseSwaggerUI();
//}

app.UseSwagger();
app.UseSwaggerUI();


// Add middlewares
app.UseMiddleware<ExceptionHandlerMiddleware>();
app.UseMiddleware<RequestLoggingMiddleware>();

app.UseAuthorization();
app.MapControllers();

app.Run();
