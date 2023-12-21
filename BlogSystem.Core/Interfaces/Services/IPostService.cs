using BlogSystem.Core.Entities;

namespace BlogSystem.Core.Interfaces.Services
{
    public interface IPostService
    {
        Task<Post?> GetPostByIdAsync(int id);
        Task<IEnumerable<Post>> GetPostsAsync();
    }
}