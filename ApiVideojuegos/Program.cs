//Leonel Contreras
using ApiVideojuegos.Application.Services;
using ApiVideojuegos.Data;
using ApiVideojuegos.Domain.Interfaces;
using ApiVideojuegos.Domain.Services;
using ApiVideojuegos.Infrastructure.Repositories;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services.AddDbContext<AppDbContext>(options =>
    options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection")));

builder.Services.AddScoped<ICategoriaRepository, CategoriaRepository>();
builder.Services.AddScoped<IVideojuegoRepository, VideojuegoRepository>();

builder.Services.AddScoped<CategoriaDomainService>();
builder.Services.AddScoped<VideojuegoDomainService>();

builder.Services.AddScoped<CategoriaAppService>();
builder.Services.AddScoped<VideojuegoAppService>();

var app = builder.Build();

if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();
app.UseAuthorization();
app.MapControllers();

app.Run();