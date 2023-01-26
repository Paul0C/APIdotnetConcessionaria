using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using ApiConcessionaria.Models.Entities;
using ApiConcessionaria.Models.Dtos;
using ApiConcessionaria.Repository.FiltroRepository;

namespace ApiConcessionaria.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class FiltroController : ControllerBase
    {
        private readonly IFiltroRepository _filtroRepository;

        public FiltroController(IFiltroRepository filtroRepository)
        {
            _filtroRepository = filtroRepository;
        }

        [HttpGet]
        public async Task<IActionResult> GetCarrosPorFiltragem([FromQuery] int? CategoriaId, [FromQuery] int? MarcaId)
        {
            if ((CategoriaId.HasValue && MarcaId.HasValue))
            {
                var veiculosFiltro = await _filtroRepository.FiltragemCategoriaMarca((int)CategoriaId, (int)MarcaId);
                return veiculosFiltro.Any()
                ? Ok(veiculosFiltro)
                : NotFound("Não foi possível fazer a filtragem");

            }
            else if (CategoriaId == null)
            {
                var veiculosFiltro = await _filtroRepository.FiltragemMarca((int)MarcaId);
                return veiculosFiltro.Any()
                ? Ok(veiculosFiltro)
                : NotFound("Não foi possível fazer a filtragem");
            }
            else
            {
                var veiculosFiltro = await _filtroRepository.FiltragemCategoria((int)CategoriaId);
                return veiculosFiltro.Any()
                ? Ok(veiculosFiltro)
                : NotFound("Não foi possível fazer a filtragem");
            }
        }
    }
}