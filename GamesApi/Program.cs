using Microsoft.EntityFrameworkCore;
using GamesAPI.Data;
using Microsoft.Extensions.Options;
using GamesAPI.Web;
using GamesAPI.Services.Games.IService;
using GamesAPI.Services.Games.Service;
using GamesAPI.Data.RolesModels;
using System.Text;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.IdentityModel.Tokens;
using GamesAPI.Services.Authorization;
using Microsoft.Net.Http.Headers;
using Microsoft.OpenApi.Models;
using Swashbuckle.AspNetCore.Filters;
using GamesAPI.Services.Seeding;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();



builder.Services
    .AddSqlServer<ApplicationDbContext>(builder.Configuration.GetConnectionString("DefaultConnection"))
    .AddIdentity<ApplicationUser, ApplicationRole>()
    .AddEntityFrameworkStores<ApplicationDbContext>();

var key = Encoding.UTF8.GetBytes(builder.Configuration["JWTSecret"]);

builder.Services
    .AddAuthentication(x =>
    {
        x.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
        x.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;
        x.DefaultScheme = JwtBearerDefaults.AuthenticationScheme;
    })
    .AddJwtBearer(x =>
    {
        x.RequireHttpsMetadata = false;
        x.SaveToken = false;
        x.TokenValidationParameters = new TokenValidationParameters
        {
            ValidateIssuerSigningKey = true,
            IssuerSigningKey = new SymmetricSecurityKey(key),
            ValidateIssuer = false,
            ValidateAudience = false,
            ClockSkew = TimeSpan.Zero
        };
    });

builder.Services.AddSwaggerGen(options =>
{
    const string name = "Bearer token";

    options.AddSecurityDefinition(name, new OpenApiSecurityScheme
    {
        Description = "Standard Authorization header using the Bearer scheme. Example: \"Bearer {token}\"",
        In = ParameterLocation.Header,
        Name = HeaderNames.Authorization,
        Type = SecuritySchemeType.Http,
        Scheme = "bearer",
        BearerFormat = "JWT",
    });

    options.OperationFilter<SecurityRequirementsOperationFilter>(true, name);
});


builder.Services.AddTransient<IGamesService, GamesService>();
builder.Services.AddTransient<IGenreService, GenreService>();
builder.Services.AddTransient<IPlatformService, PlatformService>();
builder.Services.AddTransient<IPublisherService, PublisherService>();
builder.Services.AddTransient<IRoleSeeder, RoleSeeder>();
builder.Services.AddTransient<IAuthorizationService, AuthorizationService>();
builder.Services.AddTransient<IGamesCSVSeeder, GamesCSVSeeder>();



builder.Services.AddAutoMapper(typeof(MappingProfile).Assembly);

var app = builder.Build();


using (var scope = app.Services.CreateScope())
{
    var gameSeeder = scope.ServiceProvider.GetRequiredService<IGamesCSVSeeder>();

    await gameSeeder.SeedAsync();

    var roleSeeder = scope.ServiceProvider.GetRequiredService<IRoleSeeder>();

    await roleSeeder.SeedAsync();
}
    // Configure the HTTP request pipeline.
    if (app.Environment.IsDevelopment())
    {
        app.UseSwagger();
        app.UseSwaggerUI();
    }

app.UseHttpsRedirection();

app.UseAuthentication();

app.UseAuthorization();

app.MapControllers();

app.Run();
