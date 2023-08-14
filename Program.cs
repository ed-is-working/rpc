// global availability
global using rpc.Models;
global using rpc.Services.CharacterService;
global using rpc.DTOs.Character;
global using AutoMapper; // It is used in the CharacterService.cs and will be used elsewhere
global using Microsoft.EntityFrameworkCore; // It is used in the DataContext.cs and will be used elsewhere
global using rpc.Data; // It is used in the DataContext.cs and will be used elsewhere

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddDbContext<DataContext>(options => options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection")));    

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
// Add AutoMapper
builder.Services.AddAutoMapper(typeof(Program).Assembly);

// Add the CharacterService to the container
// add a scoped service for every request
builder.Services.AddScoped<ICharacterService, CharacterService>();

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
