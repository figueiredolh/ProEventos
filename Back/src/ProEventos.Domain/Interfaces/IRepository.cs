using System.Threading.Tasks;
using System.Collections.Generic;

namespace ProEventos.Domain.Interfaces
{
    public interface IRepository<T> where T : class
    {
        void Add(T entity);
        void Update(T entity);
        void Delete(T entity);
        void DeleteRange(IEnumerable<T> entityCollection);
        Task<bool> SaveChangesAsync();
    }
}
