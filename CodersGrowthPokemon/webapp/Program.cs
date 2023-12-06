using CrudWinFormsBancoMemoria;
using CrudWinFormsBancoMemoria.Models;
using Dominio.Validacoes;
using Infraestrutura.Repositorios;

try
{
    BancoDeDados.ConfiguracaoDaMigracao();
}
catch (Exception ex)
{
    ex.ToString();
}

var builder = WebApplication.CreateBuilder(args);
builder.Services.AddScoped<IRepositorio, RepositorioLinqToDb>();
builder.Services.AddScoped<PokemonValidator>();

// Add services to the container.

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

app.UseStaticFiles();

app.UseRouting();

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();

