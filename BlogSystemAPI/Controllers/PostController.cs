using AutoMapper;
using BlogSystem.Api.Response;
using BlogSystem.Core.Dtos;
using BlogSystem.Core.Dtos.Post.Response;
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
            var entities = await _postService.GetPostsAsync();

            if (!entities.Any()) 
            {
                return NoContent();
            }

            var mappingEntities = _mapper.Map<IEnumerable<ReadPostResponse>>(entities);

            var response = new ApiResponse<IEnumerable<ReadPostResponse>>(mappingEntities);

            return Ok(response);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetPostById([FromRoute]int id)
        {
            var entity = await _postService.GetPostByIdAsync(id);

            if (entity == null) 
            {
                return NotFound();
            }

            var mappingEntity = _mapper.Map<ReadPostResponse>(entity);

            var response = new ApiResponse<ReadPostResponse>(mappingEntity);

            return Ok(response);
        }
    }
}
