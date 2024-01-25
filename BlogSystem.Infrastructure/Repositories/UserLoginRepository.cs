using BlogSystem.Core.Entities;
using BlogSystem.Core.Interfaces.Repositories;
using BlogSystem.Infrastructure.Data;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BlogSystem.Infrastructure.Repositories
{
    public class UserLoginRepository : RepositoryGeneric<UserLogin>, IUserLoginRepository
    {
        public UserLoginRepository(BlogSystemContext context) : base(context)
        {
        }

        public async Task<bool> ExistsByEmail(string emailAddress)
        {
            var response = await _context.Set<UserLogin>().AnyAsync(x => x.EmailAddress == emailAddress);
            return response;
        }
    }
}
