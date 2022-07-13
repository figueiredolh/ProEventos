using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ProEventos.api.Models
{
    public class Evento
    {
        public int Id { get; set; }
        public string Imagem { get; set; }
        public string Tema { get; set; }
        public string Local { get; set; }
        public DateTime Data { get; set; }
        public int QtdPessoas { get; set; }
        public int Lote { get; set; }
        public string Opcoes { get; set; }
    }
}
