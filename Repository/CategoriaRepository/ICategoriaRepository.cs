using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ApiConcessionaria.Models.Entities;

namespace ApiConcessionaria.Repository.CategoriaRepository
{
    public interface ICategoriaRepository
    {
        void InsereCategoria(Categoria categoria);

        Task<IEnumerable<Categoria>> Listarcategorias();

        Task<Categoria> ConsultaCategoriaPorId(int Id);

        void AtualizaCategoria(Categoria categoria);

        void RemoveCategoria(Categoria categoria);

        Task<bool> SaveChangesAsync();
    }
}