using BlogSystem.Core.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BlogSystem.Core.Interfaces.Services
{
    public interface IUserLoginService
    {
        Task<UserLogin> AddUserLoginAsync(UserLogin userLogin);
        Task<UserLogin?> GetUserLoginByAddressAsync(string emailAddress);
    }
}
