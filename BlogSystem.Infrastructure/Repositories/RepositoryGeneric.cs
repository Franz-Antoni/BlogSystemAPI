using BlogSystem.Core.Interfaces.Repositories;
using BlogSystem.Infrastructure.Data;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace BlogSystem.Infrastructure.Repositories
{
    public class RepositoryGeneric<T> : IRepositoryGeneric<T> where T : class
    {
        private readonly BlogSystemContext _context;

        public RepositoryGeneric(BlogSystemContext context)
        {
            _context = context;
        }

        public async Task<IEnumerable<T>> GetAllAsync()
        {
            var response = await _context.Set<T>().ToListAsync();

            return response;
        }

        public async Task<IEnumerable<T>> GetByConditionAsync(Expression<Func<T, bool>> expression)
        {
            var response = await _context.Set<T>().Where(expression).AsNoTracking().ToListAsync();
            
            return response;
        }

        public async Task<T?> GetByIdAsync(int id)
        {
            var response = await _context.Set<T>().FindAsync(id);

            return response;
        }
    }
}
