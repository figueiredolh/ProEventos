using Microsoft.EntityFrameworkCore;
using ProEventos.Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProEventos.Persistence
{
    public class ProEventosContext : DbContext
    {
        public ProEventosContext(DbContextOptions options) : base(options)
        {

        }

        public DbSet<Evento> Eventos { get; set; }
        public DbSet<Palestrante> Palestrantes { get; set; }
        public DbSet<RedeSocial> RedesSociais { get; set; }
        public DbSet<Lote> Lotes { get; set; }
        public DbSet<EventoPalestrante> EventosPalestrantes { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            //Configuração de chave composta para Entidade Associativa
            modelBuilder.Entity<EventoPalestrante>().HasKey(ep => new { ep.EventoId, ep.PalestranteId});

            //Configuração de Delete Cascade para uma chave estrangeira independente. Ou seja, para casos em que houver 2 ou mais chaves estrangeiras, a exclusão de 1 delas
            //impactará a exclusão de todo o registro relacionado, independentemente se houver outras chaves nela relacionadas

            //Para entidade (FK) Evento em Redes Sociais
            modelBuilder.Entity<Evento>().HasMany(e => e.RedesSociais).WithOne(rs => rs.Evento).OnDelete(DeleteBehavior.Cascade);

            //Para entidade (FK) Palestrante em Redes Sociais
            modelBuilder.Entity<Palestrante>().HasMany(p => p.RedesSociais).WithOne(rs => rs.Palestrante).OnDelete(DeleteBehavior.Cascade);
        }
    }
}
