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
        private readonly IPostRepository _postRepository;

        public PostService(IPostRepository postRepository)
        {
            _postRepository = postRepository;
        }

        public async Task<Post?> GetPostByIdAsync(int id)
        {
            var post = await _postRepository.GetPostByIdAsync(id);
            return post;
        }

        public async Task<IEnumerable<Post>> GetPostsAsync()
        {
            var posts = await _postRepository.GetPostsAsync();
            return posts;
        }
    }
}
