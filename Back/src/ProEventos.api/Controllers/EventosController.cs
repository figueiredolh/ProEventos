using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Globalization;
using ProEventos.Application.Interfaces;
using Microsoft.AspNetCore.Http;
using ProEventos.Domain.Models;

namespace ProEventos.api.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class EventosController : ControllerBase
    {
        private readonly IEventoService _eventoService;
        public EventosController(IEventoService eventoService)
        {
            _eventoService = eventoService;
        }

        [HttpGet]
        public async Task<IActionResult> GetEventos()
        {
            try
            {
                var eventos = await _eventoService.GetAllEventos();
                
                if(eventos == null) //if(eventos == null || eventos.Count() <= 0)
                {
                    return NotFound("Nenhum evento encontrado");
                }

                return Ok(eventos);
            }
            catch (Exception ex)
            {

                return this.StatusCode(StatusCodes.Status500InternalServerError, $"Houve um erro ao recuperar eventos. Mensagem de erro: {ex.Message}");
            }
        }

        [HttpGet]
        [Route("tema/{tema}")]
        public async Task<IActionResult> GetEventosByTema(string tema)
        {
            try
            {
                var eventos = await _eventoService.GetAllEventosByTema(tema);

                if(eventos == null)
                {
                    return NotFound("Nenhum evento por tema encontrado");
                }

                return Ok(eventos);
            }
            catch (Exception ex)
            {
                return this.StatusCode(StatusCodes.Status500InternalServerError, $"Houve um erro ao recuperar eventos por tema. Erro: {ex.Message}");
            }
        }

        [HttpGet]
        [Route("evento/{id:int}")]
        public async Task<IActionResult> GetEventoById(int id)
        {
            try
            {
                var evento = await _eventoService.GetEventoById(id);

                if(evento == null)
                {
                    return NotFound("Nenhum evento encontrado");
                }

                return Ok(evento);
            }
            catch (Exception ex)
            {
                return this.StatusCode(StatusCodes.Status500InternalServerError, $"Erro ao recuperar evento. Erro: {ex.Message}");
            }
        }

        [HttpPost]
        public async Task<IActionResult> CreateEvento(Evento model)
        {
            try
            {
                var evento = await _eventoService.AddEvento(model);

                if(evento == null)
                {
                    return BadRequest("Erro ao adicionar evento");
                }

                return Ok(evento);
            }
            catch (Exception ex)
            {
                return this.StatusCode(StatusCodes.Status500InternalServerError, $"Houve um erro ao adicionar evento. Erro {ex.Message}");
            }
        }

        [HttpPut]
        [Route("evento/{id:int}")]

        public async Task<IActionResult> UpdateEvento(int id, Evento model)
        {
            try
            {
                var evento = await _eventoService.UpdateEvento(id, model);

                if(evento == null)
                {
                    return BadRequest("Erro ao atualizar evento");
                }

                return Ok(evento);
            }
            catch (Exception ex)
            {
                return this.StatusCode(StatusCodes.Status500InternalServerError, $"Houve um erro ao adicionar evento. Erro {ex.Message}");
            }
        }

        [HttpDelete]
        [Route("evento/{id:int}")]

        public async Task<IActionResult> DeleteEvento(int id)
        {
            try
            {
                var isDeleted = await _eventoService.DeleteEvento(id);

                if(!isDeleted)
                {
                    return BadRequest("Erro ao excluir evento");
                }

                return Ok("Excluido com sucesso");
            }
            catch (Exception ex)
            {
                return this.StatusCode(StatusCodes.Status500InternalServerError, $"Houve um erro ao adicionar evento. Erro {ex.Message}");
            }
        }

    }
}
