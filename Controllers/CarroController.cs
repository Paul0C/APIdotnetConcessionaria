using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using ApiConcessionaria.Models.Entities;
using ApiConcessionaria.Repository.CarroRepository;
using ApiConcessionaria.Repository.MarcaRepository;
using ApiConcessionaria.Models.Dtos;

namespace ApiConcessionaria.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class CarroController : ControllerBase
    {
        private readonly ICarroRepository _carroRepository;

        public CarroController(ICarroRepository carroRepository)
        {
            _carroRepository = carroRepository;
        }

        [HttpGet]
        public async Task<IActionResult> GetCarros()
        {
            var carros = await _carroRepository.ListarCarros();
            return carros != null
            ? Ok(carros)
            : NotFound("Não foi possível listar os carros");
        }

        [HttpGet("{Id}")]
        public async Task<IActionResult> GetCarrosPorId(int Id)
        {
            if (Id <= 0) return BadRequest("Id inválido.");

            var carro = await _carroRepository.ConsultarCarroDetalhesPorId(Id);

            return carro != null
            ? Ok(carro)
            : NotFound("Não foi possível encontrar o carro");
        }

        [HttpGet("{IdCategoria}/CarrosPorCategoria")]
        public async Task<IActionResult> GetCarrosPorCategoria(int IdCategoria)
        {
            if (IdCategoria <= 0) return BadRequest("Id inválido.");

            var carro = await _carroRepository.ListarCarrosPorCategoria(IdCategoria);

            return carro.Any()
            ? Ok(carro)
            : NotFound("Essa categoria está sem carros no momento.");
        }

        [HttpPost]
        public async Task<IActionResult> PostCarro([FromBody] CarroAdicionarDto carro)
        {
            _carroRepository.InsereCarro(carro);
            return await _carroRepository.SaveChangesAsync()
            ? Ok("Carro inserido com sucesso")
            : BadRequest("Não foi possível inserir o carro.");
        }


        [HttpPut("{Id}")]
        public async Task<IActionResult> PutCarro([FromBody] CarroAtualizarDto carro, int Id)
        {
            if (Id <= 0) return BadRequest("Id inválido.");

            var CarroDoBanco = await _carroRepository.ConsultarCarroPorId(Id);
            if (CarroDoBanco == null) return NotFound("O carro não foi encontrado.");

            CarroDoBanco.Nome = carro.Nome == null ? CarroDoBanco.Nome : carro.Nome;
            CarroDoBanco.Ano = carro.Ano == null ? CarroDoBanco.Ano : carro.Ano;
            CarroDoBanco.Preco = carro.Preco == null ? CarroDoBanco.Preco : carro.Preco;
            CarroDoBanco.Km = carro.Km == null ? CarroDoBanco.Km : carro.Km;
            CarroDoBanco.MarcaId = carro.MarcaId == null ? CarroDoBanco.MarcaId : carro.MarcaId;
            CarroDoBanco.CategoriaId = carro.CategoriaId == null ? CarroDoBanco.CategoriaId : carro.CategoriaId;
            CarroDoBanco.CorId = carro.CorId == null ? CarroDoBanco.CorId : carro.CorId;

            _carroRepository.AtualizaCarro(CarroDoBanco);

            return await _carroRepository.SaveChangesAsync()
            ? Ok("O carro foi atualizado com sucesso!")
            : BadRequest("Não foi possível atualizar o carro.");
        }


        [HttpDelete("{Id}")]
        public async Task<IActionResult> DeleteCarro(int Id)
        {
            if (Id <= 0) return BadRequest("Id inválido.");

            var carro = await _carroRepository.ConsultarCarroPorId(Id);
            if (carro == null) return NotFound("Não foi possível encontrar o carro");

            _carroRepository.RemoveCarro(carro);

            return await _carroRepository.SaveChangesAsync()
            ? Ok("Carro removido com sucesso!")
            : BadRequest("Não foi possível remover o carro.");
        }
    }
}