﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ProEventos.Domain.Models
{
    public class Evento
    {
        public int Id { get; set; }
        public string? ImagemUrl { get; set; }
        public string Tema { get; set; }
        public string Local { get; set; }
        public DateTime Data { get; set; }
        public int QtdPessoas { get; set; }
        public IEnumerable<Lote> Lotes { get; set; }
        public IEnumerable<RedeSocial>? RedesSociais { get; set; }
        public IEnumerable<EventoPalestrante> EventosPalestrantes { get; set; }
    }
}
