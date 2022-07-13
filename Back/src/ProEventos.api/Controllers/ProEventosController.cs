using Microsoft.AspNetCore.Mvc;
using ProEventos.api.Data;
using ProEventos.api.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Globalization;


namespace ProEventos.api.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class ProEventosController : ControllerBase
    {
        private readonly DataContext _context;
        public ProEventosController(DataContext context)
        {
            _context = context;
        }

        [HttpGet]
        [Route("eventos")]
        //Retorno de coleção de Eventos
        public IEnumerable<Evento> GetEventos()
        {
            return _context.Eventos.ToList();
        }

        //Retorno de Evento por Id
        [HttpGet]
        [Route("eventos/{id:int}")]
        public Evento GetEventoById(int id)
        {
            //return _context.Eventos.Where(e => e.Id == id).FirstOrDefault();
            return _context.Eventos.FirstOrDefault(e => e.Id == id);
        }
    }
}
