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
    public class UserAccountService : IUserAccountService
    {
        private readonly IUnitOfWork _unitOfWork;

        public UserAccountService(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public async Task<IEnumerable<UserAccount>> GetAllUserAccountAsync()
        {
            var response = await _unitOfWork.UserAccountRepository.GetByConditionAsync(x => x.Status == true);
            return response;
        }

        public async Task<UserAccount?> GetUserAccountByIdAsync(int id)
        {
            var response = await _unitOfWork.UserAccountRepository.GetByIdAsync(id);
            return response;
        }

        public async Task<UserAccount> AddUserAccountAsync(UserAccount userAccount)
        {
            userAccount.Status = true;

            var response = await _unitOfWork.UserAccountRepository.AddAsync(userAccount);
            await _unitOfWork.CompleteAsync();

            return response;
        }

        public async Task<UserAccount?> UpdateUserAccountAsync(int id, UserAccount userAccount)
        {
            var response = await GetUserAccountByIdAsync(id);
            
            if (response == null) 
            {
                throw new NotFoundException("No se encontro la entidad");
            }

            response.FullName = userAccount.FullName;
            response.LastName = userAccount.LastName;
            response.Gender = userAccount.Gender;
            response.DateOfBirth = userAccount.DateOfBirth;
            response.Status = userAccount.Status;

            await _unitOfWork.UserAccountRepository.UpdateAsync(response);
            await _unitOfWork.CompleteAsync();

            return userAccount;
        }

        public async Task<UserAccount?> DeleteUserAccountAsync(int id)
        {
            var response = await GetUserAccountByIdAsync(id);
            
            if (response == null) 
            {
                throw new NotFoundException("No se encontro la entidad");
            }

            response.Status = false;

            await _unitOfWork.UserAccountRepository.DeleteAsync(response);
            await _unitOfWork.CompleteAsync();

            return response;
        }
    }
}
