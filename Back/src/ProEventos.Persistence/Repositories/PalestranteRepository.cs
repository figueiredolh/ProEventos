using ProEventos.Domain.Interfaces;
using ProEventos.Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProEventos.Persistence.Repositories
{
    public class PalestranteRepository : Repository<Palestrante>, IPalestranteRepository
    {
        public PalestranteRepository(ProEventosContext context) : base(context)
        {

        }
        public Task<Palestrante> GetPalestranteByIdAsync(int palestranteId, bool includeEventos)
        {
            throw new NotImplementedException();
        }

        public Task<IEnumerable<Palestrante>> GetPalestrantesAsync(bool includeEventos)
        {
            throw new NotImplementedException();
        }

        public Task<IEnumerable<Palestrante>> GetPalestrantesByNomeAsync(string nome, bool includeEventos)
        {
            throw new NotImplementedException();
        }
    }
}
