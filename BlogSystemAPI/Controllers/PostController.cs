using BlogSystem.Core.Interfaces;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Net;

namespace BlogSystem.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PostController : ControllerBase
    {
        private readonly IPostRepository _postRepository;

        public PostController(IPostRepository postRepository)
        {
            _postRepository = postRepository;
        }

        [HttpGet]
        public async Task<IActionResult> GetAllPost() 
        {
            var posts = await _postRepository.GetPostsAsync();
            return Ok(posts);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetPostById([FromRoute]int id)
        {
            var post = await _postRepository.GetPostByIdAsync(id);

            if (post == null) 
            {
                return NotFound();
            }

            return Ok(post);
        }
    }
}
