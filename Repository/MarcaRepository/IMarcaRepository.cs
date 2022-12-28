using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ApiConcessionaria.Models.Entities;

namespace ApiConcessionaria.Repository.MarcaRepository
{
    public interface IMarcaRepository
    {
        void AdicionarMarca(Marca marca);

        Task<IEnumerable<Marca>> ListarMarcas();

        Task<Marca> ConsultarMarcaPorId(int Id);

        void AtualizarMarca(Marca marca);

        void DeletarMarca(Marca marca);

        Task<bool> SaveChangesAsync();
    }
}