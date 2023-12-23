using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace BlogSystem.Core.Interfaces.Repositories
{
    public interface IRepositoryGeneric<T> where T : class
    {
        Task<IEnumerable<T>> GetAllAsync();
        Task<IEnumerable<T>> GetByConditionAsync(Expression<Func<T,bool>> expression);
        Task<T?> GetByIdAsync(int id);
    }
}
