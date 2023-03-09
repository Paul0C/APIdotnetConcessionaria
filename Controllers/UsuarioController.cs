using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ApiConcessionaria.Services;
using ApiConcessionaria.Models.DtosIdentity;
using Microsoft.AspNetCore.Mvc;

namespace ApiConcessionaria.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class UsuarioController : ControllerBase
    {
        private readonly IIdentityService _identityService;

        public UsuarioController(IIdentityService identityService)
        {
            _identityService = identityService;
        }

        [HttpPost("cadastro")]
        public async Task<ActionResult<UsuarioCadastroResponse>> Cadastrar(UsuarioCadastroRequest usuarioCadastro)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest();
            }

            var resultado = await _identityService.CadastrarUsuario(usuarioCadastro);

            if (resultado.Sucesso)
            {
                return Ok(resultado);
            }/*else if(resultado.Erros.Count > 0){
                return BadRequest(resultado);
            }*/

            return StatusCode(StatusCodes.Status500InternalServerError);
        }

        [HttpPost("login")]
        public async Task<ActionResult<UsuarioLoginResponse>> Login(UsuarioLoginRequest usuarioLogin)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest();
            }

            var resultado = await _identityService.Login(usuarioLogin);

            if (resultado.Sucesso)
            {
                return Ok(resultado);
            }

            return Unauthorized(resultado);
        }
    }
}