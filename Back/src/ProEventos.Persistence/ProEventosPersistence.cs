using Microsoft.EntityFrameworkCore;
using ProEventos.Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProEventos.Persistence
{
    public class ProEventosPersistence : IProEventosPersistence
    {
        private readonly ProEventosContext _context;
        public ProEventosPersistence(ProEventosContext context)
        {
            _context = context;
        }
        public void Add<T>(T entity) where T : class
        {
            _context.Add(entity);
        }

        public void Update<T>(T entity) where T : class
        {
            _context.Update(entity);
        }

        public void Delete<T>(T entity) where T : class
        {
            _context.Remove(entity);
        }

        public void DeleteRange<T>(IEnumerable<T> entityCollection) where T : class
        {
            _context.RemoveRange(entityCollection);
        }

        public async Task<bool> SaveChangesAsync()
        {
            return await _context.SaveChangesAsync() > 0;
        }

        public async Task<Evento> GetEventoByIdAsync(int eventoId, bool includePalestrantes = false)
        {
            IQueryable<Evento> queryEvento = _context.Eventos.Where(e => e.Id == eventoId).Include(e => e.Lotes).Include(e => e.RedesSociais);

            if (includePalestrantes)
            {
                queryEvento.Include(e => e.EventosPalestrantes).ThenInclude(pe => pe.Palestrante);
            }

            return await queryEvento.OrderBy(e => e.Id).FirstOrDefaultAsync();
        }

        public async Task<IEnumerable<Evento>> GetEventosAsync(bool includePalestrantes = false)
        {
            IQueryable<Evento> queryEvento = _context.Eventos.Include(e => e.Lotes).Include(e => e.RedesSociais);

            if (includePalestrantes)
            {
                queryEvento.Include(e => e.EventosPalestrantes).ThenInclude(pe => pe.Palestrante);
            }

            return await queryEvento.OrderBy(e => e.Id).ToListAsync();
        }

        public async Task<IEnumerable<Evento>> GetEventosByTemaAsync(string tema, bool includePalestrantes = false)
        {
            IQueryable<Evento> queryEvento = _context.Eventos.Where(e => e.Tema.ToLower().Contains(tema.ToLower()))
                                                             .Include(e => e.Lotes).Include(e => e.RedesSociais);

            if (includePalestrantes)
            {
                queryEvento.Include(e => e.EventosPalestrantes).ThenInclude(pe => pe.Palestrante);
            }

            return await queryEvento.OrderBy(e => e.Id).ToListAsync();
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

        public void Remove<T>(T entity) where T : class
        {
            throw new NotImplementedException();
        }
    }
}
