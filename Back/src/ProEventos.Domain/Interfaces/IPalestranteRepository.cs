using ProEventos.Domain.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace ProEventos.Domain.Interfaces
{
    public interface IPalestranteRepository : IRepository<Palestrante>
    {
        Task<IEnumerable<Palestrante>> GetPalestrantesByNomeAsync(string nome, bool includeEventos = false); //Retornar todos palestrantes por nome
        Task<IEnumerable<Palestrante>> GetPalestrantesAsync(bool includeEventos = false); //Retornar todos os palestrantes
        Task<Palestrante> GetPalestranteByIdAsync(int palestranteId, bool includeEventos = false); //Retornar palestrante por id
    }
}
