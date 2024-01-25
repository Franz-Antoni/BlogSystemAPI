using BlogSystem.Core.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BlogSystem.Core.Interfaces.Services
{
    public interface IAccountAndLoginService
    {
        Task AddAuthentication(UserAccount userAccount, UserLogin userLogin);
    }
}
