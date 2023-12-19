using BlogSystem.Core.Entities;
using BlogSystem.Core.Interfaces;
using BlogSystem.Infrastructure.Data;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BlogSystem.Infrastructure.Repositories
{
    public class PostRepository : IPostRepository
    {
        private readonly BlogSystemContext _context;

        public PostRepository(BlogSystemContext context)
        {
            _context = context;
        }

        public async Task<Post?> GetPostByIdAsync(int id)
        {
            var post = await _context.Posts.FirstOrDefaultAsync(x => x.Id == id);
            return post;
        }

        public async Task<IEnumerable<Post>> GetPostsAsync()
        {
            var posts = await _context.Posts.ToListAsync();
            return posts;
        }
    }
}
