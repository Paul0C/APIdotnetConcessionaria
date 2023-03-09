using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ApiConcessionaria.Models.DtosIdentity
{
    public class UsuarioCadastroResponse
    {
        public bool Sucesso { get; private set; }

        public UsuarioCadastroResponse(bool sucesso)
        {
            Sucesso = sucesso;
        }
    }
}