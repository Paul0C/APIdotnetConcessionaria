using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ApiConcessionaria.Models.Dtos;
using ApiConcessionaria.Models.Entities;

namespace ApiConcessionaria.Repository.CarroRepository
{
    public interface ICarroRepository
    {
        void InsereCarro(CarroAdicionarDto carro);

        Task<IEnumerable<CarroDto>> ListarCarros();

        Task<CarroDetalhesDto> ConsultarCarroDetalhesPorId(int Id);

        Task<Carro> ConsultarCarroPorId(int Id);

        void AtualizaCarro(Carro carro);

        void RemoveCarro(Carro carro);

        Task<bool> SaveChangesAsync();
    }
}