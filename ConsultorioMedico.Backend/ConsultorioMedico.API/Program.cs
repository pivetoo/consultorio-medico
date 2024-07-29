using ConsultorioMedico.Dominio.Repositories;
using Microsoft.AspNetCore.Builder;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using NHibernate;
using ConsultorioMedico.Infrastructure.Configurations;
using ConsultorioMedico.Infrastructure.Repositories;
using ConsultorioMedico.Application.Services;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllers();

// Register NHibernate session factory and session
var connectionString = builder.Configuration.GetConnectionString("DefaultConnection");
builder.Services.AddSingleton<INHibernateSessionFactory>(provider =>
{
    return new NHibernateSessionFactory(connectionString);
});

builder.Services.AddSingleton<ISessionFactory>(provider =>
{
    return provider.GetRequiredService<INHibernateSessionFactory>().GetSessionFactory();
});

builder.Services.AddScoped(provider =>
{
    var sessionFactory = provider.GetRequiredService<ISessionFactory>();
    return sessionFactory.OpenSession();
});

// Register repositories
builder.Services.AddScoped<IMedicoRepository, MedicoRepository>();
builder.Services.AddScoped<IPacienteRepository, PacienteRepository>();
builder.Services.AddScoped<MedicoService>();
builder.Services.AddScoped<PacienteService>();

// Add Swagger/OpenAPI support
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
