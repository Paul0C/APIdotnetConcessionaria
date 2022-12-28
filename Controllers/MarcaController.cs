using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using ApiConcessionaria.Repository.MarcaRepository;
using ApiConcessionaria.Models.Entities;

namespace ApiConcessionaria.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class MarcaController : ControllerBase
    {
        private readonly IMarcaRepository _marcaRepository;

        public MarcaController(IMarcaRepository marcaRepository)
        {
            _marcaRepository = marcaRepository;
        }

        [HttpGet]
        public async Task<IActionResult> GetMarca()
        {
            var marcas = await _marcaRepository.ListarMarcas();
            return marcas != null
            ? Ok(marcas)
            : NotFound("Não tem marcas presente no banco de dados.");
        }

        [HttpGet("{Id}")]
        public async Task<IActionResult> GetMarcaPorId([FromRoute] int Id)
        {
            var marca = await _marcaRepository.ConsultarMarcaPorId(Id);
            return marca != null
            ? Ok(marca)
            : NotFound("Marca não encontrada");
        }

        [HttpPost]
        public async Task<IActionResult> PostMarca([FromBody] Marca marca)
        {
            _marcaRepository.AdicionarMarca(marca);
            return await _marcaRepository.SaveChangesAsync()
            ? Ok("Marca inserida com sucesso!")
            : BadRequest("Erro na inserção da marca.");
        }

        [HttpPut("{Id}")]
        public async Task<IActionResult> PutMarca(int Id, [FromBody] Marca marca)
        {
            var MarcaDoBanco = await _marcaRepository.ConsultarMarcaPorId(Id);
            if (MarcaDoBanco == null) return NotFound("Marca não encontrada");

            MarcaDoBanco.Nome = marca.Nome == null ? MarcaDoBanco.Nome : marca.Nome;
            MarcaDoBanco.Sede = marca.Sede == null ? MarcaDoBanco.Sede : marca.Sede;

            _marcaRepository.AtualizarMarca(MarcaDoBanco);

            return await _marcaRepository.SaveChangesAsync()
            ? Ok("Marca atualizada com sucesso!")
            : BadRequest("Não foi possível atualizar a marca.");
        }

        [HttpDelete("{Id}")]
        public async Task<IActionResult> DeleteMarca(int Id)
        {
            var MarcaDoBanco = await _marcaRepository.ConsultarMarcaPorId(Id);
            if (MarcaDoBanco == null) return NotFound("Marca não encontrada");

            _marcaRepository.DeletarMarca(MarcaDoBanco);

            return await _marcaRepository.SaveChangesAsync()
            ? Ok("Marca removida com sucesso!")
            : BadRequest("Não foi possível remover a marca.");
        }

    }
}