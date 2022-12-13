using Neues.Core.Models;
using NeuesCore.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Neues.Core.Interface
{
    public interface IUser
    {
        public Task<IEnumerable<User>> GetAllUsers();

        public Task<User> GetUser(Guid Id);

        public Task UpdateUser(User user);

        public Task<User> DeleteUser(Guid Id);

        public Task<User> CreateUser(User user);

        public Task<bool> IsUserExist(string email);

        Task<bool> UpdateUserPassword(string email, string password);

        //public Task<User> ResetPassword(ForgotPassword password);
    }
}
