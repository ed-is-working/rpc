// global availability
global using rpc.Models;
global using rpc.Services.CharacterService;
global using rpc.DTOs.Character;
// global using AutoMapper;
global using Microsoft.EntityFrameworkCore;
global using rpc.Data;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.IdentityModel.Tokens;
using System.Text;
using Swashbuckle.AspNetCore.Filters;
using Microsoft.OpenApi.Models;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle

builder.Services.AddDbContext<DataContext>(options => options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection")));    
builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();

// Add Swagger Config
// Bearer scheme is the standard for JWT authentication
builder.Services.AddSwaggerGen(c =>
{
    c.SwaggerDoc("v1", new() { Title = "Web API Auth with JSON Web Tokens", Version = "v1" });
    c.AddSecurityDefinition("oauth2", new OpenApiSecurityScheme
    {
        Description = "Standard Authorization header using the Bearer scheme. Example: \"bearer {token}\"",
        In = ParameterLocation.Header,
        Name = "Authorization",
        Type = SecuritySchemeType.ApiKey
    });
    c.OperationFilter<SecurityRequirementsOperationFilter>();
});

builder.Services.AddSwaggerGen();
// Add AutoMapper
builder.Services.AddAutoMapper(typeof(Program).Assembly);

// Add the CharacterService to the container
builder.Services.AddScoped<ICharacterService, CharacterService>();

// Add the AuthRepository to the container
builder.Services.AddScoped<IAuthRepository, AuthRepository>();

// Add authentication scheme to secure web services
// install Microsoft.AspNetCore.Authentication.JwtBearer
// ! null forgiving operator (removes warning, its baked in!)
builder.Services.AddAuthentication(JwtBearerDefaults.AuthenticationScheme)
    .AddJwtBearer(options => {
        options.TokenValidationParameters = new TokenValidationParameters{
            ValidateIssuerSigningKey = true,
            IssuerSigningKey = new SymmetricSecurityKey(Encoding.ASCII.GetBytes(builder.Configuration.GetSection("AppSettings:Token").Value!)),
            ValidateIssuer = false,
            ValidateAudience = false
        };
    });

var app = builder.Build();

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
