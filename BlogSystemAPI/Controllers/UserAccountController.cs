using AutoMapper;
using BlogSystem.Core.Dtos;
using BlogSystem.Core.Dtos.UserAccount.Request;
using BlogSystem.Core.Dtos.UserAccount.Response;
using BlogSystem.Core.Entities;
using BlogSystem.Core.Interfaces.Services;
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

        [HttpPost]
        public async Task<IActionResult> PostUserAccount(CreateUserAccountRequest userAccountRequest) 
        {
            var request = _mapper.Map<UserAccount>(userAccountRequest);
            var entity = await _userAccountService.AddUserAccountAsync(request);

            var response = _mapper.Map<CreateUserAccountResponse>(entity);

            return Ok(response);
        }

        [HttpPut]
        public async Task<IActionResult> PutUserAccount(UpdateUserAccountRequest userAccountRequest) 
        {
            var request = _mapper.Map<UserAccount>(userAccountRequest);
            var entity = await _userAccountService.UpdateUserAccountAsync(request);

            var response = _mapper.Map<UpdateUserAccountResponse>(entity);

            return Ok(response);
        }
    }
}
