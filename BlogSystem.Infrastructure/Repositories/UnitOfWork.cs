using BlogSystem.Core.Interfaces.Repositories;
using BlogSystem.Infrastructure.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BlogSystem.Infrastructure.Repositories
{
    public class UnitOfWork : IUnitOfWork
    {
        private readonly BlogSystemContext _context;

        public IPostRepository PostRepository { get; }

        public IUserAccountRepository UserAccountRepository { get; }

        public UnitOfWork(BlogSystemContext context, IPostRepository postRepository, IUserAccountRepository userAccountRepository)
        {
            _context = context;
            PostRepository = postRepository;
            UserAccountRepository = userAccountRepository;
        }

        public async Task CompleteAsync() => await _context.SaveChangesAsync();

        public void Dispose()
        {
            if (_context != null)
            {
                _context.Dispose();
            }
        }
    }
}
