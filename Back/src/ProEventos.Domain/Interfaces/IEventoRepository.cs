using ProEventos.Domain.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace ProEventos.Domain.Interfaces
{
    public interface IEventoRepository : IRepository<Evento>
    {
        Task<IEnumerable<Evento>> GetEventosByTemaAsync(string tema, bool includePalestrantes = false); //Retornar todos os eventos por tema
        Task<IEnumerable<Evento>> GetEventosAsync(bool includePalestrantes = false); //Retornar todos os eventos
        Task<Evento> GetEventoByIdAsync(int eventoId, bool includePalestrantes = false); //Retornar evento por id
    }
}
