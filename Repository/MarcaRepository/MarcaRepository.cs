using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ApiConcessionaria.Models.Entities;
using ApiConcessionaria.Data;
using Microsoft.EntityFrameworkCore;

namespace ApiConcessionaria.Repository.MarcaRepository
{
    public class MarcaRepository : IMarcaRepository
    {

        private readonly ConcessionariaContext _concessionariaContext;

        public MarcaRepository(ConcessionariaContext concessionariaContext)
        {
            _concessionariaContext = concessionariaContext;
        }

        public void AdicionarMarca(Marca marca)
        {
            _concessionariaContext.Marcas.Add(marca);
        }

        public void AtualizarMarca(Marca marca)
        {
            _concessionariaContext.Marcas.Update(marca);
        }

        public async Task<Marca> ConsultarMarcaPorId(int Id)
        {
            return await _concessionariaContext.Marcas.FirstOrDefaultAsync(x => x.Id == Id);
        }

        public void DeletarMarca(Marca marca)
        {
            _concessionariaContext.Marcas.Remove(marca);
        }

        public async Task<IEnumerable<Marca>> ListarMarcas()
        {
            var marcas = await _concessionariaContext.Marcas.ToListAsync();
            return marcas;
        }

        public async Task<bool> SaveChangesAsync()
        {
            return await _concessionariaContext.SaveChangesAsync() > 0;
        }
    }
}