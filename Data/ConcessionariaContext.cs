using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ApiConcessionaria.Models.Entities;
using Microsoft.EntityFrameworkCore;

namespace ApiConcessionaria.Data
{
    public class ConcessionariaContext : DbContext
    {
        public ConcessionariaContext(DbContextOptions options) : base(options)
        {
        }

        public DbSet<Carro> Carros { get; set; }
        public DbSet<Categoria> Categorias { get; set; }
        public DbSet<Cor> Cores { get; set; }
        public DbSet<Marca> Marcas { get; set; }
    }
}