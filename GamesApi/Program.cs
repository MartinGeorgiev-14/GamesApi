using Microsoft.EntityFrameworkCore;
using GamesAPI.Data;
using Microsoft.Extensions.Options;
using GamesAPI.Web;
using GamesAPI.Services.Games.IService;
using GamesAPI.Services.Games.Service;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();



builder.Services
    .AddSqlServer<ApplicationDbContext>(builder.Configuration.GetConnectionString("DefaultConnection"));

builder.Services.AddTransient<IGamesService, GamesService>();
builder.Services.AddTransient<IGamesPlatformMTMService, GamesPlatformMTMService>();
builder.Services.AddTransient<IGenreService, GenreService>();
builder.Services.AddTransient<IPlatformService, PlatformService>();
builder.Services.AddTransient<IPublisherService, PublisherService>();
builder.Services.AddTransient<IYearService, YearService>();

builder.Services.AddAutoMapper(typeof(MappingProfile).Assembly);



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
