using AutoMapper;
using BlogSystem.Core.Dtos.AccountAndLogin.Request;
using BlogSystem.Core.Dtos.UserLogin.Request;
using BlogSystem.Core.Entities;
using BlogSystem.Core.Interfaces.Services;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace BlogSystem.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AuthenticationController : ControllerBase
    {
        private readonly IAccountAndLoginService _accountAndLoginService;
        private readonly IMapper _mapper;

        public AuthenticationController(IAccountAndLoginService accountAndLoginService, IMapper mapper)
        {
            _accountAndLoginService = accountAndLoginService;
            _mapper = mapper;
        }

        [HttpPost("Register")]
        public async Task<IActionResult> Register(CreateAccountAndLoginRequest createAccountAndLoginRequest) 
        {
            var accountRequest = _mapper.Map<UserAccount>(createAccountAndLoginRequest);
            var loginRequest = _mapper.Map<UserLogin>(createAccountAndLoginRequest);

            await _accountAndLoginService.AddAuthentication(accountRequest, loginRequest);
            return Ok();
        }

        [HttpPost("Login")]
        public async Task<IActionResult> Authentication(ReadAccountAndLoginRequest readAccountAndLoginRequest)
        {
            var response = await _accountAndLoginService.GetAuthentication(readAccountAndLoginRequest.EmailAddress, 
                readAccountAndLoginRequest.Password);

            return Ok(response);
        }
    }
}
