using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ApiConcessionaria.Models.Dtos;

namespace ApiConcessionaria.Repository.FiltroRepository
{
    public interface IFiltroRepository
    {
        Task<IEnumerable<CarroDto>> FiltragemCategoriaMarca(int categoria, int marca);
        Task<IEnumerable<CarroDto>> FiltragemCategoria(int categoria);
        Task<IEnumerable<CarroDto>> FiltragemMarca(int marca);
    }
}