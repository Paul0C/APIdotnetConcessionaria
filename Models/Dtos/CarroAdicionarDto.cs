using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ApiConcessionaria.Models.Dtos
{
    public class CarroAdicionarDto
    {
        public int Id { get; set; }
        public string? Nome { get; set; }
        public int? Ano { get; set; }
        public double? Preco { get; set; }
        public int? Km { get; set; }
        public int? MarcaId { get; set; }
        public int? CategoriaId { get; set; }
        public int? CorId { get; set; }
    }
}