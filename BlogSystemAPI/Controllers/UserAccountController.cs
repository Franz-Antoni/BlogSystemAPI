using AutoMapper;
using BlogSystem.Api.Response;
using BlogSystem.Core.Dtos;
using BlogSystem.Core.Dtos.UserAccount.Request;
using BlogSystem.Core.Dtos.UserAccount.Response;
using BlogSystem.Core.Entities;
using BlogSystem.Core.Interfaces.Services;
using BlogSystem.Core.Services;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Net;

namespace BlogSystem.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserAccountController : ControllerBase
    {
        private readonly IUserAccountService _userAccountService;
        private readonly IMapper _mapper;

        public UserAccountController(IUserAccountService userAccountService, IMapper mapper)
        {
            _userAccountService = userAccountService;
            _mapper = mapper;
        }

        [HttpGet]
        public async Task<IActionResult> GetAllUserAccount()
        {
            var entities = await _userAccountService.GetAllUserAccountAsync();

            if (!entities.Any()) 
            {
                return NoContent();
            }

            var mappingEntities = _mapper.Map<IEnumerable<ReadUserAccountResponse>>(entities);

            var response = new ApiResponse<IEnumerable<ReadUserAccountResponse>>(mappingEntities);

            return Ok(response);
        }

        [HttpPost]
        public async Task<IActionResult> PostUserAccount([FromBody]CreateUserAccountRequest userAccountRequest) 
        {
            var request = _mapper.Map<UserAccount>(userAccountRequest);
            var entity = await _userAccountService.AddUserAccountAsync(request);

            var response = _mapper.Map<CreateUserAccountResponse>(entity);

            return Ok(response);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> PutUserAccount([FromRoute]int id, [FromBody]UpdateUserAccountRequest userAccountRequest) 
        {
            var request = _mapper.Map<UserAccount>(userAccountRequest);
            var entity = await _userAccountService.UpdateUserAccountAsync(id, request);

            var response = _mapper.Map<UpdateUserAccountResponse>(entity);

            return Ok(response);
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteUserAccount([FromRoute]int id) 
        {
            var entity = await _userAccountService.DeleteUserAccountAsync(id);

            var response = _mapper.Map<DeleteUserAccountResponse>(entity);

            return Ok(response);
        }
    }
}
