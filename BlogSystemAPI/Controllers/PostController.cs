using AutoMapper;
using BlogSystem.Api.Response;
using BlogSystem.Core.Dtos;
using BlogSystem.Core.Interfaces.Services;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Net;

namespace BlogSystem.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PostController : ControllerBase
    {
        private readonly IPostService _postService;
        private readonly IMapper _mapper;

        public PostController(IPostService postRepository, IMapper mapper)
        {
            _postService = postRepository;
            _mapper = mapper;
        }

        [HttpGet]
        public async Task<IActionResult> GetAllPost() 
        {
            var response = await _postService.GetPostsAsync();
            var posts = _mapper.Map<IEnumerable<PostDto>>(response);

            var result = new ApiResponse<IEnumerable<PostDto>>(posts);

            return Ok(result);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetPostById([FromRoute]int id)
        {
            var response = await _postService.GetPostByIdAsync(id);

            if (response == null) 
            {
                return NotFound();
            }

            var post = _mapper.Map<PostDto>(response);

            var result = new ApiResponse<PostDto>(post);

            return Ok(result);
        }
    }
}
