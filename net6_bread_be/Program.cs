using Microsoft.EntityFrameworkCore;
using net6_bread_be;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

//CountryTrackerContext
builder.Services.AddDbContext<CountryTrackerContext>(options =>
    options.UseNpgsql(builder.Configuration.GetConnectionString("BreadDbConnection"))
        .UseSnakeCaseNamingConvention());

//BreadTrackerContext
builder.Services.AddDbContext<BreadTrackerContext>(options =>
    options.UseNpgsql(builder.Configuration.GetConnectionString("BreadDbConnection"))
           .UseSnakeCaseNamingConvention());

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();

