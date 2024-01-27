using BlogSystem.Core.Entities;
using BlogSystem.Core.Interfaces.Repositories;
using BlogSystem.Core.Interfaces.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;

namespace BlogSystem.Core.Services
{
    public class AccountAndLoginService : IAccountAndLoginService
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IUserAccountService _userAccountService;
        private readonly IUserLoginService _userLoginService;

        public AccountAndLoginService(IUnitOfWork unitOfWork, IUserAccountService userAccountService, IUserLoginService userLoginService)
        {
            _unitOfWork = unitOfWork;
            _userAccountService = userAccountService;
            _userLoginService = userLoginService;
        }

        public async Task AddAuthentication(UserAccount userAccount, UserLogin userLogin)
        {
            var login = await _userLoginService.AddUserLoginAsync(userLogin);

            userAccount.UserLogins.Add(login);
            await _userAccountService.AddUserAccountAsync(userAccount);

            await _unitOfWork.CompleteAsync();
        }
    }
}
