using BlogSystem.Core.Entities;
using BlogSystem.Core.Interfaces.Repositories;
using BlogSystem.Infrastructure.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BlogSystem.Infrastructure.Repositories
{
    public class UserAccountRepository : RepositoryGeneric<UserAccount>, IUserAccountRepository
    {
        public UserAccountRepository(BlogSystemContext context) : base(context)
        {
        }
    }
}
