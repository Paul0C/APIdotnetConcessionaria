using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ApiConcessionaria.Models.Entities;

namespace ApiConcessionaria.Repository.CorRepository
{
    public interface ICorRepository
    {
        void InsereCor(Cor cor);

        Task<IEnumerable<Cor>> Listarcor();

        Task<Cor> ConsultaCorPorId(int Id);

        void AtualizaCor(Cor cor);

        void RemoveCor(Cor cor);

        Task<bool> SaveChangesAsync();
    }
}