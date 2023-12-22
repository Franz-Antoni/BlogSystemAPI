using BlogSystem.Core.Entities;
using BlogSystem.Core.Interfaces.Repositories;
using BlogSystem.Core.Interfaces.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BlogSystem.Core.Services
{
    public class PostService : IPostService
    {
        private readonly IRepositoryGeneric<Post> _postRepository;

        public PostService(IRepositoryGeneric<Post> postRepository)
        {
            _postRepository = postRepository;
        }

        public async Task<Post?> GetPostByIdAsync(int id)
        {
            var post = await _postRepository.GetByIdAsync(id);
            return post;
        }

        public async Task<IEnumerable<Post>> GetPostsAsync()
        {
            var posts = await _postRepository.GetAllAsync();
            return posts;
        }
    }
}
