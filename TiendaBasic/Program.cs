using Microsoft.EntityFrameworkCore;
using TiendaBasic.Data;
using TiendaBasic.Repositories;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

// 1.Añadimos la conexion a la base de datos.
builder.Services.AddDbContext<TiendaContext>(options => options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection")));

// 2.Añadimos el repositorio a la inyeccion de dependencias.
builder.Services.AddScoped<RepositoryCliente>();

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

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
