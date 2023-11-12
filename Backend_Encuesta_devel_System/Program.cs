using Backend_Encuesta_devel_System.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

//Cadena de conexion con el modelo.
builder.Services.AddDbContext<EncuestaContext>(options =>
        options.UseSqlServer(builder.Configuration.GetConnectionString("CadenaConexion")));

//Politica de cors.
builder.Services.AddCors(option =>
{
    option.AddPolicy("NuevaPolitica", app =>
    {
        app.AllowAnyOrigin()
        .AllowAnyHeader() 
        .AllowAnyMethod();
    });
});

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthorization();

//politica de cors
app.UseCors("NuevaPolitica");

app.MapControllers();

app.Run();
