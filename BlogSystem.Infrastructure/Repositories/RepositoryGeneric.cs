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
        protected readonly BlogSystemContext _context;

        public RepositoryGeneric(BlogSystemContext context)
        {
            _context = context;
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

        public async Task<T> AddAsync(T entity)
        {
            await _context.Set<T>().AddAsync(entity);
            return entity;
        }

        public async Task UpdateAsync(T entity)
        {
            _context.Entry(entity).State = EntityState.Modified;
            await Task.CompletedTask;
        }

        public async Task DeleteAsync(T entity)
        {
            _context.Entry(entity).State = EntityState.Modified;
            await Task.CompletedTask;
        }
    }
}
