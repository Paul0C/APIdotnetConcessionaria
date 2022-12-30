using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using ApiConcessionaria.Repository.CorRepository;
using ApiConcessionaria.Models.Entities;

namespace ApiConcessionaria.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class CorController : ControllerBase
    {
        private readonly ICorRepository _corRepository;

        public CorController(ICorRepository corRepository)
        {
            _corRepository = corRepository;
        }

        [HttpGet]
        public async Task<IActionResult> GetCor()
        {
            var cores = await _corRepository.Listarcor();
            return cores != null
            ? Ok(cores)
            : NotFound("Não tem cores presente no banco de dados.");
        }

        [HttpGet("{Id}")]
        public async Task<IActionResult> GetCorPorId([FromRoute] int Id)
        {
            var cor = await _corRepository.ConsultaCorPorId(Id);
            return cor != null
            ? Ok(cor)
            : NotFound("Cor não encontrada");
        }

        [HttpPost]
        public async Task<IActionResult> PostCor([FromBody] Cor cor)
        {
            _corRepository.InsereCor(cor);
            return await _corRepository.SaveChangesAsync()
            ? Ok("Cor inserida com sucesso!")
            : BadRequest("Erro na inserção da cor.");
        }

        [HttpPut("{Id}")]
        public async Task<IActionResult> PutCor(int Id, [FromBody] Cor cor)
        {
            var CorDoBanco = await _corRepository.ConsultaCorPorId(Id);
            if (CorDoBanco == null) return NotFound("Cor não encontrada");

            CorDoBanco.Nome = cor.Nome == null ? CorDoBanco.Nome : cor.Nome;

            _corRepository.AtualizaCor(CorDoBanco);

            return await _corRepository.SaveChangesAsync()
            ? Ok("Cor atualizada com sucesso!")
            : BadRequest("Não foi possível atualizar a cor.");
        }

        [HttpDelete("{Id}")]
        public async Task<IActionResult> DeleteCor(int Id)
        {
            var CorDoBanco = await _corRepository.ConsultaCorPorId(Id);
            if (CorDoBanco == null) return NotFound("Cor não encontrada");

            _corRepository.RemoveCor(CorDoBanco);

            return await _corRepository.SaveChangesAsync()
            ? Ok("Cor removida com sucesso!")
            : BadRequest("Não foi possível remover a cor.");
        }
    }
}