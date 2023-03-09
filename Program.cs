using ApiConcessionaria.Data;
using ApiConcessionaria.Repository.CategoriaRepository;
using ApiConcessionaria.Repository.MarcaRepository;
using ApiConcessionaria.Repository.CorRepository;
using ApiConcessionaria.Repository.CarroRepository;
using ApiConcessionaria.Repository.FiltroRepository;
using Microsoft.EntityFrameworkCore;
using ApiConcessionaria.Services;
using ApiConcessionaria.Configurations;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.IdentityModel.Tokens;
using System.Text;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

string connectionString = builder.Configuration.GetConnectionString("ConcessionariaContext");
builder.Services.AddDbContext<ConcessionariaContext>(options =>
    options.UseSqlServer(connectionString));

builder.Services.AddDbContext<IdentityDataContext>(options =>
    options.UseSqlServer(connectionString));

builder.Services.AddScoped<ICategoriaRepository, CategoriaRepository>();
builder.Services.AddScoped<IMarcaRepository, MarcaRepository>();
builder.Services.AddScoped<ICorRepository, CorRepository>();
builder.Services.AddScoped<ICarroRepository, CarroRepository>();
builder.Services.AddScoped<IFiltroRepository, FiltroRepository>();
builder.Services.AddScoped<IIdentityService, IdentityService>();

builder.Services.AddDefaultIdentity<IdentityUser>()
                .AddRoles<IdentityRole>()
                .AddEntityFrameworkStores<IdentityDataContext>()
                .AddDefaultTokenProviders();

builder.Services.AddAuthentication(builder.Configuration);
builder.Services.AddSwagger();


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
