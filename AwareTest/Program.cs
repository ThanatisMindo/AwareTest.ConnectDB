using AwareTest.Controllers;
using AwareTest.Data.IRepository;
using AwareTest.Data.Repository;
using AwareTest.Model.Model;
using AwareTest.Services.IService;
using AwareTest.Services.Services;
using AwareTest.Services.Services.Authorization;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.DataProtection.KeyManagement;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.IdentityModel.Tokens;
using System.Text;


var builder = WebApplication.CreateBuilder(args);
{
    var services = builder.Services;
    services.AddCors();
    services.AddControllers();
    var configValue = builder.Configuration.GetValue<string>("AppSettings:Secret") ?? string.Empty;
    var key = Encoding.ASCII.GetBytes(configValue);
    services.AddAuthentication(a =>
    {
        a.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
        a.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;
        a.DefaultScheme = JwtBearerDefaults.AuthenticationScheme;
    })
  .AddJwtBearer(o =>
  {
      o.TokenValidationParameters = new TokenValidationParameters()
      {
          ValidateIssuerSigningKey = true,
          IssuerSigningKey = new SymmetricSecurityKey(key),
          ValidateIssuer = false,
          ValidateAudience = false,
          ValidateLifetime = true,
          // set clockskew to zero so tokens expire exactly at token expiration time (instead of 5 minutes later)
          ClockSkew = TimeSpan.Zero
      };
  });
    //builder.Services.AddAuthentication(CookieAuthenticationDefaults.AuthenticationScheme);

    // configure strongly typed settings object
    services.Configure<AppSettingsModel>(builder.Configuration.GetSection("AppSettings"));
    services.AddHttpContextAccessor();

    services.AddScoped<IEmployeeService, EmployeeService>();
    services.AddScoped<IUserService, UserService>();
    services.AddScoped<IJwtUtilsService, JwtUtilsService>();

    services.AddScoped<IEmployeeRepository, EmployeeRepository>();

    services.AddAuthorization(options =>
    {
        options.AddPolicy("MyPolicy", policy =>
        {
            policy.RequireAuthenticatedUser();
            // Other policy requirements
        });
    });
}
builder.Services.AddOptions();
// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var app = builder.Build();
{
    // global cors policy
    app.UseCors(x => x
        .AllowAnyOrigin()
        .AllowAnyMethod()
        .AllowAnyHeader());

    app.UseAuthentication();
    app.UseAuthorization();
}

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();

    // custom jwt auth middleware
    app.UseMiddleware<JwtMiddlewareService>();
}

//builder.Services.ConfigureMyConfig(builder.Configuration);

app.MapControllers();

app.Run();

