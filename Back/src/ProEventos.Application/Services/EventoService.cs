using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ProEventos.Application.Interfaces;
using ProEventos.Domain.Models;
using ProEventos.Domain.Interfaces;

namespace ProEventos.Application.Services
{
    public class EventoService : IEventoService
    {
        private readonly IEventoRepository _eventoRepository;

        public EventoService(IEventoRepository eventoRepository)
        {
            _eventoRepository = eventoRepository;
        }
        public async Task<Evento> AddEvento(Evento modelEvento)
        {
            try
            {
                _eventoRepository.Add(modelEvento);

                if (await _eventoRepository.SaveChangesAsync())
                {
                    return await _eventoRepository.GetEventoByIdAsync(modelEvento.Id, false);
                }

                return null;

            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public async Task<Evento> UpdateEvento(int eventoId, Evento modelEvento) 
        {
            try
            {
                var evento = await _eventoRepository.GetEventoByIdAsync(eventoId, false);

                if (evento == null)
                {
                    return null;
                }

                modelEvento.Id = eventoId;
                _eventoRepository.Update(modelEvento);

                if(await _eventoRepository.SaveChangesAsync())
                {
                    return await _eventoRepository.GetEventoByIdAsync(modelEvento.Id, false); //retorno do novo evento
                }

                return null;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public async Task<bool> DeleteEvento(int eventoId)
        {
            try
            {
                var evento = await _eventoRepository.GetEventoByIdAsync(eventoId);

                if (evento == null)
                {
                    throw new Exception("Evento não encontrado para exclusão");
                }

                _eventoRepository.Delete(evento);
                return await _eventoRepository.SaveChangesAsync();
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public async Task<IEnumerable<Evento>> GetAllEventos(bool includePalestrantes = false)
        {
            try
            {
                var eventos = await _eventoRepository.GetEventosAsync(includePalestrantes);

                if (eventos == null)
                {
                    return null;
                }

                return eventos;
            }
            catch (Exception ex)
            {

                throw new Exception(ex.Message);
            }
        }

        public async Task<IEnumerable<Evento>> GetAllEventosByTema(string tema, bool includePalestrantes = false)
        {
            try
            {
                var eventos = await _eventoRepository.GetEventosByTemaAsync(tema, includePalestrantes);

                if (eventos == null)
                {
                    return null;
                }

                return eventos;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public async Task<Evento> GetEventoById(int eventoId, bool includePalestrantes = false)
        {
            try
            {
                var evento = await _eventoRepository.GetEventoByIdAsync(eventoId, includePalestrantes);

                if (evento == null)
                {
                    return null;
                }

                return evento;
            }
            catch (Exception ex)
            {

                throw new Exception(ex.Message);
            }
        }
    }
}
