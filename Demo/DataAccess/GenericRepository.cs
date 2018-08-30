using System;
using System.Data;
using System.Data.Common;
using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;

namespace DataAccess
{
    public class GenericRepository<T> : IGenericRepository<T> where T : BaseModel
    {
        protected readonly DemoContext _context;
        protected DbSet<T> _dbset;

        public GenericRepository(DemoContext context)
        {
            _context = context;
            _dbset = context.Set<T>();
        }

        public async Task Add(T entity)
        {
            _dbset.Add(entity);
            await _context.SaveChangesAsync();
        }

        public async Task Delete(T entity)
        {
            _dbset.Remove(entity);
            await _context.SaveChangesAsync();
        }

        public async Task Update(T entity)
        {
            _dbset.Update(entity);
            await _context.SaveChangesAsync();

        }

        public async Task<T> Get(long? id)
        {
            return await _dbset.SingleOrDefaultAsync(s => s.Id == id);
        }

        public async Task<IEnumerable<T>> GetAll()
        {
            return await _dbset.ToListAsync();
        }

        public async Task<bool> IsExists(long? id)
        {
            return await _dbset.AnyAsync(s=>s.Id == id);
        }
    }
}
