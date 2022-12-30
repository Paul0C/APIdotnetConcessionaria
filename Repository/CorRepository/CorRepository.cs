using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ApiConcessionaria.Models.Entities;
using ApiConcessionaria.Data;
using Microsoft.EntityFrameworkCore;

namespace ApiConcessionaria.Repository.CorRepository
{
    public class CorRepository : ICorRepository
    {

        private readonly ConcessionariaContext _concessionariaContext;

        public CorRepository(ConcessionariaContext concessionariaContext)
        {
            _concessionariaContext = concessionariaContext;
        }

        public void AtualizaCor(Cor cor)
        {
            _concessionariaContext.Cores.Update(cor);
        }

        public async Task<Cor> ConsultaCorPorId(int Id)
        {
            return await _concessionariaContext.Cores.FirstOrDefaultAsync(x => x.Id == Id);
        }

        public void InsereCor(Cor cor)
        {
            _concessionariaContext.Cores.Add(cor);
        }

        public async Task<IEnumerable<Cor>> Listarcor()
        {
            var cores = await _concessionariaContext.Cores.ToListAsync();
            return cores;
        }

        public void RemoveCor(Cor cor)
        {
            _concessionariaContext.Cores.Remove(cor);
        }

        public async Task<bool> SaveChangesAsync()
        {
            return await _concessionariaContext.SaveChangesAsync() > 0;
        }
    }
}