using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ApiConcessionaria.Models.Dtos
{
    public class CarroDetalhesDto
    {
        public string? Marca { get; set; }
        public string Nome { get; set; }
        public int? Ano { get; set; }
        public double? Preco { get; set; }
        public int? Km { get; set; }
        public string? Categoria { get; set; }
        public string? Cor { get; set; }


    }
}