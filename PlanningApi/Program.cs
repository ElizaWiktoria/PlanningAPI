using PlanningApi.Startup;

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

var app = builder.Build();

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

app.UseHttpsRedirection();

app.UseExceptionHandler(_ => { });

app.UseAuthorization();

app.MapControllers();

app.Run();