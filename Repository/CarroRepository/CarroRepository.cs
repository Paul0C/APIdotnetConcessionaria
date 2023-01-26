using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using ApiConcessionaria.Data;
using ApiConcessionaria.Models.Entities;
using ApiConcessionaria.Models.Dtos;

namespace ApiConcessionaria.Repository.CarroRepository
{
    public class CarroRepository : ICarroRepository
    {

        private readonly ConcessionariaContext _concessionariaContext;

        public CarroRepository(ConcessionariaContext concessionariaContext)
        {
            _concessionariaContext = concessionariaContext;
        }

        public void AtualizaCarro(Carro carro)
        {
            _concessionariaContext.Carros.Update(carro);
        }

        public async Task<CarroDetalhesDto> ConsultarCarroDetalhesPorId(int Id)
        {

            return await _concessionariaContext.Carros.Where(x => x.Id == Id).Select(x => new CarroDetalhesDto
            {
                Marca = x.Marca.Nome,
                Nome = x.Nome,
                Ano = x.Ano,
                Preco = x.Preco,
                Km = x.Km,
                Categoria = x.Categoria.Nome,
                Cor = x.Cor.Nome
            }).FirstOrDefaultAsync();
        }

        public async Task<Carro> ConsultarCarroPorId(int Id)
        {
            return await _concessionariaContext.Carros.FirstOrDefaultAsync(x => x.Id == Id);
        }

        public void InsereCarro(CarroAdicionarDto carro)
        {

            _concessionariaContext.Carros.Add(new Carro
            {
                Nome = carro.Nome,
                Ano = carro.Ano,
                Preco = carro.Preco,
                Km = carro.Km,
                MarcaId = carro.MarcaId,
                CategoriaId = carro.CategoriaId,
                CorId = carro.CorId
            });
        }

        public async Task<IEnumerable<CarroDto>> ListarCarros()
        {

            return await _concessionariaContext.Carros.Select(x => new CarroDto
            {
                Id = x.Id,
                Marca = x.Marca.Nome,
                Nome = x.Nome
            }).ToListAsync();
        }

        public async Task<IEnumerable<CarroDto>> ListarCarrosPorCategoria(int Id)
        {
            return await _concessionariaContext.Carros.Where(x => x.CategoriaId == Id).Select(x => new CarroDto
            {
                Id = x.Id,
                Marca = x.Marca.Nome,
                Nome = x.Nome
            })
            .ToListAsync();
        }

        public void RemoveCarro(Carro carro)
        {
            _concessionariaContext.Carros.Remove(carro);
        }

        public async Task<bool> SaveChangesAsync()
        {
            return await _concessionariaContext.SaveChangesAsync() > 0;
        }
    }
}