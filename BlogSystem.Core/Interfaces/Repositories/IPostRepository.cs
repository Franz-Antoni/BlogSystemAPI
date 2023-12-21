using BlogSystem.Core.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BlogSystem.Core.Interfaces.Repositories
{
    public interface IPostRepository
    {
        Task<IEnumerable<Post>> GetPostsAsync();
        Task<Post?> GetPostByIdAsync(int id);
    }
}
