using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ApiConcessionaria.Models.Entities;
using ApiConcessionaria.Data;
using Microsoft.EntityFrameworkCore;

namespace ApiConcessionaria.Repository.CategoriaRepository
{
    public class CategoriaRepository : ICategoriaRepository
    {

        private readonly ConcessionariaContext _concessionariaContext;

        public CategoriaRepository(ConcessionariaContext concessionariaContext)
        {
            _concessionariaContext = concessionariaContext;
        }

        public void AtualizaCategoria(Categoria categoria)
        {
            _concessionariaContext.Categorias.Update(categoria);
        }

        public async Task<Categoria> ConsultaCategoriaPorId(int Id)
        {
            return await _concessionariaContext.Categorias.FirstOrDefaultAsync(x => x.Id == Id);
        }

        public void InsereCategoria(Categoria categoria)
        {
            _concessionariaContext.Categorias.Add(categoria);
        }

        public async Task<IEnumerable<Categoria>> Listarcategorias()
        {
            return await _concessionariaContext.Categorias.ToListAsync();
        }

        public void RemoveCategoria(Categoria categoria)
        {
            _concessionariaContext.Categorias.Remove(categoria);
        }

        public async Task<bool> SaveChangesAsync()
        {
            return await _concessionariaContext.SaveChangesAsync() > 0;
        }
    }
}