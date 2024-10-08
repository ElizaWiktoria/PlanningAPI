using Planning.Application.Middleware;
using PlanningApi.Startup;
using Serilog;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
ServiceRegistration.Register(builder.Services);

builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services.AddCors(options =>
{
    options.AddPolicy("DevCors", corsBuilder =>
    {
        corsBuilder.WithOrigins("http://localhost:3000")
                    .AllowAnyMethod()
                    .AllowAnyHeader()
                    .AllowCredentials();
    });
    options.AddPolicy("ProdCors", corsBuilder =>
    {
        corsBuilder.WithOrigins("")
                    .AllowAnyMethod()
                    .AllowAnyHeader()
                    .AllowCredentials();
    });
});

// Configure Serilog
Log.Logger = new LoggerConfiguration()
    .ReadFrom.Configuration(builder.Configuration)
    .Enrich.FromLogContext()
    .CreateLogger();

builder.Logging.ClearProviders(); // Clear default logging providers
builder.Logging.AddSerilog(); // Add Serilog to logging pipeline

var app = builder.Build();

app.UseMiddleware<RequestLoggingMiddleware>();


// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseCors("DevCors");
    app.UseSwagger();
    app.UseSwaggerUI();
}
else
{
    app.UseCors("");
    app.UseHttpsRedirection();
}

//app.UseHttpLogging();

app.UseHttpsRedirection();

app.UseExceptionHandler(_ => { });

app.UseAuthorization();

app.MapControllers();

app.Run();