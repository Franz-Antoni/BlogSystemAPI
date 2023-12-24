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
        private readonly IUnitOfWork _unitOfWork;

        public PostService(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public async Task<Post?> GetPostByIdAsync(int id)
        {
            var post = await _unitOfWork.PostRepository.GetByIdAsync(id);
            return post;
        }

        public async Task<IEnumerable<Post>> GetPostsAsync() 
        {
            var posts = await _unitOfWork.PostRepository.GetByConditionAsync(x => x.Status == true);
            return posts;
        }
    }
}
