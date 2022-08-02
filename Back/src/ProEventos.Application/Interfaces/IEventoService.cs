using ProEventos.Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProEventos.Application.Interfaces
{
    public interface IEventoService
    {
        Task<Evento> AddEvento(Evento modelEvento);
        Task<Evento> UpdateEvento(int eventoId, Evento modelEvento);
        Task<bool> DeleteEvento(int eventoId);
        Task<IEnumerable<Evento>> GetAllEventos(bool includePalestrantes = false);
        Task<IEnumerable<Evento>> GetAllEventosByTema(string tema, bool includePalestrantes = false);
        Task<Evento> GetEventoById(int eventoId, bool includePalestrantes = false);
    }
}
