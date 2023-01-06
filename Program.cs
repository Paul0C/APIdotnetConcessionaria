using ApiConcessionaria.Data;
using ApiConcessionaria.Repository.CategoriaRepository;
using ApiConcessionaria.Repository.MarcaRepository;
using ApiConcessionaria.Repository.CorRepository;
using ApiConcessionaria.Repository.CarroRepository;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

string connectionString = builder.Configuration.GetConnectionString("ConcessionariaContext");
builder.Services.AddDbContext<ConcessionariaContext>(options =>
    options.UseSqlServer(connectionString));

builder.Services.AddScoped<ICategoriaRepository, CategoriaRepository>();
builder.Services.AddScoped<IMarcaRepository, MarcaRepository>();
builder.Services.AddScoped<ICorRepository, CorRepository>();
builder.Services.AddScoped<ICarroRepository, CarroRepository>();


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
