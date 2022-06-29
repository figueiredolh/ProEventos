using Microsoft.AspNetCore.Mvc;
using ProEventos.api.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;


namespace ProEventos.api.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class ProEventosController : ControllerBase
    {
        private Evento[] _eventos = new Evento[]{
            new Evento()
            {
                Id = 1,
                Name = "Aniversário",
                Date = DateTime.Now
            },
            new Evento()
            {
                Id = 2,
                Name = "Jogo do Paysandu",
                Date = DateTime.Now
            },
            new Evento()
            {
                Id = 3,
                Name = "Trabalho",
                Date = DateTime.Now
            }
        };

        [HttpGet]
        [Route("eventos")]
        //Get para retorno da coleção de Eventos
        public IEnumerable<Evento> GetEventos()
        {
            return _eventos;
        }

        //Get para retorno de Evento por Id
        [HttpGet]
        [Route("eventos/{id:int}")]
        public Evento GetEventoById(int id)
        {
            var evento = _eventos.Where(e => e.Id == id).FirstOrDefault();
            return evento;
        }
    }
}
