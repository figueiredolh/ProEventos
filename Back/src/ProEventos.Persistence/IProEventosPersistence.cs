using ProEventos.Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProEventos.Persistence
{
    public interface IProEventosPersistence
    {
        //Interfaces Comuns
        void Add<T>(T entity) where T : class;
        void Update<T>(T entity) where T : class;
        void Remove<T>(T entity) where T : class;
        void Delete<T>(T entity) where T : class;
        void DeleteRange<T>(IEnumerable<T> entityCollection) where T : class;
        Task<bool> SaveChangesAsync();

        //Interfaces para Eventos
        
        Task<IEnumerable<Evento>> GetEventosByTemaAsync(string tema, bool includePalestrantes); //Retornar todos os eventos por tema
        Task<IEnumerable<Evento>> GetEventosAsync(bool includePalestrantes); //Retornar todos os eventos
        Task<Evento> GetEventoByIdAsync(int eventoId, bool includePalestrantes); //Retornar evento por id

        //Interfaces para Palestrantes

        Task<IEnumerable<Palestrante>> GetPalestrantesByNomeAsync(string nome, bool includeEventos); //Retornar todos palestrantes por nome
        Task<IEnumerable<Palestrante>> GetPalestrantesAsync(bool includeEventos); //Retornar todos os palestrantes
        Task<Palestrante> GetPalestranteByIdAsync(int palestranteId, bool includeEventos); //Retornar palestrante por id
    }
}
