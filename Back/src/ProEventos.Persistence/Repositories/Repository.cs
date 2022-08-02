using Microsoft.EntityFrameworkCore;
using ProEventos.Domain.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProEventos.Persistence.Repositories
{
    public abstract class Repository<T> : IRepository<T> where T : class
    {
        protected readonly ProEventosContext _context; //troca de private para protected para uso em classes derivadas
        protected readonly DbSet<T> dbSet; //DbSet genérico para a persistência comum de dados
        protected Repository(ProEventosContext context)
        {
            _context = context;
            dbSet = context.Set<T>();
        }
        public void Add(T entity)
        {
            //_context.Set<T>().Add(entity);
            dbSet.Add(entity);
        }

        public void Update(T entity)
        {
            dbSet.Update(entity);
        }

        public void Delete(T entity)
        {
            dbSet.Remove(entity);
         }

        public void DeleteRange(IEnumerable<T> entityCollection)
        {
            dbSet.RemoveRange(entityCollection);
        }

        public async Task<bool> SaveChangesAsync()
        {
            return await _context.SaveChangesAsync() > 0;
        }
    }
}
