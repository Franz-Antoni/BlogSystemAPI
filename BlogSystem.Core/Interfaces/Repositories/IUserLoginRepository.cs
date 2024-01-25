using BlogSystem.Core.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BlogSystem.Core.Interfaces.Repositories
{
    public interface IUserLoginRepository : IRepositoryGeneric<UserLogin>
    {
        Task<bool> ExistsByEmail(string emailAddress);
    }
}
