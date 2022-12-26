using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ApiConcessionaria.Models.Entities;
using ApiConcessionaria.Repository.CategoriaRepository;
using ApiConcessionaria.Repository;
using Microsoft.AspNetCore.Mvc;

namespace ApiConcessionaria.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class CategoriaController : ControllerBase
    {

        private readonly ICategoriaRepository _categoriaRepository;

        public CategoriaController(ICategoriaRepository categoriaRepository)
        {
            _categoriaRepository = categoriaRepository;
        }

        [HttpGet]
        public async Task<IActionResult> GetCategorias()
        {
            var categorias = await _categoriaRepository.Listarcategorias();
            return categorias != null
            ? Ok(categorias)
            : NotFound("Não tem categorias presente no banco de dados");
        }

        [HttpGet]
        [Route("{Id}")]
        public async Task<IActionResult> GetCategoriaPorId([FromRoute] int Id)
        {
            var categoria = await _categoriaRepository.ConsultaCategoriaPorId(Id);
            return categoria == null
            ? NotFound("Categoria não encontrada")
            : Ok(categoria);
        }

        [HttpPost]
        public async Task<IActionResult> PostCategoria([FromBody] Categoria categoria)
        {
            _categoriaRepository.InsereCategoria(categoria);
            return await _categoriaRepository.SaveChangesAsync()
            ? Ok("Categoria inserida com sucesso")
            : BadRequest("Erro na inserção da categoria");
        }

        [HttpPut("{Id}")]
        public async Task<IActionResult> PutCategoria([FromBody] Categoria categoria, int Id)
        {
            var CategoriaDoBanco = await _categoriaRepository.ConsultaCategoriaPorId(Id);
            if (CategoriaDoBanco == null) return NotFound("Categoria não encontrada.");

            CategoriaDoBanco.Nome = categoria.Nome != null
            ? categoria.Nome
            : CategoriaDoBanco.Nome;

            _categoriaRepository.AtualizaCategoria(CategoriaDoBanco);
            return await _categoriaRepository.SaveChangesAsync()
            ? Ok("Categoria atualizada com sucesso!" + categoria)
            : BadRequest("Não foi possível atualizar a categoria.");
        }

        [HttpDelete("{Id}")]
        public async Task<IActionResult> DeleteCategoria(int Id)
        {
            var categoria = _categoriaRepository.ConsultaCategoriaPorId(Id);
            if (categoria == null) return NotFound("Não foi possível encontrar a categoria.");

            _categoriaRepository.RemoveCategoria(Id);
            return await _categoriaRepository.SaveChangesAsync()
            ? Ok("Categoria removida com sucesso")
            : BadRequest("Não foi possível remover a categoria");
        }
    }
}