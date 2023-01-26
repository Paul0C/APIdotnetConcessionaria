using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ApiConcessionaria.Models.Dtos;
using ApiConcessionaria.Data;
using Microsoft.EntityFrameworkCore;

namespace ApiConcessionaria.Repository.FiltroRepository
{
    public class FiltroRepository : IFiltroRepository
    {

        private readonly ConcessionariaContext _concessionariaContext;

        public FiltroRepository(ConcessionariaContext concessionariaContext)
        {
            _concessionariaContext = concessionariaContext;
        }

        public async Task<IEnumerable<CarroDto>> FiltragemCategoria(int categoria)
        {
            return await _concessionariaContext.Carros.Where(x => x.CategoriaId == categoria).Select(x => new CarroDto
            {
                Id = x.Id,
                Marca = x.Marca.Nome,
                Nome = x.Nome
            })
           .ToListAsync();
        }

        public async Task<IEnumerable<CarroDto>> FiltragemCategoriaMarca(int categoria, int marca)
        {
            return await _concessionariaContext.Carros.Where(x => x.CategoriaId == categoria
            && x.MarcaId == marca)
            .Select(x => new CarroDto
            {
                Id = x.Id,
                Marca = x.Marca.Nome,
                Nome = x.Nome
            }).ToListAsync();
        }

        public async Task<IEnumerable<CarroDto>> FiltragemMarca(int marca)
        {
            return await _concessionariaContext.Carros.Where(x => x.MarcaId == marca).Select(x => new CarroDto
            {
                Id = x.Id,
                Marca = x.Marca.Nome,
                Nome = x.Nome
            })
            .ToListAsync();
        }
    }
}