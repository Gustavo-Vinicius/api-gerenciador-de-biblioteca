using gerenciador_de_biblioteca.API.Configuration;
using gerenciador_de_biblioteca.Core.Interfaces.Repositories;
using gerenciador_de_biblioteca.Core.Interfaces.Services;
using gerenciador_de_biblioteca.Core.Services;
using gerenciador_de_biblioteca.Infrastructure.Persistence;
using gerenciador_de_biblioteca.Infrastructure.Persistence.Repositories;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddControllers();
// Add services to the container.
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var connectionString = builder.Configuration.GetConnectionString("GerenciadorDeBiblioteca");
builder.Services.AddDbContext<BibliotecaDbContext>(p => p.UseSqlServer(connectionString));

builder.Services.AddSwaggerConfiguration();

builder.Services.AddScoped<IGerenciamentoBibliotecaRepository, GerenciamentoBibliotecaRepository>();
builder.Services.AddScoped<IUsuarioRepository, UsuarioRepository>();
builder.Services.AddScoped<ILivroRepository, LivroRepository>();

builder.Services.AddScoped<IGerenciamentoBibliotecaService, GerenciamentoBibliotecaService>();
builder.Services.AddScoped<IUsuarioService, UsuarioService>();
builder.Services.AddScoped<ILivroService, LivroService>();

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

