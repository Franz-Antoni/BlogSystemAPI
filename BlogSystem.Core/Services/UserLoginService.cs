using BlogSystem.Core.Entities;
using BlogSystem.Core.Exceptions;
using BlogSystem.Core.Interfaces.Repositories;
using BlogSystem.Core.Interfaces.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BlogSystem.Core.Services
{
    public class UserLoginService : IUserLoginService
    {
        private readonly IUnitOfWork _unitOfWork;

        public UserLoginService(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public async Task<UserLogin> AddUserLoginAsync(UserLogin userLogin)
        {
            var existEmail = await _unitOfWork.UserLoginRepository.ExistsByEmail(userLogin.EmailAddress);

            if (existEmail) 
            {
                throw new ConflictException("Este email ya esta en uso.");
            }

            userLogin.Status = true;

            var response = await _unitOfWork.UserLoginRepository.AddAsync(userLogin);
            //await _unitOfWork.CompleteAsync();

            return response;
        }
    }
}
