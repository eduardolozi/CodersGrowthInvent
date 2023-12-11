using CrudWinFormsBancoMemoria;
using CrudWinFormsBancoMemoria.Models;
using Dominio.Validacoes;
using Infraestrutura.Repositorios;
using Microsoft.AspNetCore.StaticFiles;
using Microsoft.Extensions.FileProviders;

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

builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var app = builder.Build();

if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseStaticFiles(new StaticFileOptions
{
   FileProvider = new PhysicalFileProvider(
                   Path.Combine(Directory.GetCurrentDirectory(), "wwwroot")
               ),
   ContentTypeProvider = new FileExtensionContentTypeProvider
   {
       Mappings = { [".properties"] = "application/x-msdownload" }
   }
});

app.UseRouting();

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();

