using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BlogSystem.Core.Interfaces.Repositories
{
    public interface IUnitOfWork : IDisposable
    {
        IPostRepository PostRepository { get; }
        IUserAccountRepository UserAccountRepository { get; }
        Task CompleteAsync();
    }
}
