using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ApiConcessionaria.Models.Entities
{
    public class Marca
    {
        public int Id { get; set; }
        public string Nome { get; set; }
        public string Sede { get; set; }
        public List<Carro> Carros { get; set; }
    }
}