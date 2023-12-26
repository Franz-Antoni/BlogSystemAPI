﻿using BlogSystem.Core.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BlogSystem.Core.Interfaces.Services
{
    public interface IUserAccountService
    {
        Task<UserAccount?> GetUserAccountByIdAsync(int id);
        Task<IEnumerable<UserAccount>> GetAllUserAccountAsync();
        Task<UserAccount> AddUserAccountAsync(UserAccount userAccount);
        Task UpdateUserAccountAsync(UserAccount userAccount);
        Task DeleteUserAccountAsync(int id);
    }
}
