using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ApiConcessionaria.Models.DtosIdentity;

namespace ApiConcessionaria.Services
{
    public interface IIdentityService
    {
        Task<UsuarioCadastroResponse> CadastrarUsuario(UsuarioCadastroRequest usuarioCadastro);

        Task<UsuarioLoginResponse> Login(UsuarioLoginRequest usuarioLogin);
    }
}