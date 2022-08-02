using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using ProEventos.Domain.Interfaces;
using ProEventos.Domain.Models;

namespace ProEventos.Persistence.Repositories
{
    public class EventoRepository : Repository<Evento>, IEventoRepository
    {
        public EventoRepository(ProEventosContext context) : base(context)
        {
        }
        public async Task<Evento> GetEventoByIdAsync(int eventoId, bool includePalestrantes = false)
        {
            IQueryable<Evento> queryEvento = _context.Eventos.Where(e => e.Id == eventoId).Include(e => e.Lotes).Include(e => e.RedesSociais);

            if (includePalestrantes)
            {
                queryEvento.Include(e => e.EventosPalestrantes).ThenInclude(pe => pe.Palestrante);
            }

            return await queryEvento.AsNoTracking().OrderBy(e => e.Id).FirstOrDefaultAsync();
        }

        public async Task<IEnumerable<Evento>> GetEventosAsync(bool includePalestrantes = false)
        {
            IQueryable<Evento> queryEvento = _context.Eventos.Include(e => e.Lotes).Include(e => e.RedesSociais);

            if (includePalestrantes)
            {
                queryEvento.Include(e => e.EventosPalestrantes).ThenInclude(pe => pe.Palestrante);
            }

            return await queryEvento.AsNoTracking().OrderBy(e => e.Id).ToListAsync();
        }

        public async Task<IEnumerable<Evento>> GetEventosByTemaAsync(string tema, bool includePalestrantes = false)
        {
            IQueryable<Evento> queryEvento = _context.Eventos.Where(e => e.Tema.ToLower().Contains(tema.ToLower()))
                                                             .Include(e => e.Lotes).Include(e => e.RedesSociais);

            if (includePalestrantes)
            {
                queryEvento.Include(e => e.EventosPalestrantes).ThenInclude(pe => pe.Palestrante);
            }

            return await queryEvento.AsNoTracking().OrderBy(e => e.Id).ToListAsync();
        }
    }
}
